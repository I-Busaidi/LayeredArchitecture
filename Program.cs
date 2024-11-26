using LayeredArchitecture.Repositories;
using LayeredArchitecture.Services;
using Microsoft.Extensions.DependencyInjection;
using LayeredArchitecture.Models;

namespace LayeredArchitecture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();
            using var scope = serviceProvider.CreateScope();

            var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
            var bankAccountService = scope.ServiceProvider.GetRequiredService<IBankAccountService>();
            var transactionService = scope.ServiceProvider.GetRequiredService<ITransactionService>();
            var bankService = scope.ServiceProvider.GetRequiredService<IBankServices>();

            RunProgram(userService, bankAccountService, transactionService, bankService);
        }

        private static void RunProgram(IUserService userService, IBankAccountService bankAccountService, ITransactionService transactionService, IBankServices bankService)
        {
            string header = "Select an operation from the list:";
            string[] options = {"Add User", "Add Account", "Deposit", "Withdraw", "Transfer", "Exit"};
            int choice = -1;
            do
            {
                choice = ArrowKeySelection(options.ToList(), header);
                Console.Clear();
                switch(choice)
                {
                    case 0:
                        AddUser(userService);
                        break;

                    case 1:
                        AddBankAccount(bankAccountService);
                        break;

                    case 2:
                        Deposit(bankService);
                        break;

                    case 3:
                        Withdraw(bankService);
                        break;

                    case 4:
                        Transfer(bankService);
                        break;

                    case 5:
                    case -1:
                        break;

                    default:
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            while (choice != 5);
        }

        private static void AddUser(IUserService userService)
        {
            Console.Clear();
            Console.WriteLine("Enter the user name: ");
            string name = Console.ReadLine();

            Console.WriteLine($"Enter the eamil for user {name}");
            string email = Console.ReadLine();

            userService.AddUser(new User
            {
                Name = name,
                Email = email
            });
        }

        private static void AddBankAccount(IBankAccountService bankAccountService)
        {
            Console.Clear();
            Console.WriteLine("Enter the user ID of the account owner: ");
            int userId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the account number: ");
            string accNumber = Console.ReadLine();

            Console.WriteLine("Enter the initial balance: ");
            decimal initBalance = decimal.Parse(Console.ReadLine());

            bankAccountService.AddAccount(new BankAccount
            {
                AccountNumber = accNumber,
                Balance = initBalance,
                UserId = userId
            });
        }

        private static void Deposit(IBankServices bankServices)
        {
            Console.Clear();
            Console.WriteLine("Enter the account number: ");
            string accNum = Console.ReadLine();

            Console.WriteLine("Enter the amount to deposit: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            string result = bankServices.Deposit(accNum, amount);

            Console.WriteLine(result);
        }

        private static void Withdraw(IBankServices bankServices)
        {
            Console.Clear();
            Console.WriteLine("Enter the account number: ");
            string accNum = Console.ReadLine();

            Console.WriteLine("Enter the amount to withdraw: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            string result = bankServices.Withdraw(accNum, amount);

            Console.WriteLine(result);
        }

        private static void Transfer(IBankServices bankServices)
        {
            Console.Clear();
            Console.WriteLine("Enter the source account number: ");
            string sourceAccNum = Console.ReadLine();

            Console.WriteLine("Enter the destination account number: ");
            string destAccNum = Console.ReadLine();

            Console.WriteLine("Enter the amount to transfer: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            string result = bankServices.Transfer(sourceAccNum, destAccNum, amount);

            Console.WriteLine(result);
        }

        private static int ArrowKeySelection(List<string> options, string head)
        {
            int selectedIndex = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(head + "\n\n");
                for (int i = 0; i < options.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.WriteLine($">> {options[i]} <<");
                    }
                    else
                    {
                        Console.WriteLine($"   {options[i]}");
                    }
                }
                Console.WriteLine("\n\nUse arrow keys to select. or 'Esc' to exit menu");
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : options.Count - 1;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex < options.Count - 1) ? selectedIndex + 1 : 0;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    return selectedIndex;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    return -1;
                }
            }
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
