namespace RFL.Scripts.DI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Types : IEnumerable<Type>
    {
        private readonly Type[] _types;

        public Types(params Type[] types)
        {
            _types = types;
        }

        public IEnumerator<Type> GetEnumerator() => (IEnumerator<Type>)_types.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public static implicit operator Type[](Types types) => types._types;
        public static implicit operator Types(Type[] types) => new(types);

        public override string ToString() => string.Join(", ", this.Select(x => x.Name));
    }
}