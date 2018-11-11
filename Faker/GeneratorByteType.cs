using System;

namespace Faker
{
    public class GeneratorByteType:IGenerator
    {
        public object generate()
        {
            Random random = new Random();
            return (byte) random.Next(0, 256);
        }

        public string getTypeName()
        {
            return "Byte";
        }
    }
}