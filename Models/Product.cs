using System.ComponentModel.DataAnnotations;

namespace MICLifePortal.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        public int ProductCodeInt { get; set; }

        public string ProductCodeExt { get; set; }

        public string ArName { get; set; }

        public string EnName { get; set; }

        public string SectorId { get; set; }
    }
}
