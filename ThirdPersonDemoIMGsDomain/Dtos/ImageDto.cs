using System;
using Newtonsoft.Json;
using ThirdPersonDemoIMGsDomain.JsonConverters;

namespace ThirdPersonDemoIMGsDomain.Dtos
{
    public class ImageDto
    {
        public string ImgBase64 { get; set; }
        public string ImgName { get; set; }
        [JsonConverter(typeof(JsonDateConverter),"dd-MM-yyyy")]
        public DateTime? CreationDate { get; set; }

    }
}
