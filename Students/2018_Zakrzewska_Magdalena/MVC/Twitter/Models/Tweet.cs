using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Twitter.Models
{
    public class Tweet
    {
        public int TweetId { get; set; }
        public string Title { get; set; }

        [MinLength(5, ErrorMessage = "Comment content to short. Minimum length : {1}.")]
        public string Description { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}