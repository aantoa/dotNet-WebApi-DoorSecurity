using System.ComponentModel.DataAnnotations;

namespace DoorsSecurity.Models
{
    public class Door{
        [Key]
        public int Id { get; set; }
        public int Number{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<Card> Cards { get; set; } = new List<Card>();
    }
}