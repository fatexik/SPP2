using System;

namespace FakerLibraryMy
{
    public class GeneratorFloatType:IGenerator
    {
        public object generate()
        {
            Random random = new Random();
            return (float) random.NextDouble();
        }

        public string getTypeName()
        {
            return "Single";
        }
    }
}