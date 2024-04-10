
using GenericMethods.Domain.Models;
using GenericMethods.Domain;
using GenericMethods.Domain.Helpers;

PetStore<Dog> dogStore = new PetStore<Dog>();
dogStore.AddPet(new Dog("Billy","Pomeranian", 2,true,"Chicken"));
dogStore.AddPet(new Dog("Rita", "PitBull", 1, true, "Berries"));

PetStore<Cat> catStore = new PetStore<Cat>();
catStore.AddPet(new Cat("Mia", "Birman", 5, false,7));
catStore.AddPet(new Cat("Kaja", "Bengal", 4, false, 6));

PetStore<Fish> fishStore = new PetStore<Fish>();
fishStore.AddPet(new Fish("Goldie", "Fish", 1, "Gold", "Medium"));
fishStore.AddPet(new Fish("Nia", "Fish", 2, "Blue", "Small"));

dogStore.BuyPet("Billy");
catStore.BuyPet("Mia");
fishStore.BuyPet("Kia");

ConsoleHelper.PrintInColor("\nAvailable pets \n",ConsoleColor.DarkYellow);

ConsoleHelper.PrintInColor("\nDog Store\n ", ConsoleColor.DarkMagenta);
dogStore.PrintPets();
ConsoleHelper.PrintInColor("\nCat Store\n ", ConsoleColor.Magenta);
catStore.PrintPets();
ConsoleHelper.PrintInColor("\nFish Store\n ", ConsoleColor.DarkCyan);
fishStore.PrintPets();