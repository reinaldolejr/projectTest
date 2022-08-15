using FreshMvvm;
using NETCore.Encrypt;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using ProjectTest.Common;
using ProjectTest.Model;
using ProjectTest.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjectTest.ViewModels
{
    public class SignUpViewModel : FreshBasePageModel
    {

        private string username;
        private string password;
        private string passwordConfirm;
        private bool isLoading;
        private string btnSignUp;

        public SignUpViewModel()
        {
        }

        public ICommand SignUpCommand => new Command(async () =>
        {
            await SignUp(Username.ToLower(), Password, passwordConfirm);

        }, () => !String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password) && !String.IsNullOrEmpty(PasswordConfirm));

        private async Task SignUp(string username, string password, string passwordConfirm)
        {
            try
            {
                BtnSignUp = "Loading...";

                if (password == passwordConfirm)
                {
                    var passwordHashed = EncryptProvider.Md5(password);

                    bool result = await new ApiClient().Signup(username, passwordHashed);
                    if (result)
                    {
                        await CoreMethods.PopPageModel();
                    }
                    else
                        await CoreMethods.DisplayAlert("SIGN UP", "something wrong", "Ok");
                }
                else
                {
                    await CoreMethods.DisplayAlert("SIGN UP", "Your Password and Confirm Password are different", "Ok");
                }

            }
            catch (Exception ex)
            {
                await CoreMethods.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally
            {

                BtnSignUp = "SIGN UP";
            }
        }

        public string BtnSignUp
        {
            get
            {
                return btnSignUp;
            }

            set
            {
                btnSignUp = value;
                RaisePropertyChanged("SignUpCommand");
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
                RaisePropertyChanged("SignUpCommand");
            }
        }

        public string PasswordConfirm
        {
            get
            {
                return passwordConfirm;
            }

            set
            {
                passwordConfirm = value;
                RaisePropertyChanged("SignUpCommand");
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
                RaisePropertyChanged("SignUpCommand");
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
