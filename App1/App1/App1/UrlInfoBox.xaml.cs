using System.Collections.Generic;
using Xamarin.Forms;

namespace App1
{
    public partial class UrlInfoBox
    {
        public static readonly BindableProperty ElementProperty;

        public UrlInfo Element
        {
            get => GetValue(ElementProperty) as UrlInfo;
            set => SetValue(ElementProperty, value);
        }

        static UrlInfoBox()
        {
            ElementProperty = BindableProperty.Create(nameof(Element), typeof(UrlInfo), typeof(UrlInfoBox), new UrlInfo() { Arguments = new Dictionary<string, string>() });
        }

        public UrlInfoBox()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            if (propertyName == ElementProperty.PropertyName)
                BindingContext = Element;
        }
    }
}