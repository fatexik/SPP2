using System;
using System.Collections;
using System.Collections.Generic;

namespace Faker
{
    public class GeneratorTypeList:ICollectionGenerator
    {
        private FieldValueGenerator _fieldValueGenerator;
        public GeneratorTypeList(FieldValueGenerator fieldValueGenerator)
        {
            _fieldValueGenerator = fieldValueGenerator;
        }
        public object generate(Type t)
        {
            object newObject = Activator.CreateInstance(typeof(List<>).MakeGenericType(t));
            ((IList) newObject).Add(_fieldValueGenerator.generateValue(t));
            return newObject;
        }

        public string getTypeName()
        {
            return "List`1";
        }
    }
}