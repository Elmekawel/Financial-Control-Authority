using System.ComponentModel.DataAnnotations;

namespace MICLifePortal.Models
{
    public class ReasonsType
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        [MaxLength(2)]
        public char SName { get; set; }
    }
}
