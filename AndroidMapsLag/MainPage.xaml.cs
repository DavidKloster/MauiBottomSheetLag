using DevExpress.Maui.Controls;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace AndroidMapsLag
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            var targetlocation = new Location(20.776676329883447, -156.37643484609933);
            mapctrl.MoveToRegion(MapSpan.FromCenterAndRadius(targetlocation, Distance.FromKilometers(5)));

            var pin = new Pin
            {
                Label = "Test",
                Location = targetlocation
            };
            pin.MarkerClicked += (sender, e) =>
            {


                IosMap_MapClickedAsync(sender!, new MapClickedEventArgs(pin.Location));
                e.HideInfoWindow = true;
            };
            mapctrl.Pins.Add(pin);

            Circle circle = new Circle
            {
                Center = targetlocation,
                Radius = new Microsoft.Maui.Maps.Distance(150),
                StrokeColor = Color.FromArgb("#88FF0000"),
                StrokeWidth = 8,
                FillColor = Color.FromArgb("#88FFC0CB")
            };
            mapctrl.MapElements.Add(circle);
        }


        private async void IosMap_MapClickedAsync(object sender, MapClickedEventArgs e)
        {
              bottomSheet.State = BottomSheetState.HalfExpanded;
            Pin p = mapctrl.Pins.Where(x => x.Location == new Location(e.Location.Latitude, e.Location.Longitude)).FirstOrDefault();
            mapctrl.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(e.Location.Latitude, e.Location.Longitude), Microsoft.Maui.Maps.Distance.FromMeters(50 * 2)));
            return;


        }

    }
}
