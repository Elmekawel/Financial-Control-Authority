using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MICLifePortal.Models
{
    public class RejectionBeneficiary
    {
        [Key]
        public int ID { get; set; }
        public int? RejectedEntityID { get; set; }
        public int? BeneficiaryID { get; set; }
        public double? BeneficiaryPrec { get; set; }

        [ForeignKey("RejectedEntityID")]
        public RejectedEntity RejectedEntity { get; set; }

        [ForeignKey("BeneficiaryID")]
        public Contact Beneficiary { get; set; }
    }
}
