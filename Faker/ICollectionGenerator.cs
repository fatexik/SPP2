using System;

namespace Faker
{
    public interface ICollectionGenerator
    {
        object generate(Type t);
        string getTypeName();
    }
}