using System;
using ThirdPersonDemoIMGsDomain.Enums;

namespace ThirdPersonDemoIMGsDomain.Entities
{
    public class Image : Entity
    {
        public byte[] ImgBytes { get; set; }
        public string ImgName { get; set; }
        public DateTime CreationDate { get; set; }
        public ImgCategory Category { get; set;}
        public string GameStudioName { get; set; }
    }
}
