using Newtonsoft.Json.Converters;

namespace EDeanery.Host.Converters
{
    public class CustomDateConverter : IsoDateTimeConverter
    {
        public CustomDateConverter()
        {
            DateTimeFormat = "dd-mm-yyyy";
        }
    }
}