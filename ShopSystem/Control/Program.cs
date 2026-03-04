namespace ShopSystem.Control
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AuthenticationControl auth = new AuthenticationControl();

            auth.InitializeAuthentication();
        }
    }
}
