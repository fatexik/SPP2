using System;

namespace Faker
{
    public class GeneratorTypeLong:IGenerator
    {
        public object generate()
        {
            Random random = new Random();
            return random.Next(int.MinValue, int.MaxValue);
        }

        public string getTypeName()
        {
            return "Long";
        }
    }
}