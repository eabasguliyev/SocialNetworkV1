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
        public Post.Post Posts { get; private set; }
        public bool Activation { get; set; } = default;

        private static int CurrentId { get; set; } = default;

        public User()
        {
            Id = ++CurrentId;
        }
    }
}
