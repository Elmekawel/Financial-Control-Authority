using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MICLifePortal.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public List<User> Users { get; set; }
    }
}
