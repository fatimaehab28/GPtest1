using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tbackendgp.Models;



namespace tbackendgp.Models
{
    public class IdentityCard
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }
        public string Code { get; set; }
        public int Gender { get; set; }
        public User User { get; set; }
    }

}
