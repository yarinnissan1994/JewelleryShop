using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace JewelleryShop.Models
{
    public class Category
    {
        public Category()
        { 
            SubCategories = new List<Category>();
            Items = new List<Item>();
        }
        [Key]
        public int ID { get; set; }
        [Required, Display(Name = "שם קבוצה")]
        public string Name { get; set; }
        [Display(Name = "תאור")]
        public string Description { get; set; }
        [Display(Name = "תמונה")]
        public byte[] Image { get; set; }
        public Category Parent { get; set; }
        public List<Category> SubCategories { get; set; }
        public List<Item> Items { get; set; }

        //function for adding SubCategory
        public Category AddSubCategory(string name)
        {
            Category category = new Category { Name = name, Parent = this };
            return AddSubCategory(category);
        }
        public Category AddSubCategory(string name, string description)
        {
            Category category = new Category { Name = name, Description = description, Parent = this };
            return AddSubCategory(category);
        }
        public Category AddSubCategory(string name, string description, IFormFile file)
        {
            Category category = new Category { Name = name, Description = description, SetImage = file, Parent = this };
            return AddSubCategory(category);
        }
        public Category AddSubCategory(Category subCategory)
        {
            SubCategories.Add(subCategory);
            return subCategory;
        }

        //function for adding Item
        public Item AddItem(string Name, string Description, decimal myPrice)
        {
            Item item = new Item();
            item.AddPrice(myPrice);
            return AddItem(new Item { Name = Name, Description = Description });
        }
        public Item AddItem(string Name, string Description, decimal myPrice, DateTime End)
        {
            Item item = new Item();
            item.AddPrice(myPrice, End);
            return AddItem(new Item { Name = Name, Description = Description });
        }
        public Item AddItem(string Name, string Description, decimal myPrice, DateTime Start, DateTime End)
        {
            Item item = new Item();
            item.AddPrice(myPrice, Start, End);
            return AddItem(new Item { Name = Name, Description = Description });
        }
        public Item AddItem(string Name, string Description, List<IFormFile> files, decimal myPrice)
        {
            Item item = new Item();
            foreach (IFormFile file in files)
            {
                item.AddImage(file);
            }
            item.AddPrice(myPrice);
            return AddItem(new Item { Name = Name, Description = Description });
        }
        public Item AddItem(string Name, string Description, List<IFormFile> files, decimal myPrice, DateTime End)
        {
            Item item = new Item();
            foreach (IFormFile file in files)
            {
                item.AddImage(file);
            }
            item.AddPrice(myPrice, End);
            return AddItem(new Item { Name = Name, Description = Description });
        }
        public Item AddItem(string Name, string Description, List<IFormFile> files, decimal myPrice, DateTime Start, DateTime End)
        {
            Item item = new Item();
            foreach (IFormFile file in files)
            {
                item.AddImage(file);
            }
            item.AddPrice(myPrice, Start, End);
            return AddItem(new Item { Name = Name, Description = Description });
        }
        public Item AddItem(Item item)
        {
            Items.Add(item);
            return item;
        }

        //function for adding Image
        public IFormFile SetImage
        {
            set
            {
                if (value == null) return;
                MemoryStream stream = new MemoryStream();
                value.CopyTo(stream);
                Image = stream.ToArray();
            }
        }
    }
}
