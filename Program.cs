using LayeredArchitecture.Repositories;
using LayeredArchitecture.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LayeredArchitecture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();
            using var scope = serviceProvider.CreateScope();

            var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
            
        }

        private static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<ApplicationDbContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBankAccountRepository, BankAccountRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBankAccountService, BankAccountService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IBankServices, BankServices>();

            return services.BuildServiceProvider();
        }
    }
}
