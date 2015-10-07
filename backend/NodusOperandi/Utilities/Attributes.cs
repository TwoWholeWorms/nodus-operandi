using System;

namespace NodusOperandi.Utilities
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class NodusOperandiPlugin : Attribute
    {
        readonly Type type;
        public Type Type => type;

        public NodusOperandiPlugin(Type type)
        {
            this.type = type;
        }
    }
}

