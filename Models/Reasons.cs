using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MICLifePortal.Models
{
    public class Reasons
    {
        [Key]
        public int ReasonsID { get; set; }
        public int ReasonsCategoryID { get; set; }
        public string Name { get; set; }

        [ForeignKey("ReasonsCategoryID")]
        public ReasonsCategory ReasonsCategory { get; set; }
    }
}
