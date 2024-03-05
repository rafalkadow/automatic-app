namespace Shared.Validation
{
    public class ValidationElement
    {
        public string field { get; set; }
        public string label { get; set; }

        public string rules { get; set; }

        public Dictionary<string, string> errors { get; set; }
    }
}