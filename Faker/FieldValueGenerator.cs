using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Faker
{
    public class FieldValueGenerator
    {
        private List<Type> DTOList;
        private Faker faker;
        private Assembly _assembly;
        private JSONSerializer _jsonSerializer;
        private List<Type> _cycleControlList;
        private Dictionary<string, IGenerator> _generators;
        private Dictionary<string, ICollectionGenerator> _collectionGenerators;

        public void DTOAdd(Type t)
        {
            DTOList.Add(t);
        }

        public void deintialize()
        {
            _cycleControlList.Clear();
        }

        public object generateValue(Type type)
        {
            if (DTOList.Contains(type))
            {
                if (_cycleControlList.Contains(type))
                {
                    _cycleControlList.Remove(type);
                    return null;
                }

                List<Type> tmpCycleControlList = new List<Type>();
                tmpCycleControlList.AddRange(_cycleControlList);
                object tmpObject = faker.Create(type);
                _cycleControlList = tmpCycleControlList;
                return tmpObject;
            }

            if (_generators.ContainsKey(type.Name))
            {
                return _generators[type.Name].generate();
            }

            if (_collectionGenerators.ContainsKey(type.Name))
            {
                return _collectionGenerators[type.Name].generate(type.GenericTypeArguments[0]);
            }
          return type.IsValueType ? Activator.CreateInstance(type) : null;
        }

        public FieldValueGenerator(Faker faker)
        {
            DTOList = new List<Type>();
            _cycleControlList = new List<Type>();
//            _assembly = Assembly.Load();
            _generators = new Dictionary<string, IGenerator>();
            _generators.Add("Double",new GeneratorDoubleType());
            _generators.Add("Char",new GeneratorCharType());
            _generators.Add("Byte",new GeneratorByteType());
            _generators.Add("Int32",new GeneratorIntType());
            _generators.Add("String",new GeneratorTypeString());
            _generators.Add("Int64",new GeneratorTypeLong());
            _generators.Add("Object",new GeneratorTypeObject());
            _generators.Add("DateTime",new GeneratorDateTime());
            this.faker = faker;
//            var types = _assembly.GetTypes().Where(t => t.GetInterfaces().Any(i => i == typeof(IGenerator)));
//            foreach (var type in types)
//            {
//                var plugin = _assembly.CreateInstance(type.FullName) as IGenerator;
//                if (!_generators.ContainsKey(plugin.getTypeName()))
//                {
//                    _generators.Add(plugin.getTypeName(),plugin);
//                }
//            }
            
            _collectionGenerators = new Dictionary<string, ICollectionGenerator>();
            _collectionGenerators.Add("List`1", new GeneratorTypeList(this));
        }
    }
}
