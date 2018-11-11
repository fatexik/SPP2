using System;
using FakerLibraryMy;

namespace MyPlugin
{
    public class GeneratorFloatType : IGenerator
    {
        public object generate()
        {
            Random random = new Random();
            return (float) (random.NextDouble() * (float.MaxValue - float.MinValue) + float.MinValue);
        }

        public string getTypeName()
        {
            return "Single";
        }
    }
}