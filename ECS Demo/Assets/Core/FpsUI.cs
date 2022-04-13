using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class FpsUI : MonoBehaviour
{
    // .. FIELDS
    
    [Header("UI")] 
    [SerializeField] 
    private Text textShipCount = null;
    
    // .. PRIVATE
    
    private void Update()
    {
        float dt = Time.unscaledDeltaTime;
        float fps = Mathf.Floor(1000.0f/(dt*1000f));
        float ms = dt * 1000;
        
        this.textShipCount.text = $"{fps.ToString(CultureInfo.InvariantCulture)} ({ms:F1}ms)";
    }
}
