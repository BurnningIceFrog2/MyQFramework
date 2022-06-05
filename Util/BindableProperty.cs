using System;

namespace com.QFramework 
{
    public class BindableProperty<T>
    {
        private T _value;

        private Action<T> onValueChanged;

        public BindableProperty() 
        {
            _value = default(T);
        }

        public BindableProperty(T defaultValue) 
        {
            _value = defaultValue;
        }

        public IUnSubscribe Subscribe(Action<T> onPropertyChanged) 
        {
            onValueChanged += onPropertyChanged;
            return new BindablePropertyUnSubscribe<T>(this,onPropertyChanged);
        }

        public void UnSubscribe(Action<T> onPropertyChanged) 
        {
            onValueChanged -= onPropertyChanged;
        }
        
        public T Value 
        {
            get => _value;
            set 
            {
                if (_value != null)
                {
                    if (!_value.Equals(value)) 
                    {
                        _value = value;
                        onValueChanged?.Invoke(_value);
                    }
                }
                else 
                {
                    if (value != null) 
                    {
                        _value = value;
                        onValueChanged?.Invoke(_value);
                    }
                }
            }
        }
        public override string ToString()
        {
            if (_value == null) 
            {
                return "null";
            }
            return _value.ToString();
        }
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) 
            {
                return false;
            }
            if (!(obj is BindableProperty<T>)) 
            {
                return false;
            }
            var p2 = (BindableProperty<T>)obj;
            return this==p2;
        }

        public static implicit operator T(BindableProperty<T> b) 
        {
            return b.Value;
        }
        public static implicit operator BindableProperty<T>(T value) 
        {
            return new BindableProperty<T>(value);
        }
        public static bool operator ==(BindableProperty<T> b1, BindableProperty<T> b2)
        {
            if (b1.Value == null && b2.Value == null)
            {
                return true;
            }
            else if (b1.Value == null)
            {
                return b2.Value.Equals(b1.Value);
            }
            else
            {
                return b1.Value.Equals(b2.Value);
            }
        }
        public static bool operator !=(BindableProperty<T> b1, BindableProperty<T> b2)
        {
            return !(b1 == b2);
        }
    }
}
