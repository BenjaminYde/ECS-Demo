﻿using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Movement01
{
    public partial class MovementSystem : SystemBase
    {
        // 1. create on update method
        protected override void OnUpdate()
        {
            float dt = Time.DeltaTime;
            // 2. run over all entities with MoveForward Component (lambda expression)
            Entities.ForEach((ref Translation translation, ref Rotation rotation, ref MoveForward moveForward) =>
            {
                // 3. apply logic
                float3 pos = translation.Value;
                pos += moveForward.speed * dt * math.forward(rotation.Value);

                if (pos.z > moveForward.halfBound)
                    pos.z = -moveForward.halfBound;

                if (moveForward.doHeavyCalculation)
                {
                    float value = 0;
                    for (int i = 0; i < 10000; i++)
                    {
                        value = math.exp10(math.sqrt(value));
                    }
                }

                translation.Value = pos;
            }).ScheduleParallel();
        }
    } 
}