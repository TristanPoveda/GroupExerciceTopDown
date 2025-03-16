using Sirenix.OdinInspector;
using UnityEngine;
public class Exit : MonoBehaviour
{
    [Title("Settings")]
    [SerializeField] private int requiredItemQuantity;

    [Title("RSO")]
    [SerializeField] private RSO_Items rsoItems;

    [Title("RSE")]
    [SerializeField] private RSE_ExitReached rseExitReached;

    private void Awake()
    {
        rsoItems.Value.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(rsoItems.Value.Count);
        if (other.CompareTag("Player") && rsoItems.Value.Count >= requiredItemQuantity)
        {
            rseExitReached.Call();
            //Add Something
            Destroy(other.gameObject); //Destroy Player for testing
        }
    }
}