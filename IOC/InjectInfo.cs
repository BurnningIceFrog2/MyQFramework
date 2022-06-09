using System;
using System.Reflection;

namespace LGUVirtualOffice.Framework
{
    public class InjectInfo
    {
        public Type BaseType { get; set; }
        public FieldInfo InjectField { get; set; }
        public Type InjectType { get; set; }
        public InjectScope InjectScope { get; set; }
    }
}
