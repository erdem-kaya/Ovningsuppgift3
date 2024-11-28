using Bussiness.Dtos;
using Bussiness.Factories;
using Bussiness.Services;

namespace MainApp.Services
{
    public class MenuService
    {
        private readonly UserService _userService = new();

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("---------- MENU OPTIONS ----------");
            Console.WriteLine($" {"1.",-3} Create User");
            Console.WriteLine($" {"2.",-3} View All Users");
            Console.WriteLine($" {"3.",-3} Remove All Users");
            Console.WriteLine($" {"Q.",-3} Quit");
            Console.WriteLine("---------------------------------");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice.ToLower())
            {
                case "1":
                    CreateUser();
                    break;
                case "2":
                    ViewAllUsers();
                    break;
                case "3":
                    RemoveAllUsers();
                    break;
                case "q":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.ReadKey();
                    ShowMenu();
                    break;
            }
        }

        public void CreateUser()
        {
            Console.Clear();
            Console.WriteLine("---------- CREATE USER ----------");

            // Create a new user
            UserRegistrationForm user = UserFactory.Create();
            // Get user input for first name, last name, email, password and confirm password
            Console.Write("Enter your first name: ");
            user.FirstName = Console.ReadLine();

            Console.Write("Enter your last name: ");
            user.LastName = Console.ReadLine();

            Console.Write("Enter your email: ");
            user.Email = Console.ReadLine();

            //Validate user password and confirm password match
            while (true)
            {
                Console.Write("Enter your password: ");
                user.Password = Console.ReadLine();

                Console.Write("Confirm your password: ");
                user.ConfirmPassword = Console.ReadLine();
                // If password and confirm password match, break the loop
                if (user.Password == user.ConfirmPassword)
                {
                    break;
                }
                // If password and confirm password do not match, display error message
                else
                {
                    Console.WriteLine("Passwords do not match. Please try again.");
                }
            }
            
            // Add user to the list
            _userService.Add(user);
            Console.WriteLine("User created successfully.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Press ENTER to go to the Main Menu");
            Console.ReadKey();
            
            ShowMenu();
        }


        public void ViewAllUsers()
        {
            Console.Clear();
            Console.WriteLine("---------- ALL USERS ----------");
            // Get all users
            var users = _userService.GetAll();
            // If no users found
            if (users.Count() == 0)
            {
                Console.WriteLine("No users found.");
            }
            // Display all users found in the list
            else
            {
                foreach (var user in users)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{"Id: ", -15 } {user.Id}");
                    Console.WriteLine($"{"Name: ",-15 } {user.FirstName} {user.LastName}");
                    Console.WriteLine($"{"Email: ",-15 } {user.Email}");
                    Console.WriteLine($"{"Created At: ",-15 } {user.CreatedAt}");
                    Console.WriteLine();
                    Console.WriteLine("---------------------------------");
                }
            }
            Console.WriteLine("Press ENTER to go to the Main Menu");
            Console.ReadKey();
            ShowMenu();
        }

        public void RemoveAllUsers()
        {
            Console.Clear();
            Console.WriteLine("---------- REMOVE ALL USERS ----------");
            Console.WriteLine("Are you sure you want to remove all users? (Y/N)");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "y")
            {
                // Remove all users from the list
                _userService.RemoveAll();
                Console.WriteLine("All users have been removed.");
            }
            else if (choice.ToLower() == "n")
            {
                Console.WriteLine("Operation cancelled.");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
            Console.WriteLine("Press ENTER to go to the Main Menu");
            Console.ReadKey();
            ShowMenu();
        }
    }
}
