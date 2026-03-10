using ShopSystem.Model;
using ShopSystem.View;

namespace ShopSystem.Control
{
    internal class AuthenticationController : MasterController
    {
        private AuthenticationView _authenticationView;

        //beim erstellen des authentifizierungs-controllers wird zusätzlich ein
            //authentifizierungs-view instanziiert und der controller übergibt sich
            //selbst als parameter
        public AuthenticationController()
        {
            _authenticationView = new AuthenticationView(this);
            _authenticationView.Authenticate();
        }

        //einfache überprüfung ob eingaben des benutzernamen und passwort mit
            //schon existierenden daten übereinstimmen.
        //falls ja wird Login ausgeführt
        //falls nein wird InvalidInput ausgeführt für erneute benutzereingabe
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
        }
    }
}
