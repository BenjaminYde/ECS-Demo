using UnityEngine;
using UnityEngine.Serialization;

namespace Movement01
{
    public class GameManager : MonoBehaviour
    {
        // .. PROPERTIES

        public AShipFactory ShipFactory => this.shipFactory;
        
        // .. FIELDS
        
        [Header("Update Method")] 
        public UpdateMethod UpdateMethod = default;

        [Header("Spawn Settings")] 
        public GameObject PrefabShip = null;
        public GameObject PrefabShipECS = null;
        public int SpawnCount = 1000;
        public float ShipCreationAreaSize = 500f;

        [Header("Ship Settings")] 
        public ShipDescription ShipDescription;

        private AShipFactory shipFactory = null;

        // .. INITIALIZATION

        private void Start()
        {
            // create ship factory
            switch (UpdateMethod)
            {
                case UpdateMethod.Mono:
                    shipFactory = new ShipFactoryClassic(ShipDescription, PrefabShip);
                    break;
                case UpdateMethod.Jobs:
                    shipFactory = new ShipFactoryJob(ShipDescription, PrefabShip);
                    break;
                case UpdateMethod.Ecs:
                    shipFactory = new ShipFactoryEcs(ShipDescription, PrefabShipECS);
                    break;
            }
            shipFactory.ShipCreationAreaSize = ShipCreationAreaSize;
        }

        private void Update()
        {
            // input - press space
            // >> create ships
            if (Input.GetKeyDown(KeyCode.Space))
            {
                shipFactory.CreateShips(SpawnCount);
            }
            
            // update
            if (shipFactory is ShipFactoryJob shipFactoryJob)
            {
                shipFactoryJob.TryScheduleMovementJob();
            }
        }
    }
}