using ShopSystem.Model;
using ShopSystem.View;

namespace ShopSystem.Control
{
    internal class AuthenticationController : MasterController
    {
        public void InitializeAuthentication()
        {
            const int VALID_INPUT = 0;
            const int wrongUserName = 1;
            const int wrongPassword = 2;

            AuthenticationView authenticationView = new AuthenticationView();
            Account account = new Account("TestUsername", "TestPassword");

            int wrongInput;
            string usernameInput;
            string passwordInput;

            authenticationView.InitializeView(out usernameInput, out passwordInput);

            do
            {
                if (usernameInput != account.Username)
                {
                    wrongInput = wrongUserName;
                }
                else if (passwordInput != account.Password)
                {
                    wrongInput = wrongPassword;
                }
                else
                {
                    wrongInput = VALID_INPUT;
                }

                if (wrongInput != 0)
                {
                    authenticationView.InvalidInput(wrongInput, out usernameInput, out passwordInput);
                }
            }
            while (wrongInput != 0);
        }
    }
}
