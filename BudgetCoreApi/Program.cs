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
                .ConfigureServices(services => services.AddMvc())
                .Configure(app => app.UseMvc())
                .Build()
                .RunAsync();
        }
    }
}