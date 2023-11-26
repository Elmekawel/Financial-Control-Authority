using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MICLifePortal.Models
{
    public class Contact
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal? NationalID { get; set; }

        [ForeignKey("ContractorType")]
        public int? ContactType { get; set; }

        public ContractorType ContractorType { get; set; }
    }
}
