using System.Collections.Generic;
using System.Windows;

namespace WpfApp1
{
    public partial class UrlInfoBox
    {
        public static readonly DependencyProperty ElementProperty;
        public static readonly DependencyProperty LeftMarginProperty;
        public static readonly DependencyProperty TopMarginProperty;

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
            ElementProperty = DependencyProperty.Register(nameof(Element), typeof(UrlInfo), typeof(UrlInfoBox), new PropertyMetadata(new UrlInfo() { Arguments = new Dictionary<string, string>() }));
            LeftMarginProperty = DependencyProperty.Register(nameof(LeftMargin), typeof(double), typeof(UrlInfoBox), new PropertyMetadata(0.0));
            TopMarginProperty = DependencyProperty.Register(nameof(TopMargin), typeof(double), typeof(UrlInfoBox), new PropertyMetadata(0.0));
        }

        public UrlInfoBox()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property == ElementProperty)
                DataContext = Element;
            else if (e.Property == LeftMarginProperty)
            {
                Thickness margin = UrlStackPanel.Margin;
                margin.Left = LeftMargin;
                UrlStackPanel.Margin = margin;
            }
            else if (e.Property == TopMarginProperty)
            {
                Thickness margin = UrlStackPanel.Margin;
                margin.Top = TopMargin;
                UrlStackPanel.Margin = margin;
            }
        }
    }
}