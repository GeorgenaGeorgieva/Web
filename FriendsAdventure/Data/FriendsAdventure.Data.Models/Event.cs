namespace FriendsAdventure.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Event
    {
        public Event()
        {
            this.Images = new HashSet<Image>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Date { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Descripton { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
