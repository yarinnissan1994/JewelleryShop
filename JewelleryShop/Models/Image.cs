using System.ComponentModel.DataAnnotations;

namespace JewelleryShop.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public Item Item { get; set; }
        public byte[] MyImage { get; set; }

        //function for adding image
        public IFormFile SetImage
        {
            set
            {
                if (value == null) return;
                MemoryStream stream = new MemoryStream();
                value.CopyTo(stream);
                MyImage = stream.ToArray();
            }
        }
    }
}