using System.Collections;
using System.Collections.Generic;
using Movement01;
using UnityEngine;

public abstract class AShipManager : MonoBehaviour, IShipManager
{
    // .. PROPERTIES
    public int SpawnCount { get; private set; }

    protected ShipManager authoring = null;

    // .. INITALIZATION
    public void Initialize(ShipManager authoring)
    {
        this.authoring = authoring;
    }
    
    // .. PUBLIC OPERATIONS
    public virtual void CreateShips(GameObject prefabShip, int count)
    {
        SpawnCount += count;
    }
}
