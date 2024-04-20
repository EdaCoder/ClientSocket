using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace ClientSocket
{
    public class WebHost
    {
        public static void StartWeb()
        {
            Host.CreateDefaultBuilder().ConfigureWebHostDefaults(t =>
            {
                t.UseKestrel();
                t.ConfigureKestrel(x => x.ListenAnyIP(99));
                t.ConfigureServices(services =>
                {
                    services.AddControllers().AddNewtonsoftJson(opt =>
                    {
                        opt.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                        opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    });
                    services.AddSwaggerGen(opt =>
                    {
                        opt.SwaggerDoc("v1", new OpenApiInfo { Title = "客服端通信", Version = "v1" });
                    });
                });
                t.Configure(app =>
                {
                    app.UseSwagger();
                    app.UseSwaggerUI(opt =>
                    {
                        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "客服端通信");
                    });
                    app.UseRouting();

                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers();
                    });
                });
            }).Build().Start();
        }
    }
}
