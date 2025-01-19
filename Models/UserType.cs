using System.ComponentModel.DataAnnotations;
using tbackendgp.Models;


namespace tbackendgp.Models
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }
        public string Role { get; set; }

        public ICollection<User> User { get; set; }
    }
}





