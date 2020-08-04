using System;
using Movement01;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShipManagerEcs : AShipManager
{
    public override void CreateShips(GameObject prefabShip, int count)
    {
        base.CreateShips(prefabShip, count);
        
        GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
        Entity shipEntity = GameObjectConversionUtility.ConvertGameObjectHierarchy(prefabShip, settings);

        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        NativeArray<Entity> shipArray = new NativeArray<Entity>(count, Allocator.Temp);

        for (int i = 0; i < count; ++i)
        {
            shipArray[i] = entityManager.Instantiate(shipEntity);

            float randomX = Random.Range(-Authoring.HalfBound, Authoring.HalfBound);
            entityManager.SetComponentData(shipArray[i],new Translation() {Value = new float3(randomX,0,0)});
            entityManager.SetComponentData(shipArray[i],new MoveForward() {speed = Authoring.ShipSpeed, halfBound = Authoring.HalfBound});
        }
        
        shipArray.Dispose();
    }

    private void Update()
    {
        // input
        if (Input.GetKeyDown(KeyCode.Space))
            CreateShips(Authoring.PrefabShipECS, Authoring.SpawnCount);
    }
}
