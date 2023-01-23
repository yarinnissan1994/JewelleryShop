using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelleryShop.Models
{
    public class Price
    {
        public Price() 
        {
            Start = DateTime.Now;
            End = DateTime.Now.AddYears(1);
        }
        [Key]
        public int Id { get; set; }
        public Item Item { get; set; }
        [Display(Name = "תאריך ושעת התחלה")]
        public DateTime Start { get; set; }
        [Display(Name = "תאריך התחלה")]
        [DataType(DataType.Date)]
        [NotMapped]
        public DateTime StartDate 
        { 
            get { return Start; } 
            set { Start = new DateTime(value.Year, value.Month, value.Day, Start.Hour, Start.Minute, 0); } 
        }
        [Display(Name = "שעת התחלה")]
        [DataType(DataType.Time)]
        [NotMapped]
        public TimeOnly StartTime 
        {
            get { return new TimeOnly (Start.Hour, Start.Minute); } 
            set { Start = new DateTime(Start.Year, Start.Month, Start.Day, value.Hour, value.Minute, 0); } 
        }
        public DateTime End { get; set; }
        public decimal MyPrice { get; set; }
    }
}