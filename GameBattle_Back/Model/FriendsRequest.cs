using System.Collections.Generic;

namespace GameBattle
{
    public class FriendRequest
    {
        public int Id { get; set; }
        public User user1 { get; set; }
        public User user2 { get; set; }
        public Clan userclan { get; set; }
        public string RequestType { get; set; }
    }
}