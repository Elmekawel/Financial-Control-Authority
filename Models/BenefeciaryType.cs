using System.ComponentModel.DataAnnotations;

namespace MICLifePortal.Models
{
    public class BenefeciaryType
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        [MaxLength(1)]
        public string Symbol { get; set; }
    }
}
