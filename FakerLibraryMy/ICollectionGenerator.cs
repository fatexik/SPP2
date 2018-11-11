using System;

namespace FakerLibraryMy
{
    public interface ICollectionGenerator
    {
        object generate(Type t);
        string getTypeName();
    }
}