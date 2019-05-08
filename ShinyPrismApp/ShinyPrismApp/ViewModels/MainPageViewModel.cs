using Prism.AppModel;
using Prism.Events;
using Prism.Mvvm;
using Shiny.Locations;
using ShinyPrismApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShinyPrismApp.ViewModels
{
    class MainPageViewModel : BindableBase, IPageLifecycleAware
    {
        private IGpsManager _gpsManager { get; }
        public MainPageViewModel(IEventAggregator ea, IGpsManager gpsManager)
        {
            _gpsManager = gpsManager;
            ea.GetEvent<GpsReadingEvent>().Subscribe(OnGpsReading);
        }

        private IGpsReading _reading;
        public IGpsReading Reading
        {
            get => _reading;
            set => SetProperty(ref _reading, value);
        }

        private void OnGpsReading(IGpsReading reading)
        {
            Reading = reading;
        }

        public async void OnAppearing()
        {
            var accessState = await _gpsManager.RequestAccess(false);

            if (accessState != Shiny.AccessState.Available) return;

            if (_gpsManager.IsListening) await _gpsManager.StopListener();

            await _gpsManager.StartListener();
        }

        public void OnDisappearing()
        {

        }
    }
}
