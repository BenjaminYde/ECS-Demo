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
        float dt = Time.unscaledDeltaTime;
        float fps = Mathf.Floor(1000.0f/(dt*1000f));
        float ms = dt * 1000;
        textShipCount.text = $"{fps.ToString(CultureInfo.InvariantCulture)} ({ms:F1}ms)";
    }
}
