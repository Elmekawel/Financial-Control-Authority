using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MICLifePortal.Models
{
    public class TokenResponse
    {
        [Key]
        public int Id { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }
    }
}
