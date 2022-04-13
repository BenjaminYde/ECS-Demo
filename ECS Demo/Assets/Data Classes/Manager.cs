using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    protected Authoring authoring;
    
    public void SetAuthoring(Authoring authoring)
    {
        this.authoring = authoring;
    }
}

public class Manager<T> : Manager where T : Authoring
{
    public T Authoring => authoring as T;
    
}
