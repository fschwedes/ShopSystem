namespace ShopSystem.Control
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MasterController masterController = new MasterController();
            CustomerController customerController = new CustomerController();
            AuthenticationController auth = new AuthenticationController();

            customerController.InitializeCustomerCatalog();
            auth.InitializeAuthentication();
        }
    }
}
