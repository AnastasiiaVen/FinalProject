using AnimalNursery.Models.Commands;

namespace AnimalNursery.Models.Animals
{
    public class FriendOfHuman
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Type { get; set; }
        public List<string> Commands { get; set; }

    }
}
