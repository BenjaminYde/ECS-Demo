using System;
using System.Collections;
using System.Collections.Generic;
using Movement01;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;
using Random = UnityEngine.Random;

public class ShipManagerJob : AShipManager
{
    private TransformAccessArray transforms;
    private MovementJob job;
    private JobHandle handle;
    
    // .. INITIALIZATION
    private void Start()
    {
        transforms = new TransformAccessArray(0, -1);
    }
    
    // .. MONO
    private void Update()
    {
        handle.Complete();
        
        // input
        if (Input.GetKeyDown(KeyCode.Space))
            CreateShips(Authoring.PrefabShip, Authoring.SpawnCount);
        
        // move transforms
        job = new MovementJob()
        {
            moveSpeed = Authoring.ShipSpeed,
            halfBound = Authoring.HalfBound,
            deltaTime = Time.deltaTime
        };
        
        handle = job.Schedule(transforms);

        JobHandle.ScheduleBatchedJobs();
        
    }
    private void OnDisable()
    {
        handle.Complete();
        transforms.Dispose();
    }
    
    // .. PUBLIC OPERATIONS
    public override void CreateShips(GameObject prefabShip, int count)
    {
        // finish last jobs
        handle.Complete();

        // add ship transforms
        transforms.capacity = transforms.length + count;
        
        Vector3 pos = default;
        for (int i = 0; i < count; ++i)
        {
            // instantiate ship
            float randomX = Random.Range(-Authoring.HalfBound, Authoring.HalfBound);
            pos.x = randomX;
            var ship = Instantiate(prefabShip, pos, Quaternion.identity);
            // add transform to list
            transforms.Add(ship.transform);
        }
        
        base.CreateShips(prefabShip, count);
    }

    
}
