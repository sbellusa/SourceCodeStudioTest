namespace SourceCodeStudioTest.Controls;

public partial class LocationControl : ContentView
{
    public LocationControl()
    {
        InitializeComponent();
    }


    public static readonly BindableProperty LocationProperty =
        BindableProperty.Create(nameof(Location), typeof(Location), typeof(LocationControl), null, propertyChanged: OnLocationChanged);

    public Location Location
    {
        get => (Location)GetValue(LocationProperty);
        set => SetValue(LocationProperty, value);
    }

    public static readonly BindableProperty ComparedLocationProperty =
    BindableProperty.Create(nameof(ComparedLocation), typeof(Location), typeof(LocationControl), null, propertyChanged: OnLocationChanged);
    public Location ComparedLocation
    {
        get => (Location)GetValue(ComparedLocationProperty);
        set => SetValue(ComparedLocationProperty, value);
    }

    private static void OnLocationChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is LocationControl control)
        {
            var location = control.Location;
            var comparedLocation = control.ComparedLocation;

            if (location == null || comparedLocation == null) return;

            var distance = location.CalculateDistance(comparedLocation, DistanceUnits.Miles);

            control.DistanceSpan.Text = distance.ToString("0");
        }
    }
}