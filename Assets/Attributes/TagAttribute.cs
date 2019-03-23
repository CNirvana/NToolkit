﻿using System;
using UnityEngine;

namespace Nirvana.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class TagAttribute : PropertyAttribute
    {
    }
}