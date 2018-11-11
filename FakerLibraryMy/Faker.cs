using System;
using System.Collections.Generic;
using System.Reflection;

namespace FakerLibraryMy
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
            ConstructorInfo[] constructorInfos = type.GetConstructors(BindingFlags.Public|BindingFlags.Instance);
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
                if (constructorInfos.Length!=0)
                {
                    obj = CreateByPublicFields(type);
                }
                else
                {
                    obj = null;
                }
            }

            return obj;
        }
        
        private object CreateByConstructor(Type t, ConstructorInfo info)
        {
            object[] tmp = new object[info.GetParameters().Length];
            int i = 0;
            List<Type> elementCreated = new List<Type>();
            foreach(ParameterInfo parameterInfo in info.GetParameters())
            {
                tmp[i] = _fieldValueGenerator.generateValue(parameterInfo.ParameterType,elementCreated);
                i++;
            }
            _fieldValueGenerator.clearCycleControlList(elementCreated);
            return info.Invoke(tmp);
        }
        private object CreateByPublicFields(Type t)
        {
            object tmp = Activator.CreateInstance(t);
            FieldInfo[] fieldInfo = t.GetFields(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] propertyInfo = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            List<Type> elementCreated = new List<Type>();
            foreach (FieldInfo info in fieldInfo)
                info.SetValue(tmp, _fieldValueGenerator.generateValue(info.FieldType,elementCreated));
            foreach (PropertyInfo info in propertyInfo)
                info.SetValue(tmp, _fieldValueGenerator.generateValue(info.PropertyType,elementCreated));
            _fieldValueGenerator.clearCycleControlList(elementCreated);
            return tmp;
        }

        public T Create<T>()
        {
            _fieldValueGenerator.addFirst(typeof(T));
            return (T) Create(typeof(T));
        }
    }
}