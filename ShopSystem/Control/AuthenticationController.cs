using ShopSystem.Model;
using ShopSystem.View;

namespace ShopSystem.Control
{
    internal class AuthenticationController : MasterController
    {
        public void InitializeAuthentication()
        {
            AuthenticationView authenticationView = new AuthenticationView();
            MasterController masterController = new MasterController();

            string usernameInput;
            string passwordInput;

            authenticationView.InitializeView(out usernameInput, out passwordInput);
            CheckInput(authenticationView, masterController.Accounts(), ref usernameInput, ref passwordInput);
        }

        private void CheckInput(AuthenticationView authenticationView, List<Account> accounts, ref string usernameInput, ref string passwordInput)
        {
            bool matchingInputUsername;
            bool matchingInputPassword;

            do
            {
                matchingInputUsername = false;
                matchingInputPassword = false;

                foreach (Account account in accounts)
                {
                    if (account.Username == usernameInput)
                    {
                        matchingInputUsername = true;
                        if (account.Password == passwordInput)
                        {
                            matchingInputPassword = true;
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
        }
    }
}
