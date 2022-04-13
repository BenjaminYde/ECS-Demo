using Unity.Mathematics;
using UnityEngine;

namespace Movement01
{
    public class Ship : MonoBehaviour
    {
        // .. PROPERTIES
        
        public float Speed { get; set; }
        public float MaxMovePositionZ { get; set; }
        public bool DoHeavyCalculation { get; set; }
        
        
        // .. MONO
        
        private void Update()
        {
            Move(Time.deltaTime);

            if (DoHeavyCalculation)
            {
                float value = 0;
                for (int i = 0; i < 10000; i++)
                {
                    value = math.exp10(math.sqrt(value));
                }
            }
        }

        // .. PRIVATE 
        
        private void Move(float deltaTime)
        {
            var pos = transform.localPosition;

            pos += Vector3.forward * (Speed * deltaTime);;

            if (pos.z > MaxMovePositionZ) 
                pos.z = -MaxMovePositionZ;

            transform.localPosition = pos;
        }
    } 
}

