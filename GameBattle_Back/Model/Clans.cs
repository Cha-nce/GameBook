using System.Collections.Generic;
namespace GameBattle
{
    public class Clan
    {
        public int Id { get; set; }
        public string clanname { get; set; }
        public User clanleader { get; set; }
        public List<User> clanmembers{ get; set; }
    }

}
