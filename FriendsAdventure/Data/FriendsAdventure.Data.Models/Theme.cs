namespace FriendsAdventure.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Theme
    {
        public Theme()
        {
            this.Comments = new List<Comment>();
        }

        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        public string PictirePath { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
