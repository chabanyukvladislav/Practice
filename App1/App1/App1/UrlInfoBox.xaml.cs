using System.Collections.Generic;
using Xamarin.Forms;

namespace App1
{
    public partial class UrlInfoBox
    {
        public static readonly BindableProperty ElementProperty;
        public static readonly BindableProperty LeftMarginProperty;
        public static readonly BindableProperty TopMarginProperty;

        public UrlInfo Element
        {
            get => GetValue(ElementProperty) as UrlInfo;
            set => SetValue(ElementProperty, value);
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

        static UrlInfoBox()
        {
            ElementProperty = BindableProperty.Create(nameof(Element), typeof(UrlInfo), typeof(UrlInfoBox), new UrlInfo() { Arguments = new Dictionary<string, string>() });
            LeftMarginProperty = BindableProperty.Create(nameof(LeftMargin), typeof(double), typeof(UrlInfoBox),0.0);
            TopMarginProperty = BindableProperty.Create(nameof(TopMargin), typeof(double), typeof(UrlInfoBox), 0.0);
        }

        public UrlInfoBox()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == ElementProperty.PropertyName)
                BindingContext = Element;
            else if (propertyName == LeftMarginProperty.PropertyName)
            {
                Thickness margin = UrlStackPanel.Margin;
                margin.Left = LeftMargin;
                UrlStackPanel.Margin = margin;
            }
            else if (propertyName == TopMarginProperty.PropertyName)
            {
                Thickness margin = UrlStackPanel.Margin;
                margin.Top = TopMargin;
                UrlStackPanel.Margin = margin;
            }
        }
    }
}