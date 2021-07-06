namespace FriendsAdventure.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string AuthorName { get; set; }

        [Required]
        [MaxLength(250)]
        [MinLength(3)]
        public string Content { get; set; }


        public int ThemeId { get; set; }

        public Theme Theme { get; set; }


        public string UserId { get; set; }

        public User User { get; set; }
    }
}
