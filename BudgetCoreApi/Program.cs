using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetCoreApi
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/"; 

            await WebHost.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    // services.AddMvc();
                    services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    }));

                    // Add framework services.
                    services.AddMvc();
                    // services.Configure<MvcOptions>(options =>
                    // {
                    //     options.Filters.Add(new CorsAuthorizationFilterFactory("MyPolicy"));
                    // }

                })
                .Configure(app => app.UseMvc())
                .Build()
                .RunAsync();
        }
    }
}