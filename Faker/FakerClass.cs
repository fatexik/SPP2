using System;
using System.Reflection;

namespace Faker
{
    public class Faker:IFaker
    {
        private FieldValueGenerator _fieldValueGenerator;

        public Faker()
        {
            _fieldValueGenerator = new FieldValueGenerator(this);
        }
        public object Create(Type type)
        {
            ConstructorInfo[] constructorInfos = type.GetConstructors();
            ConstructorInfo parametrizedConstructorInfo = null;
            ParameterInfo[] parameterInfos;
            object obj;
            for (int i = 0; i < constructorInfos.Length; i++)
            {
                parameterInfos = constructorInfos[i].GetParameters();
                if (parameterInfos.Length>0)
                {
                    parametrizedConstructorInfo = constructorInfos[i];
                }
            }

            if (parametrizedConstructorInfo != null)
            {
                obj = CreateByConstructor(type, parametrizedConstructorInfo);
            }
            else
            {
                obj = CreateByPublicFields(type);
            }

            return obj;
        }
        
        private object CreateByConstructor(Type t, ConstructorInfo info)
        {
            object[] tmp = new object[info.GetParameters().Length];
            int i = 0;
            foreach(ParameterInfo parameterInfo in info.GetParameters())
            {
                tmp[i] = _fieldValueGenerator.generateValue(parameterInfo.ParameterType);
                i++;
            }

            return info.Invoke(tmp);
        }
        private object CreateByPublicFields(Type t)
        {
            object tmp = Activator.CreateInstance(t);
            FieldInfo[] fieldInfo = t.GetFields(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] propertyInfo = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo info in fieldInfo)
                info.SetValue(tmp, _fieldValueGenerator.generateValue(info.FieldType));
            foreach (PropertyInfo info in propertyInfo)
                info.SetValue(tmp, _fieldValueGenerator.generateValue(info.PropertyType));

            return tmp;
        }

        public T Create<T>()
        {
            return (T) Create(typeof(T));
        }
    }
}