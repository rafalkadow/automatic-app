namespace Shared.Models
{
    public static class ValuesModel
    {
        public static string BaseUrl { get; set; } = "";

        public static bool TestModule { get; set; } = false;
        public static bool MultiLanguage { get; set; } = false;

        public static string ContentRootPath { get; set; } = "";

        public static string LanguageCodeDefault { get; set; } = "";
        public static string LanguageNameDefault { get; set; } = "";
        public static Guid LanguageIdDefault { get; set; }
    }
}