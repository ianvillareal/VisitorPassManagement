using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.Service.Attributes
{
    /// <summary>
    /// Property or field will be ALWAYS included during update
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class IncludeAttribute : Attribute {}
}
