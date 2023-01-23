using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JewelleryShop.Models
{
    public class Item
    {
        public Item()
        {
            Images = new List<Image>();
            Prices = new List<Price>();
        }
        [Key]
        public int ID { get; set; }
        [Required, Display(Name = "שם פריט")]
        public string Name { get; set; }
        [Display(Name = "תאור")]
        public string Description { get; set; }
        [Display(Name = "תמונה")]
        public List<Image> Images { get; set; }
        public List<Price> Prices { get; set; }

        //function for adding a image
        public void AddImage(IFormFile file)
        {
            if (file == null) return;
            Images.Add(new Image { Item=this, SetImage=file });
        }

        //function for adding a price
        public Price AddPrice(decimal myPrice)
        {
            return AddPrice(new Price { MyPrice = myPrice });
        }
        public Price AddPrice(decimal myPrice, DateTime End)
        {
            return AddPrice(new Price { MyPrice = myPrice, End = End });
        }
        public Price AddPrice(decimal myPrice, DateTime Start, DateTime End)
        {
            return AddPrice(new Price { MyPrice= myPrice, Start = Start, End = End });
        }
        public Price AddPrice(Price price)
        {
            Prices.Add(price);
            return price;
        }
    }
}