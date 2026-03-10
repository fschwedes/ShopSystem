using ShopSystem.Control;

namespace ShopSystem.View
{
    internal class AuthenticationView
    {
        private AuthenticationController _controller;

        //der sich selbst übergebende controller wird hier referiert
        public AuthenticationView(AuthenticationController controller)
        {
            _controller = controller;
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
            _controller.CheckInput(username, password);
        }

        public void InvalidInput()
        {
            Console.Clear();
            Console.WriteLine("\t-----Shop-----");
            Console.WriteLine("\nInvalid input!");
            Console.WriteLine("Please try again");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            Authenticate();

        }
    }
}
