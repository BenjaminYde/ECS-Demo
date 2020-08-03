using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class FpsUI : MonoBehaviour
{
    [Header("UI")] 
    [SerializeField] 
    private Text textShipCount = null;
    
    private void Update()
    {
        float fps = Mathf.Ceil(1.0f / Time.deltaTime);
        textShipCount.text = fps.ToString(CultureInfo.InvariantCulture);
    }
}
