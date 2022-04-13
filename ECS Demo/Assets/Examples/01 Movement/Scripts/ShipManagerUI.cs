using System;
using System.Collections;
using System.Collections.Generic;
using Movement01;
using UnityEngine;
using UnityEngine.UI;

public class ShipManagerUI : MonoBehaviour
{
    [Header("References")] 
    [SerializeField]
    private ShipManager shipManager = null;

    [Header("UI")] 
    [SerializeField] 
    private Text textShipCount = null;
    
    private void Update()
    {
        textShipCount.text = (shipManager.Manager as AShipManager)?.SpawnCount.ToString();
    }
}
