namespace FriendsAdventure.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public User()
        {
            this.IsSuspended = false;
            this.Comments = new List<Comment>();
        }

        public bool? IsSuspended { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
