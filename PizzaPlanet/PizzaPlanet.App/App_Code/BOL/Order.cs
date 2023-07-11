using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaPlanet.App.App_Code.BOL
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DatePlaced { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
