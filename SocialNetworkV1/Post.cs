using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post
{
    class Post
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; private set; }
        public int LikeCount { get; set; } = default;
        public int ViewCount { get; set; } = default;

        private static int CurrentId { get; set; } = default;

        public Post()
        {
            Id = ++CurrentId;
            CreationDate = DateTime.Now;
        }

        public static Post operator ++(Post post)
        {
            post.LikeCount++;
            return post;
        }

        public override string ToString()
        {
            var post = new StringBuilder();

            post.Append($"User: {Username}\n")
                .Append($"Creation date: {CreationDate}\n")
                .Append($"Content: {Content}\n")
                .Append($"Likes: {LikeCount}\n")
                .Append($"View count: {ViewCount}");

            return post.ToString();
        }
    }
}
