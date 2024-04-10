
using System.Runtime.InteropServices;

namespace GenericMethods.Domain.Interfaces
{
    internal interface IPetStore<T>
    {
        void AddPet(T pet);
        void PrintPets();
        void BuyPet(string name);
    }
}
