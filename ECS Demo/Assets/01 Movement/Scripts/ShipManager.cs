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
    public class ShipManager : MonoBehaviour
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
        
        [Header("UI Settings")] 
        [SerializeField]
        private Text textSpawnCount = null;
        [SerializeField]
        private Text textFps = null;

        private AShipManager shipManager = null;

        private void Start()
        {
            switch (updateType)
            {
                case UpdateType.Mono:
                    shipManager = ShipManagerClassic.AddComponent(this);
                    break;
                case UpdateType.Jobs:
                    break;
                case UpdateType.Ecs:
                    break;
            }
        }

        void Update()
        {
            // set UI
            textSpawnCount.text = shipManager.SpawnCount.ToString();
            float fps = Mathf.Ceil(1.0f / Time.deltaTime);
            textFps.text = fps.ToString(CultureInfo.InvariantCulture);
        }
    }
}