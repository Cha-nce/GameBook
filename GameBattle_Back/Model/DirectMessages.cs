using System.Collections.Generic;

namespace GameBattle
{
    public class DirectMessage
    {
        public int Id { get; set; }
        public User user1 { get; set; }
        public User user2 { get; set; }
        public string RequestType { get; set; }
        public string Message { get; set; }
    }
}

