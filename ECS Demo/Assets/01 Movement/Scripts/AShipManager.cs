using System.Collections;
using System.Collections.Generic;
using Movement01;
using UnityEngine;

namespace Movement01
{
    public abstract class AShipManager : Manager<ShipManager>, IShipManager
    {
        // .. PROPERTIES
        public int SpawnCount { get; private set; }
    
    
        // .. PUBLIC OPERATIONS
        public virtual void CreateShips(GameObject prefabShip, int count)
        {
            SpawnCount += count;
        }
    }  
}
