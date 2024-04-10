

using GenericMethods.Domain.Helpers;
using GenericMethods.Domain.Interfaces;
using GenericMethods.Domain.Models.BaseModel;

namespace GenericMethods.Domain
{
    public class PetStore<T> : IPetStore<T> where T : Pet
    {
        List<T> pets { get; set; }

        public PetStore()
        {
            pets = new List<T>();
        }
        public void AddPet(T pet)
        {
            pets.Add(pet);
        }

        public void PrintPets()
        {
            if (pets.Count == 0)
            {
                ConsoleHelper.PrintInColor("No pets available in the store ",ConsoleColor.Red);
            }
            else
            {
                foreach (T pet in pets)
                {
                    pet.PrintInfo();
                }
            }
        }

        public void BuyPet(string name)
        {
            T pet = pets.Find(p=>p.Name == name);
            if (pet != null)
            {
                pets.Remove(pet);
                ConsoleHelper.PrintInColor($"You successfully bought {name} from the store.",ConsoleColor.Green);
            }
            else
            {
                ConsoleHelper.PrintInColor($"Sorry, {name} is not available in the store.", ConsoleColor.Red);
            }
           
        }

    }
}
