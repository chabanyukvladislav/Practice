using Xamarin.Forms;

namespace App1
{
    public partial class UrlTextBox
    {
        public static readonly BindableProperty UrlTextProperty;
        public static readonly BindableProperty LeftMarginProperty;
        public static readonly BindableProperty TopMarginProperty;

        public string UrlText
        {
            get => GetValue(UrlTextProperty).ToString();
            set => SetValue(UrlTextProperty, value);
        }
        public double LeftMargin
        {
            get => (double)GetValue(LeftMarginProperty);
            set => SetValue(LeftMarginProperty, value);
        }
        public double TopMargin
        {
            get => (double)GetValue(TopMarginProperty);
            set => SetValue(TopMarginProperty, value);
        }

        static UrlTextBox()
        {
            UrlTextProperty = BindableProperty.Create(nameof(UrlText), typeof(string), typeof(UrlTextBox), "http://google.com.ua?id=123&text=test", BindingMode.TwoWay);
            LeftMarginProperty = BindableProperty.Create(nameof(LeftMargin), typeof(double), typeof(UrlTextBox), 0.0);
            TopMarginProperty = BindableProperty.Create(nameof(TopMargin), typeof(double), typeof(UrlTextBox), 0.0);
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
            else if (propertyName == LeftMarginProperty.PropertyName)
            {
                Thickness margin = UrlEntry.Margin;
                margin.Left = LeftMargin;
                UrlEntry.Margin = margin;
            }
            else if (propertyName == TopMarginProperty.PropertyName)
            {
                Thickness margin = UrlEntry.Margin;
                margin.Top = TopMargin;
                UrlEntry.Margin = margin;
            }
        }
    }
}