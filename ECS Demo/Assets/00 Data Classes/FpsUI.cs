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
        float dt = Time.deltaTime;
        float fps = Mathf.Ceil(1.0f / dt);
        float ms = dt * 1000;
        textShipCount.text = $"{fps.ToString(CultureInfo.InvariantCulture)} ({ms:F1}ms)";
    }
}
