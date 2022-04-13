using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Movement01
{
    [GenerateAuthoringComponent]
    public struct MoveForward : IComponentData
    {
        public float speed;
        public float halfBound;
        public bool doHeavyCalculation;
    }
}
