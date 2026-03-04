using ShopSystem.Model;
using ShopSystem.View;

namespace ShopSystem.Control
{
    internal class AuthenticationControl
    {
        public void InitializeAuthentication()
        {
            const int validInput = 0;
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
                    wrongInput = validInput;
                }

                if (wrongInput != 0)
                {
                    authenticationView.InitializeView(wrongInput, out usernameInput, out passwordInput);
                }
            }
            while (wrongInput != 0);
        }
    }
}
