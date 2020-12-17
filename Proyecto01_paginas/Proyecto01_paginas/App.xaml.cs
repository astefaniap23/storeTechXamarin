using Plugin.SharedTransitions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto01_paginas
{
     
    public partial class App : Application
    {
        //---------------
        
        //Constructor
        public App()
        {
            InitializeComponent();

            CarouselPage carouselPage = new CarouselPage();
            carouselPage.Children.Add(new MainPage());
            carouselPage.Children.Add(new Pagina1());
            carouselPage.Children.Add(new Pagina2());
            carouselPage.Children.Add(new Pagina3());
            carouselPage.Children.Add(new Pagina4());
            carouselPage.Children.Add(new Pagina51());
            carouselPage.Children.Add(new Pagina6());
            carouselPage.Children.Add(new Pagina7());
            MainPage = new NavigationPage(carouselPage);

            //MainPage = new SharedTransitionNavigationPage(new MainPage());

            //MainPage = new MainPage();
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
