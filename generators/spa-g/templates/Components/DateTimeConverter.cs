
using Newtonsoft.Json.Converters;

namespace <%= fullNamespace %>.Components
{
    public class DateTimeConverter : IsoDateTimeConverter
    {
        public DateTimeConverter()
        {
            base.DateTimeFormat = "dd/MM/yyyy hh:mm tt";
        }
    }
}
