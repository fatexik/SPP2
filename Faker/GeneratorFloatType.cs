using System;

namespace Faker
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