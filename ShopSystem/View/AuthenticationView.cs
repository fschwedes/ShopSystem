using ShopSystem.Control;

namespace ShopSystem.View
{
    internal class AuthenticationView
    {
        private AuthenticationController controller;
        public AuthenticationView(AuthenticationController controller)
        {
            this.controller = controller;
        }
        public void Authenticate()
        {
            string username;
            string password;
            Console.Clear();
            Console.WriteLine("\t-----Shop-----");
            Console.Write("\nPlease enter your username: ");
            username = Console.ReadLine();
            Console.Write("Please enter your password: ");
            password = Console.ReadLine();
            controller.CheckInput(username, password);
        }

        public void InvalidInput()
        {
            Console.Clear();
            Console.WriteLine("\t-----Shop-----");
            Console.WriteLine("\nInvalid input!");
            Console.WriteLine("Please try again");
            Console.ReadLine();
            Authenticate();

        }
    }
}
