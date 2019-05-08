using Prism.Events;
using Shiny.Locations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShinyPrismApp.Services
{
    public class GpsDelegate : IGpsDelegate
    {
        private IEventAggregator _ea;

        public GpsDelegate(IEventAggregator ea) => _ea = ea;

        public void OnReading(IGpsReading reading)
        {
            _ea.GetEvent<GpsReadingEvent>().Publish(reading);
        }
    }

    public class GpsReadingEvent : PubSubEvent<IGpsReading> { }
}
