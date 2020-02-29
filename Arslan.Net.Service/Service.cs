using System;
using System.Collections.Generic;

namespace Arslan.Net
{
    public static class Service 
    {
        internal static Func<Type, object> _resolver;
        internal static T Resolve<T>() => (T)_resolver(typeof(T));
        public static void Configure(Func<Type, object> resolver) => _resolver = resolver;
    }

    public struct Service<T> : IEquatable<Service<T>>, IEquatable<T>
    {
        private T _value;

        internal Service(T service = default) {
            _value = service;
        }

        public T Value {
            get {
                var value = GetValueOrDefault();
                if (value == null)
                    throw new InvalidOperationException();

                return value;
            }
        }

        public T GetValueOrDefault(T defaultValue = default) {
            if (_value == null)
                _value = Service.Resolve<T>();

            return _value ?? defaultValue;
        }

        public override bool Equals(object other) {
            var value = GetValueOrDefault();
            if (value == null)
                return other == null;

            if (value == null)
                return false;

            if (other is Service<T> service)
                return Equals(service.GetValueOrDefault(), value);

            if (other is T t)
                return Equals(t, value);

            return false;
        }

        public bool Equals(Service<T> other) => Equals(other.GetValueOrDefault());

        public bool Equals(T other) => EqualityComparer<T>.Default.Equals(GetValueOrDefault(), other);

        public override int GetHashCode() {
            var value = GetValueOrDefault();
            return value == null ? 0 : value.GetHashCode();
        }

        public override string ToString() {
            var value = GetValueOrDefault();
            return value == null ? default : value.ToString();
        }

        public static implicit operator Service<T>(T service) => new Service<T>(service);
        public static explicit operator T(Service<T> service) => service.GetValueOrDefault();
    }
}
