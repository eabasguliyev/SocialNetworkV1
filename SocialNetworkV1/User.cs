using System;
using System.Text;
using Exceptions;

namespace User
{
    class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Post.Post[] Posts { get; private set; }
        public bool Activation { get; set; } = default;

        private static int CurrentId { get; set; } = default;

        public User()
        {
            Id = ++CurrentId;
        }

        public void AddPost(ref Post.Post post)
        {
            var newLength = (Posts != null) ? Posts.Length + 1 : 1;
            var temp = new Post.Post[newLength];

            if (temp == null)
                throw new DatabaseException("Can not allocate new memory!");

            if (Posts != null)
            {
                Array.Copy(Posts, temp, Posts.Length);
            }

            temp[newLength - 1] = post;

            Posts = temp;
        }
    }
}
