using System;

namespace Faker
{
    public class GeneratorCharType:IGenerator
    {
        //TODO
        public object generate()
        {
            Random random = new Random();
            return Convert.ToChar(random.Next(0, 256));
        }

        public string getTypeName()
        {
            return "Char";
        }
    }
}