using System;
using System.Linq;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;
using Xamarin.Auth;

namespace EscapeRankUI.Servicios
{
    public class CredencialesService : ICredencialesService
    {
        public int IdUsuario
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(Constants.AppName).FirstOrDefault();
                if (account?.Username != "")
                    return Convert.ToInt32(account?.Username);
                else
                    return 0;
            }
        }

        public string Nombre
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(Constants.AppName).FirstOrDefault();
                return (account != null) ? account.Properties["UserName"] : null;
            }
        }

        public string Contrasenya
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(Constants.AppName).FirstOrDefault();
                return (account != null) ? account.Properties["Password"] : null;
            }
        }

        public string TokenAcceso 
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(Constants.AppName).FirstOrDefault();
                if (account != null)
                {
                    return string.IsNullOrEmpty(account.Properties["TokenAcceso"]) ? null : account.Properties["TokenAcceso"];
                }
                return null;
            }
        }

        public string TokenRefresco
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(Constants.AppName).FirstOrDefault();
                if (account != null)
                {
                    return string.IsNullOrEmpty(account.Properties["refreshToken"]) ? null : account.Properties["refreshToken"];
                }
                return null;
            }
        }

       

        public async Task SaveCredentials(int idUsuario, string userName, string password, Login token)
        {
            if (!string.IsNullOrWhiteSpace(idUsuario.ToString()))
            {
                Account account = new Account
                {
                    Username = idUsuario.ToString()
                };
                if (!String.IsNullOrWhiteSpace(token.TokenAcceso)){
                    account.Properties.Add("TokenAcceso", token.TokenAcceso);
                }
                if (!String.IsNullOrWhiteSpace(token.TokenRefresco))
                {
                    account.Properties.Add("refreshToken", token.TokenRefresco);
                }
               
                    account.Properties.Add("idUsuario", idUsuario.ToString());
            
                if (!String.IsNullOrWhiteSpace(userName))
                {
                    account.Properties.Add("UserName", token.TokenAcceso);
                }
                account.Properties.Add("Password", password);
                await AccountStore.Create().SaveAsync(account, Constants.AppName);
            }
        }

        public async Task SaveToken(Login token)
        {
            var account = AccountStore.Create().FindAccountsForService(Constants.AppName).FirstOrDefault();

                if (!String.IsNullOrWhiteSpace(token.TokenAcceso))
                {
                    account.Properties["TokenAcceso"] = token.TokenAcceso;

                }
                if (!String.IsNullOrWhiteSpace(token.TokenRefresco))
                {
                account.Properties["refreshToken"] = token.TokenRefresco;
                }
                await AccountStore.Create().SaveAsync(account, Constants.AppName);

        }

        public async Task DeleteCredentials()
        {
            var account = AccountStore.Create().FindAccountsForService(Constants.AppName).FirstOrDefault();
            if (account != null)
            {
                await AccountStore.Create().DeleteAsync(account, Constants.AppName);
            }
        }

        public bool DoCredentialsExist()
        {
            return AccountStore.Create().FindAccountsForService(Constants.AppName).Any() ? true : false;
        }

        public async Task SaveAccount(Account account)
        {
            await AccountStore.Create().SaveAsync(account, Constants.AppName);
        }
    }
}
