using Movement01;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;
using Random = UnityEngine.Random;

public class ShipFactoryJob : AShipFactory
{
    // .. FIELDS
    
    private TransformAccessArray transforms = new TransformAccessArray(0, -1);
    private MovementJob job;
    private JobHandle handle;
    
    // .. INITIALIZATION 

    public ShipFactoryJob(ShipDescription shipDescription, GameObject prefabShip) 
        : base(shipDescription, prefabShip)
    {
    }

    ~ShipFactoryJob()
    {
        handle.Complete();
        transforms.Dispose();
    }
    
    // .. PUBLIC
    
    public void TryScheduleMovementJob()
    {
        // return when job is not completed
        if(!handle.IsCompleted)
            return;

        // create job
        job = new MovementJob()
        {
            moveSpeed = this.shipDescription.ShipSpeed,
            halfBound = ShipCreationAreaSize,
            deltaTime = Time.deltaTime,
            doHeavyCalculation = this.shipDescription.DoHeavyCalculation
        };
        
        // schedule
        handle = job.Schedule(transforms);
    }

    // .. PROTECTED

    protected override void CreateShips_Internal(int count)
    {
        // finish last jobs
        handle.Complete();

        // add ship transforms
        transforms.capacity = transforms.length + count;
        
        Vector3 pos = default;
        for (int i = 0; i < count; ++i)
        {
            // instantiate ship
            float randomX = Random.Range(-ShipCreationAreaSize/2, ShipCreationAreaSize/2);
            pos.x = randomX;
            var ship = GameObject.Instantiate(prefabShip, pos, Quaternion.identity);
            ship.name = "ship job";
            
            // add transform to list
            transforms.Add(ship.transform);
        }    
    }
}
