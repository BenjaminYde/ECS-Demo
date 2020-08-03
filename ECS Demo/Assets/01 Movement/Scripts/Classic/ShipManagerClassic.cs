using System;
using System.Collections;
using System.Collections.Generic;
using Movement01;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Movement01
{
    public class ShipManagerClassic : AShipManager
    {

        public override void CreateShips(GameObject prefabShip, int count)
        {
            base.CreateShips(prefabShip, count);
        
            Vector3 pos = default;
            for (int i = 0; i < count; ++i)
            {
                float randomX = Random.Range(-Authoring.HalfBound, Authoring.HalfBound);
                pos.x = randomX;
                var ship = Instantiate(prefabShip, pos, Quaternion.identity).AddComponent<Ship>();
                ship.SetHalfBounds(Authoring.HalfBound);
                ship.Speed = Authoring.ShipSpeed;
            }
        }

        private void Update()
        {
            // input
            if (Input.GetKeyDown(KeyCode.Space))
                CreateShips(Authoring.PrefabShip, Authoring.SpawnCount);
        }
    }
}