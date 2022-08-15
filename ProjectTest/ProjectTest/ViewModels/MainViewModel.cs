using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using ProjectTest.Model;
using ProjectTest.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Windows.Input;
using FreshMvvm;
using NETCore.Encrypt;

namespace ProjectTest.ViewModels
{
    public class MainViewModel : FreshBasePageModel
    {
        private string username;
        private string password;
        private bool isLoading;
        private string btnSignIn;

        public MainViewModel()
        {
        }


        public ICommand SignIn => new Command(async () =>
        {
            await Login(Username.ToLower(), Password);

        }, () => !String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password));

        public ICommand SignUp => new Command(async () =>
        {
            await CoreMethods.PushPageModel<SignUpViewModel>();
        });

        private async Task Login(string username, string password)
        {
            try
            {
                BtnSignIn = "Loading...";

                var passwordHashed = EncryptProvider.Md5(password);
                UserModel result = await new ApiClient().Login(username, passwordHashed);
                if (result != null && result.id != 0)
                {
                    await CoreMethods.PushPageModel<ProductListViewModel>();
                    CoreMethods.RemoveFromNavigation();

                }
                else
                    await CoreMethods.DisplayAlert("Acesso", "username or passwor wrong", "Ok");

            }
            catch (Exception ex)
            {
                await CoreMethods.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally
            {

                BtnSignIn = "LOG IN";
            }
        }

        public string BtnSignIn
        {
            get
            {
                return btnSignIn;
            }

            set
            {
                btnSignIn = value;
                RaisePropertyChanged("SignIn");
            }
        }


        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
                RaisePropertyChanged("SignIn");
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
                RaisePropertyChanged("SignIn");
            }
        }




        public bool IsLoading
        {
            get
            {
                return isLoading;
            }

            set
            {
                isLoading = value;
            }
        }
    }
}
