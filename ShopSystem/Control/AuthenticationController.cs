using ShopSystem.Model;
using ShopSystem.View;

namespace ShopSystem.Control
{
    internal class AuthenticationController : MasterController
    {
        private AuthenticationView _authenticationView;
        public AuthenticationController()
        {
            _authenticationView = new AuthenticationView(this);
            _authenticationView.Authenticate();
        }
        public void CheckInput(string username, string password)
        {
            foreach (Account account in this.Accounts())
            {
                if (account.Username == username && account.Password == password)
                {
                    this.Login(account);
                    return;
                }
            }
            _authenticationView.InvalidInput();


            //do
            //{
            //    matchingInputUsername = false;
            //    matchingInputPassword = false;

            //    for (int i = 0; i < accounts.Count(); i++)
            //    {
            //        if (accounts[i].Username == usernameInput)
            //        {
            //            matchingInputUsername = true;
            //            if (accounts[i].Password == passwordInput)
            //            {
            //                matchingInputPassword = true;
            //                activeUser = i;
            //            }
            //            break;
            //        }
            //    }

            //    if (matchingInputUsername == false)
            //    {
            //        authenticationView.InvalidInputUsername(out usernameInput, out passwordInput);
            //    }
            //    else if (matchingInputPassword == false)
            //    {
            //        authenticationView.InvalidInputPassword(out usernameInput, out passwordInput);
            //    }
            //}
            //while (!matchingInputUsername || !matchingInputPassword);

            //return activeUser;
        }
    }
}
