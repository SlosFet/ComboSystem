﻿using System;
using UnityEngine;

namespace Obi
{
    [Serializable]
    public class ObiNativeTriangleList : ObiNativeList<Triangle>
    {
        public ObiNativeTriangleList() { }
        public ObiNativeTriangleList(int capacity = 8, int alignment = 16) : base(capacity, alignment)
        {
            for (int i = 0; i < capacity; ++i)
                this[i] = new Triangle();
        }

    }
}

