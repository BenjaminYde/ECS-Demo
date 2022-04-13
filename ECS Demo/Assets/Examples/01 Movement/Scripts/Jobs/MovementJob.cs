using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

namespace Movement01
{
    [BurstCompile]
    public struct MovementJob : IJobParallelForTransform
    {
        [ReadOnly] public float moveSpeed;
        [ReadOnly] public float halfBound;
        [ReadOnly] public float deltaTime;
        [ReadOnly] public bool doHeavyCalculation;

        public void Execute(int index, TransformAccess transform)
        {
            Vector3 pos = transform.localPosition;
            pos += Vector3.forward * (moveSpeed * deltaTime);

            if (pos.z > halfBound)
                pos.z = -halfBound;

            transform.localPosition = pos;

            if (doHeavyCalculation)
            {
                float value = 0;
                for (int i = 0; i < 10000; i++)
                {
                    value = math.exp10(math.sqrt(value));
                }
            }
        }
    }
}
