using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement01
{
    public class Ship : MonoBehaviour
    {
        // .. PROPERTIES
        public float Speed { get; set; }
        
        // .. FIELDS
        private float halfbound = 0;

        // .. MONO
        private void Update()
        {
            Move(Time.deltaTime);
        }
    
        // .. PUBLIC OPERATIONS
        public void SetHalfBounds(float bound)
        {
            halfbound = bound;
        }
        

        // .. PRIVATE OPERATIONS
        private void Move(float deltaTime)
        {
            var pos = transform.localPosition;

            pos += Vector3.forward * (Speed * deltaTime);;

            if (pos.z > halfbound) 
                pos.z = -halfbound;

            transform.localPosition = pos;
        }
    } 
}

