namespace ShopSystem.View
{
    internal class AuthenticationView
    {
        public void InitializeView(out string usernameInput, out string passwordInput)
        {
            Console.Clear();
            Console.WriteLine("\t-----Shop-----");
            Console.Write("\nPlease enter your username: ");
            usernameInput = Input();
            Console.Write("Please enter your password: ");
            passwordInput = Input();
        }

        public void InvalidInputUsername(out string usernameInput, out string passwordInput)
        {
            Console.Clear();
            Console.WriteLine("\t-----Shop-----");
            Console.WriteLine("\nInvalid input: Username not found!");
            Console.WriteLine("Please try again");
            Console.Write("\nUsername: ");
            usernameInput = Input();
            Console.Write("Password: ");
            passwordInput = Input();
        }

        public void InvalidInputPassword(out string usernameInput, out string passwordInput)
        {
            Console.Clear();
            Console.WriteLine("\t-----Shop-----");
            Console.WriteLine("\nInvalid input: Password incorrect!");
            Console.WriteLine("Please try again");
            Console.Write("\nUsername: ");
            usernameInput = Input();
            Console.Write("Password: ");
            passwordInput = Input();
        }

        private string Input()
        {
            string input = Console.ReadLine();
            return input;
        }
    }
}
