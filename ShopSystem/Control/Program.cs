namespace ShopSystem.Control
{
    internal class Program
    {
        //einstieg in das program über die Start methode
        static void Main(string[] args)
        {
            MasterController masterController = new MasterController();

            masterController.Start();
        }
    }
}
