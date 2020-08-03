using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Movement01
{
    public class ShipManager : Authoring
    {
        // .. FIELDS
        [Header("Update Method")] 
        [SerializeField]
        public UpdateType updateType = default;
        
        [Header("Spawn Settings")] 
        [SerializeField]
        public GameObject PrefabShip = null;
        [SerializeField]
        public int SpawnCount = 1000;
        [SerializeField]
        public float HalfBound = 500f;
        
        [Header("Ship Settings")] 
        public float ShipSpeed = 50;
        
        // .. OPERATIONS
        protected override void SetManager(out Manager manager)
        {
            manager = null;
            switch (updateType)
            {
                case UpdateType.Mono:
                    manager = CreateManager<ShipManagerClassic>();
                    break;
                case UpdateType.Jobs:
                    manager = CreateManager<ShipManagerJob>();
                    break;
                case UpdateType.Ecs:
                    break;
            }
        }
    }
}