using System;
using Newtonsoft.Json.Converters;

namespace ThirdPersonDemoIMGsDomain.JsonConverters
{
    public class JsonDateConverter : IsoDateTimeConverter
    {
        public JsonDateConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}
