using System;

namespace FakerLibraryMy
{
    public class GeneratorDoubleType : IGenerator
    {
        public object generate()
        {
            Random random = new Random();
            return random.NextDouble();
        }

        public string getTypeName()
        {
            return "Double";
        }
    }
}