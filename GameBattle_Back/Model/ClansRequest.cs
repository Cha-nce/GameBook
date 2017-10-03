using System.Collections.Generic;

namespace GameBattle
{
    public class ClanRequest
    {
        public int Id { get; set; }
        public User user1 { get; set; }
        public User user2 { get; set; }
        public Clan clan { get; set; }
        public string message { get; set; }
        public string RequestType { get; set; }
    }
}