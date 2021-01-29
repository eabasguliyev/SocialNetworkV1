using System;

namespace Notification
{
    class Notification
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; private set; }
        public User.User FromUser { get; set; }

        private static int CurrentId { get; set; } = default;

        public Notification()
        {
            Id = ++CurrentId;
            CreationDate = DateTime.Now;
        }
    }
}
