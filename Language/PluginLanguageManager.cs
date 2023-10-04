using SuchByte.MacroDeck.Language;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace SuchByte.WindowsUtils.Language;

public static class PluginLanguageManager
{
    public static PluginStrings PluginStrings = new PluginStrings();

    public static void Initialize()
    {
        LoadLanguage();
        LanguageManager.LanguageChanged += (s, e) => LoadLanguage();
    }

    private static void LoadLanguage()
    {
        // Getting the current language that is set in Macro Deck
        string languageName = LanguageManager.GetLanguageName();

        try
        {
            using TextReader reader = new StringReader(GetXMLLanguageResource(languageName));
            PluginStrings = (PluginStrings)new XmlSerializer(typeof(PluginStrings)).Deserialize(reader);
        }
        catch
        {
            //fallback - should never occur if things are done properly
            PluginStrings = new PluginStrings();
        }
    }

    private static string GetXMLLanguageResource(string languageName)
    {
        var assembly = typeof(PluginStrings).Assembly;
        if (string.IsNullOrEmpty(languageName)
            || !assembly.GetManifestResourceNames().Any(name => name.EndsWith($"{languageName}.xml")))
        {
            languageName = "English"; //This should always be present as default, otherwise the code goes to fallback implementation.
        }

        string languageFileName = $"SuchByte.WindowsUtils.Resources.Languages.{languageName}.xml";

        using var resourceStream = assembly.GetManifestResourceStream(languageFileName);
        using var streamReader = new StreamReader(resourceStream);
        return streamReader.ReadToEnd();
    }
}
