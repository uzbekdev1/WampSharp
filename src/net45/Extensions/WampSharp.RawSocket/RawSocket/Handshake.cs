using System;
using System.Linq;

namespace WampSharp.RawSocket
{
    public class Handshake
    {
        private const int RawSocketMagicOctet = 0x7F;

        /// <summary>
        /// Creates a new instance of a <see cref="Handshake"/>.
        /// </summary>
        /// <param name="maxLength">The max length to send. 0 for 2^9, 1 for 2^10, ..., 15 for 2^24</param>
        /// <param name="serializerType">The serializer type.</param>
        public Handshake(byte maxLength, SerializerType serializerType)
        {
            MagicOctet = RawSocketMagicOctet;

            if (maxLength >= 16)
            {
                throw new ArgumentOutOfRangeException("maxLength", "Expected a value between 0 to 15");
            }

            if (serializerType != SerializerType.Json && 
                serializerType != SerializerType.MsgPack)
            {
                throw new ArgumentException("Expected a value between 1 to 2", "serializerType");
            }

            SecondOctet = (byte) ((maxLength << 4) + (byte)serializerType);
        }

        public Handshake(HandshakeErrorCode errorCode)
        {
            MagicOctet = RawSocketMagicOctet;

            if (errorCode == HandshakeErrorCode.Illegal)
            {
                throw new ArgumentException("HandshakeErrorCode.Illegal must not be used",
                                            "errorCode");
            }

            SecondOctet = (byte)(((byte)errorCode) << 4);
        }

        public Handshake(byte[] message)
        {
            if (message == null || message.Length != 4)
            {
                throw new ArgumentException("Expected a 4 length byte array.", "message");
            }

            MagicOctet = message[0];

            if (MagicOctet != RawSocketMagicOctet)
            {
                throw new ArgumentException($"First octet must be 0x{RawSocketMagicOctet:X}.",
                                            "message");
            }

            SecondOctet = message[1];

            ReservedOctets = BitConverter.ToInt16(message, 2);
        }

        // Should be 0x7F
        public byte MagicOctet { get; set; }

        public byte SecondOctet { get; set; }

        public short ReservedOctets { get; set; }

        public int MaxMessageSizeInBytes
        {
            get
            {
                // 0 - (1 << 9) octets
                // 1 - (1 << 10) octets
                // ...
                // 15 - (1 << 24) octets
                int sizeHalfByte = SecondOctet >> 4;
                int size = sizeHalfByte + 9;
                return 1 << size;
            }
        }

        public SerializerType SerializerType
        {
            get
            {
                int serializerHalfByte = SecondOctet & 0x0F;
                return (SerializerType) serializerHalfByte;
            }
        }

        public HandshakeErrorCode? HandshakeError
        {
            get
            {
                if (!IsError)
                {
                    return null;
                }

                int errorHalfByte = SecondOctet >> 4;

                return (HandshakeErrorCode) errorHalfByte;
            }
        }

        public bool IsError
        {
            get
            {
                return (SerializerType == SerializerType.Illegal);
            }
        }

        public byte[] ToArray()
        {
            byte[] firstOctets = {MagicOctet, SecondOctet};
            byte[] reservedBytes = BitConverter.GetBytes(ReservedOctets);

            return firstOctets.Concat(reservedBytes).ToArray();
        }

        public Handshake GetAcceptedResponse(byte maxLength)
        {
            return new Handshake(maxLength, SerializerType);
        }

        public Handshake GetErrorResponse(HandshakeErrorCode errorCode)
        {
            return new Handshake(errorCode);
        }

        public static bool TryParse(byte[] message, out Handshake result)
        {
            result = default(Handshake);

            if (message == null || message.Length != 4)
            {
                throw new ArgumentException("Expected a 4 length byte array.", "message");
            }

            byte magicOctet = message[0];

            if (magicOctet != RawSocketMagicOctet)
            {
                return false;
            }

            result = new Handshake(message);
            return true;
        }
    }
}