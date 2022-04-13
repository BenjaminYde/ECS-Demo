using UnityEngine;
using Random = UnityEngine.Random;

namespace Movement01
{
    public class ShipFactoryClassic : AShipFactory
    {
        // .. INITIALIZATION
        
        public ShipFactoryClassic(ShipDescription shipDescription, GameObject prefabShip) 
            : base(shipDescription, prefabShip)
        {
        }

        // .. PROTECTED

        protected override void CreateShips_Internal(int count)
        {
            Vector3 pos = default;
            for (int i = 0; i < count; ++i)
            {
                float randomX = Random.Range(-ShipCreationAreaSize/2, ShipCreationAreaSize/2);
                pos.x = randomX;
                
                var ship = GameObject.Instantiate(prefabShip, pos, Quaternion.identity).AddComponent<Ship>();
                
                ship.MaxMovePositionZ = ShipCreationAreaSize;
                ship.Speed = this.shipDescription.ShipSpeed;
                ship.DoHeavyCalculation = this.shipDescription.DoHeavyCalculation;
            }        
        }
    }
}