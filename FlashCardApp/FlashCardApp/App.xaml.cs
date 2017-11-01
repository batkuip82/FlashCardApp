using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FlashCardApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
            //InitializeComponent();

            //MainPage = new NavigationPage(new FlashCardApp.FlashCardPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void OnInitialized()
        {
            throw new NotImplementedException();
        }

        protected override void RegisterTypes()
        {
            throw new NotImplementedException();
        }
    }
}
