using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Authoring : MonoBehaviour
{
    // .. PROPERTIES
    public Manager Manager => manager;
    
    // ..  FIELDS
    private Manager manager = null;

    // .. INITIALIZATIOn
    private void Awake()
    {
        SetManager(out Manager manager);
        this.manager = manager;
    }

    // .. OPERATIONS
    protected Manager CreateManager<T>() where T : Manager
    {
        var tempManager = gameObject.AddComponent<T>();
        tempManager.SetAuthoring(this);
        return tempManager;
    }

    protected virtual void SetManager(out Manager manager)
    {
        manager = null;
    }
}