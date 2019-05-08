using System;
using Prism.DryIoc;
using Prism.Ioc;
using ShinyPrismApp.Views;
using Shiny.Locations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ShinyPrismApp.ViewModels;

namespace ShinyPrismApp
{
    public partial class App
    {
        protected override IContainerExtension CreateContainerExtension() => PrismContainerExtension.Current;

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }
    }
}
