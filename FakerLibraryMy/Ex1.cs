using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FakerLibraryMy
{
    [DataContract]
    public class Ex1<T>
    {
        [DataMember] private int _int;
        [DataMember] private string _string;
        [DataMember] private char _char;
        [DataMember] private List<T> _list;
        [DataMember] private double _double;
        [DataMember] private long _long;
        [DataMember] private DateTime _dateTime;
        [DataMember] private bool _bool;
        [DataMember] private object _object;
        [DataMember] private Ex2<string> _ex2;

        public int getInt()
        {
            return _int;
        }

        public string getString()
        {
            return _string;
        }

        public char getChar()
        {
            return _char;
        }

        public List<T> getList()
        {
            return _list;
        }

        public object getObj()
        {
            return _object;
        }

        public bool getBool()
        {
            return _bool;
        }

        public long getLong()
        {
            return _long;
        }

        public DateTime getDateTime()
        {
            return _dateTime;
        }

        public double getDouble()
        {
            return _double;
        }

        public Ex2<string> getEx2()
        {
            return _ex2;
        }
        
        public Ex1(int i, string s, char ch, List<T> list,object obj,bool boolean, long l,DateTime date,double d,Ex2<string> ex2)
        {
            _int = i;
            _string = s;
            _char = ch;
            _list = list;
            _object = obj;
            _bool = boolean;
            _long = l;
            _dateTime = date;
            _double = d;
            _ex2 = ex2;
        }
    }
}