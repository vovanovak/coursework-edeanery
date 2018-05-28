using Newtonsoft.Json.Converters;

namespace EDeanery.PL.Converters
{
    public class CustomDateConverter : IsoDateTimeConverter
    {
        public CustomDateConverter()
        {
            DateTimeFormat = "dd-mm-yyyy";
        }
    }
}