using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace WpfApp1
{
    internal class UrlTextBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            AssociatedObject.TextChanged += TextChanged;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.TextChanged -= TextChanged;
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            textBox.Foreground = Regex.IsMatch(textBox.Text, UrlRegularExprecion.Exprecion) ? Brushes.Green : Brushes.Red;
        }
    }
}