using UnityEngine;
using System.Collections;
using System;

namespace Nirvana.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class ReadOnlyAttribute : PropertyAttribute
    {
    }
}