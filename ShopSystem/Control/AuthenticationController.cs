using ShopSystem.Model;
using ShopSystem.View;

namespace ShopSystem.Control
{
    internal class AuthenticationController : MasterController
    {
        public int InitializeAuthentication()
        {
            AuthenticationView authenticationView = new AuthenticationView();
            MasterController masterController = new MasterController();

            int activeUser;
            string usernameInput;
            string passwordInput;

            authenticationView.InitializeView(out usernameInput, out passwordInput);
            activeUser = CheckInput(authenticationView, masterController.Accounts(), ref usernameInput, ref passwordInput);

            return activeUser;
        }

        private int CheckInput(AuthenticationView authenticationView, List<Account> accounts, ref string usernameInput, ref string passwordInput)
        {
            bool matchingInputUsername;
            bool matchingInputPassword;
            int activeUser = 0;

            do
            {
                matchingInputUsername = false;
                matchingInputPassword = false;

                for (int i = 0; i < accounts.Count(); i++)
                {
                    if (accounts[i].Username == usernameInput)
                    {
                        matchingInputUsername = true;
                        if (accounts[i].Password == passwordInput)
                        {
                            matchingInputPassword = true;
                            activeUser = i;
                        }
                        break;
                    }
                }

                if (matchingInputUsername == false)
                {
                    authenticationView.InvalidInputUsername(out usernameInput, out passwordInput);
                }
                else if (matchingInputPassword == false)
                {
                    authenticationView.InvalidInputPassword(out usernameInput, out passwordInput);
                }
            }
            while (!matchingInputUsername || !matchingInputPassword);

            return activeUser;
        }
    }
}
