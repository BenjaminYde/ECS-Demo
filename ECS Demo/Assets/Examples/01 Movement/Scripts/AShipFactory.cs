using UnityEngine;

namespace Movement01
{
    public abstract class AShipFactory : IShipFactory
    {
        // .. PROPERTIES
        
        public int SpawnCount { get; protected set; }
        public float ShipCreationAreaSize { get; set; } = 500;
        
        // .. FIELDS

        protected readonly GameObject prefabShip = null;
        protected readonly ShipDescription shipDescription = null;
        
        // .. INITIALIZATION

        public AShipFactory(ShipDescription shipDescription, GameObject prefabShip)
        {
            this.prefabShip = prefabShip;
            this.shipDescription = shipDescription;
        }
        
        // .. PUBLIC
        
        public void CreateShips(int count)
        {
            CreateShips_Internal(count);
            SpawnCount += count;
        }
        
        // .. PROTECTED

        protected abstract void CreateShips_Internal(int count);
    }  
}
