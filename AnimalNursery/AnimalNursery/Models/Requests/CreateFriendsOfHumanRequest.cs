    using AnimalNursery.Models.Commands;

namespace AnimalNursery.Models.Requests
{
    public class CreateFriendsOfHumanRequest
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Type { get; set; }
        public string Commands { get; set; }
    }
}
