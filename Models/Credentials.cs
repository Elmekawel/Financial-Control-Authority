using System.ComponentModel.DataAnnotations;

namespace MICLifePortal.Models
{
    public class Credentials
    {
        [Key]
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
