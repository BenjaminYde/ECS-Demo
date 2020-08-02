using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

namespace Movement01
{
    public struct MovementJob : IJobParallelForTransform
    {
        public float moveSpeed;
        public float halfBound;
        public float deltaTime;
        
        public void Execute(int index, TransformAccess transform)
        {
            Vector3 pos = transform.localPosition;
            pos += Vector3.forward * (moveSpeed * deltaTime);

            if (pos.z > halfBound)
                pos.z = -halfBound;

            transform.localPosition = pos;
        }
    }
}
