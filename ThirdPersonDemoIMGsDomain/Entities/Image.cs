using System;
namespace ThirdPersonDemoIMGsDomain.Entities
{
    public class Image : Entity
    {
        public byte[] ImgBytes { get; set; }
        public string ImgName { get; set; }
        public DateTime CreationDate { get; set; }
        
    }
}
