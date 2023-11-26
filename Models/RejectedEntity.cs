using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MICLifePortal.Models
{
    public class RejectedEntity
    {
        [Key]
        public int ID { get; set; }
        public int? RefuseTID { get; set; }
        public int? RejectedEntityType { get; set; }
        public int? ContractorID { get; set; }
        public int? CustomerID { get; set; }
        public string CustomerCountry { get; set; }
        public int? DocumentNo { get; set; }
        public int? ProductCode { get; set; }
        public int? BeneficiaryType { get; set; }
        public int? BeneficiaryTID { get; set; }
        public int? RepaymentNo { get; set; }
        public double? PremiumValue { get; set; }
        public DateTime? RefuseDate { get; set; }
        public int? ReasonId { get; set; }
        public string OtherReasons { get; set; }

        [ForeignKey("BeneficiaryType")]
        public BenefeciaryType BenefeciaryType { get; set; }

        [ForeignKey("ContractorID")]
        public Contact Contractor { get; set; }

        [ForeignKey("CustomerID")]
        public Contact Customer { get; set; }

        [ForeignKey("BeneficiaryTID")]
        public Contact BeneficiaryTIDContact { get; set; }

        [ForeignKey("RejectedEntityType")]
        public EntityType EntityType { get; set; }

        [ForeignKey("ReasonId")]
        public Reasons Reasons { get; set; }

        [ForeignKey("RefuseTID")]
        public ReasonsType RefuseType { get; set; }
    }
}
