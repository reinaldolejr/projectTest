using FreshMvvm;
using ProjectTest.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            var page = FreshPageModelResolver.ResolvePageModel<MainViewModel>();
            var basicNavContainer = new FreshNavigationContainer(page);
            MainPage = basicNavContainer;

        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
