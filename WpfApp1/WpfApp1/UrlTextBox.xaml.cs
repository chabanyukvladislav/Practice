using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class UrlTextBox
    {
        public static readonly DependencyProperty UrlTextProperty;
        public static readonly DependencyProperty LeftMarginProperty;
        public static readonly DependencyProperty TopMarginProperty;

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
            UrlTextProperty = DependencyProperty.Register(nameof(UrlText), typeof(string), typeof(UrlTextBox), new PropertyMetadata("http://google.com.ua?id=123&text=test"));
            LeftMarginProperty = DependencyProperty.Register(nameof(LeftMargin), typeof(double), typeof(UrlTextBox), new PropertyMetadata(0.0));
            TopMarginProperty = DependencyProperty.Register(nameof(TopMargin), typeof(double), typeof(UrlTextBox), new PropertyMetadata(0.0));
        }

        public UrlTextBox()
        {
            InitializeComponent();
            UrlEntry.Text = UrlText;
            UrlEntry.TextChanged += OnEntryChanged;
        }

        private void OnEntryChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (UrlText != textBox.Text)
                UrlText = textBox.Text;
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property == UrlTextProperty && UrlText != UrlEntry.Text)
                UrlEntry.Text = UrlText;
            else if (e.Property == LeftMarginProperty)
            {
                Thickness margin = UrlEntry.Margin;
                margin.Left = LeftMargin;
                UrlEntry.Margin = margin;
            }
            else if (e.Property == TopMarginProperty)
            {
                Thickness margin = UrlEntry.Margin;
                margin.Top = TopMargin;
                UrlEntry.Margin = margin;
            }
        }
    }
}