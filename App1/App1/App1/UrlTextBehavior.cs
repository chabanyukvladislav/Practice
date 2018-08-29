using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace App1
{
    class UrlTextBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += TextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= TextChanged;
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry = (Entry) sender;
            entry.TextColor = Regex.IsMatch(e.NewTextValue, UrlRegularExprecion.Exprecion) ? Color.Green : Color.Red;
        }
    }
}
