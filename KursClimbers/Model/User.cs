using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursClimbers.Model
{
    public class User
    {
        [Key]
        [Column("ID_User")]
        public int IdUser { get; set; }

        [Required]
        [StringLength(50)]
        public string? Login { get; set; }

        [Required]
        [StringLength(50)]
        public string? Password { get; set; }
    }
}
