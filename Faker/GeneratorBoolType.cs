using System;

namespace Faker
{
    public class GeneratorBoolType:IGenerator
    {
        public object generate()
        {
            Random random = new Random();
            if (random.Next(0, 2) == 0)
            {
                return false;
            }
            return true;
        }

        public string getTypeName()
        {
            return "Bool";
        }
    }
}