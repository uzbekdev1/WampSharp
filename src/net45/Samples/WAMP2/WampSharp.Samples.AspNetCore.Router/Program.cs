﻿using System.IO;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using WampSharp.AspNetCore.RawSocket;
using WampSharp.AspNetCore.WebSockets.Server;
using WampSharp.Binding;
using WampSharp.V2;

namespace WampSharp.Samples.AspNetCore.Router
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WampHost wampHost = new WampHost();

            JTokenJsonBinding jsonBinding = new JTokenJsonBinding();
            JTokenCborBinding cborBinding = new JTokenCborBinding();
            JTokenMessagePackBinding messagePackBinding = new JTokenMessagePackBinding();

            IWebHost host =
                WebHost.CreateDefaultBuilder(args)
                       .UseKestrel(options =>
                                   {
                                       options.Listen(IPAddress.Loopback, 8080,
                                                      builder =>
                                                      {
                                                          // Log all of the http bytes as they are sent and received
                                                          builder.UseConnectionLogging();

                                                          // Configure RawSocket transport
                                                          wampHost
                                                              .RegisterTransport(new AspNetCoreRawSocketTransport(builder),
                                                                                 jsonBinding,
                                                                                 cborBinding,
                                                                                 messagePackBinding);
                                                      });
                                   })
                       .Configure(app =>
                                  {
                                      app.Map("/ws",
                                              builder =>
                                              {
                                                  builder.UseWebSockets();

                                                  // Configure WebSockets transport
                                                  wampHost
                                                      .RegisterTransport(new AspNetCoreWebSocketTransport(builder, null),
                                                                         jsonBinding,
                                                                         cborBinding,
                                                                         messagePackBinding);
                                              });

                                      app.UseStaticFiles(new StaticFileOptions
                                      {
                                          FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "static")),
                                          RequestPath = ""
                                      });

                                      wampHost.Open();
                                  })
                       .Build();

            host.Run();
        }
    }
}
