using System;

using Xamarin.Forms;

namespace mySupperClub
{
	public class App : Application
	{
        private static SupperClubService azService;

        public App ()
		{
            // The root page of your application

            //do this when you have authentication in place
            //MainPage = new ContentPage();
            //for now, just load main page
            MainPage = new NavigationPage(
                new GroupList());
        }

        public void LoadMainPage()
        {
            MainPage = new NavigationPage(
                new GroupList());
        }
        public static SupperClubService GetSupperClubService()
        {
            if (azService == null)
            {
                azService = new SupperClubService("https://mysupperclub.azurewebsites.net");
            }
            return azService;
        }
    }
}

