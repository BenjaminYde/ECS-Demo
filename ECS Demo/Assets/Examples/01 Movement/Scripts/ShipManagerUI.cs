using Movement01;
using UnityEngine;
using UnityEngine.UI;

public class ShipManagerUI : MonoBehaviour
{
    // .. FIELDS
    
    [Header("References")] 
    [SerializeField]
    private GameManager gameManager = null;

    [Header("UI")] 
    [SerializeField] 
    private Text textShipCount = null;
    
    // .. PRIVATE
    
    private void Update()
    {
        textShipCount.text = this.gameManager.ShipFactory?.SpawnCount.ToString();
    }
}
