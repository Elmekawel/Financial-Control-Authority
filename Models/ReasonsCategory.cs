using System.ComponentModel.DataAnnotations;

namespace MICLifePortal.Models
{
    public class ReasonsCategory
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        [MaxLength(1)]
        public char SmallName { get; set; }
    }
}
