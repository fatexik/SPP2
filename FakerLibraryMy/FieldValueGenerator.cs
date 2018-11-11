using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FakerLibraryMy
{
    public class FieldValueGenerator
    {
        private Faker faker;
        private Assembly _assembly;
        private List<Type> _cycleControlList;
        private Dictionary<string, IGenerator> _generators;
        private Dictionary<string, ICollectionGenerator> _collectionGenerators;
        private string plugins = "C:\\Users\\vital\\RiderProjects\\SPP2\\MyPlugin\\bin\\Debug\\MyPlugin.dll";

        public void clearCycleControlList(List<Type> list)
        {
            foreach (var t in list)
            {
                if (_cycleControlList.Contains(t))
                {
                    _cycleControlList.Remove(t);
                }
            }
        }
        
        public object generateValue(Type type,List<Type> createdElem)
        {
            if (_generators.ContainsKey(type.Name))
            {
                return _generators[type.Name].generate();
            }

            if (_collectionGenerators.ContainsKey(type.Name))
            {
                return _collectionGenerators[type.Name].generate(type.GenericTypeArguments[0]);
            }

            if (_cycleControlList.Contains(type))
            {
                return null;
            }
            List<Type> tmpCycleControlList = new List<Type>();
            _cycleControlList.Add(type);
            foreach (var onceType in _cycleControlList)
            {
                tmpCycleControlList.Add(onceType);
            }
            object tmpObject = faker.Create(type);
            _cycleControlList = tmpCycleControlList;
            createdElem.Add(type);
            return tmpObject;
        }

        public void addFirst(Type t)
        {
            _cycleControlList.Add(t);
        }
        
        public FieldValueGenerator(Faker faker)
        {
            _cycleControlList = new List<Type>();
            _assembly = Assembly.LoadFrom(plugins);
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
            var types = _assembly.GetTypes().Where(t => t.GetInterfaces().Any(i => i == typeof(IGenerator)));
            foreach (var type in types)
            {
                var plugin = _assembly.CreateInstance(type.FullName) as IGenerator;
                if (!_generators.ContainsKey(plugin.getTypeName()))
                {
                    _generators.Add(plugin.getTypeName(),plugin);
                }
            }
            _collectionGenerators = new Dictionary<string, ICollectionGenerator>();
            _collectionGenerators.Add("List`1", new GeneratorTypeList(this));
        }
    }
}
