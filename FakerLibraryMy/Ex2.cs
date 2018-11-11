using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FakerLibraryMy
{
    public class Ex2<T>
    {
        [DataMember] public int _int;
        [DataMember] public double _double;
        [DataMember] public float _float;
        [DataMember] public bool _bool;
        [DataMember] public string _string;
        [DataMember] public object _object;
        [DataMember] public List<T> _list;
        [DataMember] public Ex1<string> _ex1;
        [DataMember] public Ex2<char> _ex2;
        [DataMember] public long _long { get; set; }
    }
}