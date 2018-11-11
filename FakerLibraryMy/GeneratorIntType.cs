using System;

namespace FakerLibraryMy
{
    public class GeneratorIntType:IGenerator
    {
        public object generate()
        {
            Random random = new Random();
            return random.Next(1, int.MaxValue);
        }

        public string getTypeName()
        {
            return "Int";
        }
    }
}