using Xamarin.Forms;

namespace App1
{
	public partial class UrlTextBox: Entry
	{
	    public new static readonly BindableProperty TextProperty;

	    public new string Text
	    {
	        get => GetValue(TextProperty).ToString();
	        set => SetValue(TextProperty, value);
	    }

	    static UrlTextBox()
	    {
	        TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(UrlTextBox), "http://google.com.ua", BindingMode.TwoWay);
        }

	    public UrlTextBox ()
		{
		    InitializeComponent();
		    UrlEntry.Text = Text;
            UrlEntry.TextChanged += OnEntryChanged;
		}

	    private void OnEntryChanged(object sender, TextChangedEventArgs e)
	    {
	        Text = e.NewTextValue;
	    }

	    protected override void OnPropertyChanged(string propertyName = null)
	    {
	        if (propertyName == TextProperty.PropertyName)
	            UrlEntry.Text = Text;
	    }
	}
}