using AnimalNursery.Models.Animals.ImpBeastOfBurden;
using AnimalNursery.Models.Animals.ImpPets;
using AnimalNursery.Models.Animals;

namespace AnimalNursery.Models
{
    public class TypeOfFriendsOfHuman
    {
        public static FriendOfHuman create(string item)
        {
            switch (item)
            {
                case "Camel": return new Camel();
                case "Donkey": return new Donkey();
                case "Horse": return new Horse();
                case "Dog": return new Dog();
                case "Cat": return new Cat();
                case "Humster": return new Humster();
                default: return new FriendOfHuman();

            }


        }
    }
}
