using System.Globalization;

public static class LanguageManager
{
    public static void ChangeLanguage(string cultureCode)
    {
        CultureInfo newCulture = new CultureInfo(cultureCode);

        Thread.CurrentThread.CurrentCulture = newCulture;
        Thread.CurrentThread.CurrentUICulture = newCulture;
    }
}