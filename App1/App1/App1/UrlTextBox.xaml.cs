using Xamarin.Forms;

namespace App1
{
    public partial class UrlTextBox
    {
        public static readonly BindableProperty UrlTextProperty;

        public string UrlText
        {
            get => GetValue(UrlTextProperty).ToString();
            set => SetValue(UrlTextProperty, value);
        }

        static UrlTextBox()
        {
            UrlTextProperty = BindableProperty.Create(nameof(UrlText), typeof(string), typeof(UrlTextBox), "http://google.com.ua?id=123&text=test", BindingMode.TwoWay);
        }

        public UrlTextBox()
        {
            InitializeComponent();
            UrlEntry.Text = UrlText;
            UrlEntry.TextChanged += OnEntryChanged;
        }

        private void OnEntryChanged(object sender, TextChangedEventArgs e)
        {
            if (UrlText != e.NewTextValue)
                UrlText = e.NewTextValue;
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == UrlTextProperty.PropertyName && UrlText != UrlEntry.Text)
                UrlEntry.Text = UrlText;
        }
    }
}