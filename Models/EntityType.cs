using System.ComponentModel.DataAnnotations;

namespace MICLifePortal.Models
{
    public class EntityType
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        [MaxLength(1)]
        public char SName { get; set; }
    }
}
