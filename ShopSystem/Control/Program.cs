namespace ShopSystem.Control
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AuthenticationController auth = new AuthenticationController();
            MasterController master = new MasterController();

            auth.InitializeAuthentication();
        }
    }
}
