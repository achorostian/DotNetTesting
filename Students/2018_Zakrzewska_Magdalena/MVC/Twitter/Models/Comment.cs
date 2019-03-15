using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Twitter.Models;

namespace Twitter.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        [MinLength(5, ErrorMessage = "Comment content to short. Minimum length : {1}.")]
        [MaxLength(160, ErrorMessage = "Comment content to long. Maximum length : {1}.")]
        public string Content { get; set; }
        public int TweetId { get; set; }
        public virtual Tweet Tweet { get; set; }
    }
}