namespace FriendsAdventure.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Path { get; set; }


        public int EventId { get; set; }

        public Event Event { get; set; }
    }
}
