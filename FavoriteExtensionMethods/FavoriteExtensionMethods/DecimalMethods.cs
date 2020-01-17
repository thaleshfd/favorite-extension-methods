namespace FavoriteExtensionMethods
{
    public static class DecimalMethods
    {
        public static string Currency(this decimal s, bool showSymbol = true)
        {
            return showSymbol ? s.ToString("C") : string.Format("{0:N2}", s);
        }
    }
}
