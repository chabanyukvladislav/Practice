namespace WpfApp1
{
    static class UrlRegularExprecion
    {
        public static string Exprecion => @"https?:\/\/(\w+)(\.\w+)+(\/\w+)*(\.\w+)?(\?\w+=\w+(&\w+=\w+)*)?$";
    }
}
