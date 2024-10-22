using System;
using System.Collections.Generic;
using UnityEngine;

// ReSharper disable RedundantAssignment

namespace BricksBucket.Postman
{
    public enum DataType
    {
        NULL,
        BOOL,
        INTEGER,
        FLOAT,
        LONG,
        STRING,
        OBJECT,
        ARRAY
    }

    public interface IWrapper
    {
        DataType DataType { get; }
        bool IsNull { get; }
    }

    public interface IBoolWrapper : IWrapper
    {
        bool? Bool { get; set; }
    }

    public interface IIntegerWrapper : IWrapper
    {
        int? Integer { get; set; }
    }

    public interface IFloatWrapper : IWrapper
    {
        float? Float { get; set; }
    }

    public interface IStringWrapper : IWrapper
    {
        string String { get; set; }
    }

    public interface IObjectWrapper<T> : IWrapper
    {
        T Object { get; set; }
    }

    public interface IArrayWrapper<T> : IWrapper
    {
        List<T> Array { get; set; }
    }

    public abstract class Wrapper : IWrapper
    {
        public virtual DataType DataType { get; protected set; }
        public virtual bool IsNull => DataType == DataType.NULL;


        protected T? GetValue<T>(ref T value) where T : struct
        {
            if (DataType == DataType.NULL) return null;
            return value;
        }

        protected T GetValue<T>(T value) where T : class
        {
            return DataType == DataType.NULL ? null : value;
        }

        protected void SetValue<T>(ref T variable, ref T? value, DataType type)
            where T : struct
        {
            if (value == null)
            {
                DataType = DataType.NULL;
                variable = default;
            }
            else
            {
                DataType = type;
                variable = value.Value;
            }
        }

        protected void SetValue<T>(ref T variable, T value, DataType type)
            where T : class
        {
            DataType = value == null ? DataType.NULL : type;
            variable = value;
        }
    }

    [Serializable]
    public class BoolWrapper : Wrapper, IBoolWrapper
    {
        [SerializeField] private DataType m_dataType;

        [SerializeField] private bool m_bool;


        public override DataType DataType
        {
            get => m_dataType;
            protected set => m_dataType = value;
        }

        public bool? Bool
        {
            get => GetValue(ref m_bool);
            set => SetValue(ref m_bool, ref value, DataType.BOOL);
        }
    }

    [Serializable]
    public class IntegerWrapper : Wrapper, IIntegerWrapper
    {
        [SerializeField] private DataType m_dataType;

        [SerializeField] private int m_integer;


        public int? Integer
        {
            get => GetValue(ref m_integer);
            set => SetValue(ref m_integer, ref value, DataType.INTEGER);
        }

        public override DataType DataType
        {
            get => m_dataType;
            protected set => m_dataType = value;
        }
    }

    [Serializable]
    public class StringFloatWrapper :
        Wrapper, IStringWrapper, IFloatWrapper
    {
        [SerializeField] protected DataType m_dataType;

        [SerializeField] protected string m_string;

        [SerializeField] protected float m_float;

        public float? Float
        {
            get => GetValue(ref m_float);
            set => SetValue(ref m_float, ref value, DataType.FLOAT);
        }


        public override DataType DataType
        {
            get => m_dataType;
            protected set => m_dataType = value;
        }

        public string String
        {
            get => GetValue(m_string);
            set => SetValue(ref m_string, value, DataType.STRING);
        }


        public static implicit operator StringFloatWrapper(float f)
        {
            return new StringFloatWrapper { Float = f };
        }

        public static implicit operator StringFloatWrapper(string s)
        {
            return new StringFloatWrapper { String = s };
        }
    }

    [Serializable]
    public abstract class StringObjectWrapper<T> :
        Wrapper, IStringWrapper, IObjectWrapper<T>
        where T : class
    {
        [SerializeField] protected DataType m_dataType;

        [SerializeField] protected string m_string;

        [SerializeField] protected T m_object;

        public T Object
        {
            get => GetValue(m_object);
            set => SetValue(ref m_object, value, DataType.OBJECT);
        }


        public override DataType DataType
        {
            get => m_dataType;
            protected set => m_dataType = value;
        }

        public string String
        {
            get => GetValue(m_string);
            set => SetValue(ref m_string, value, DataType.STRING);
        }
    }

    [Serializable]
    public abstract class GenericWrapper<T> :
        Wrapper, IBoolWrapper, IIntegerWrapper, IFloatWrapper, IStringWrapper,
        IObjectWrapper<T>, IArrayWrapper<T>
        where T : class
    {
        [SerializeField] protected DataType m_dataType;

        [SerializeField] protected bool m_bool;

        [SerializeField] protected int m_integer;

        [SerializeField] protected float m_float;

        [SerializeField] protected string m_string;

        [SerializeField] protected T m_object;

        [SerializeField] protected List<T> m_list;

        public List<T> Array
        {
            get => GetValue(m_list);
            set => SetValue(ref m_list, value, DataType.ARRAY);
        }

        public override DataType DataType
        {
            get => m_dataType;
            protected set => m_dataType = value;
        }

        public bool? Bool
        {
            get => GetValue(ref m_bool);
            set => SetValue(ref m_bool, ref value, DataType.BOOL);
        }

        public float? Float
        {
            get => GetValue(ref m_float);
            set => SetValue(ref m_float, ref value, DataType.FLOAT);
        }

        public int? Integer
        {
            get => GetValue(ref m_integer);
            set => SetValue(ref m_integer, ref value, DataType.INTEGER);
        }

        public T Object
        {
            get => GetValue(m_object);
            set => SetValue(ref m_object, value, DataType.OBJECT);
        }

        public string String
        {
            get => GetValue(m_string);
            set => SetValue(ref m_string, value, DataType.STRING);
        }
    }
}