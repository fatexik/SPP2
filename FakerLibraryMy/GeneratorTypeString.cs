using System;
using System.Text;

namespace FakerLibraryMy
{
    public class GeneratorTypeString:IGenerator
    {
        public object generate()
        {
            Random random = new Random();
            int stringLength = random.Next(0, 200);
            StringBuilder stringBuilder = new StringBuilder();
            char oneChar;
            for (int i = 0; i < stringLength; i++)
            {
                oneChar = Convert.ToChar(random.Next(0, 256));
                stringBuilder.Append(oneChar);
            }

            return stringBuilder.ToString();
        }

        public string getTypeName()
        {
            return "String";
        }
    }
}