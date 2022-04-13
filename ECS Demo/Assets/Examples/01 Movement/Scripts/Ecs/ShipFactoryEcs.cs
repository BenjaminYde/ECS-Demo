using Movement01;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShipFactoryEcs : AShipFactory
{
    // .. FIELDS

    private readonly Entity shipEntity;
    private readonly EntityManager entityManager;
    
    // .. INITIALIZATION
    
    public ShipFactoryEcs(ShipDescription shipDescription, GameObject prefabShip) 
        : base(shipDescription, prefabShip)
    {
        GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
        this.entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        this.shipEntity = GameObjectConversionUtility.ConvertGameObjectHierarchy(prefabShip, settings);
    }
    
    // .. PROTECTED
    
    protected override void CreateShips_Internal(int count)
    {
        // temp array of ships
        NativeArray<Entity> shipArray = new NativeArray<Entity>(count, Allocator.Temp);
        
        // create ships
        for (int i = 0; i < count; ++i)
        {
            // create ship
            shipArray[i] = entityManager.Instantiate(this.shipEntity);

            // get spawn position x
            float randomX = Random.Range(-ShipCreationAreaSize/2, ShipCreationAreaSize/2);
            
            // set current position
            entityManager.SetComponentData(
                shipArray[i],
                new Translation()
                {
                    Value = new float3(randomX,0,0)
                });
            
            // set move data
            entityManager.SetComponentData(
                shipArray[i],
                new MoveForward()
                {
                    Speed = this.shipDescription.ShipSpeed, 
                    MaxMovePositionZ = ShipCreationAreaSize, 
                    DoHeavyCalculation = this.shipDescription.DoHeavyCalculation
                });
        }
        
        // finish
        shipArray.Dispose();    
    }
}
