using System.ComponentModel.DataAnnotations;

namespace DoorsSecurity.Models
{
    public class Card{
        [Key]
        public int Id { get; set; }
        public int Number{ get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public virtual ICollection<Door> Doors { get; set; } = new List<Door>();
    }
}        