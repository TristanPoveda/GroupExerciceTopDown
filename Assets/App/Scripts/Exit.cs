using Sirenix.OdinInspector;
using UnityEngine;
public class Exit : MonoBehaviour
{
    [Title("Settings")]
    [SerializeField] private int requiredItemQuantity;
    [SerializeField] private string nextLevel;

    [Title("RSO")]
    [SerializeField] private RSO_Items rsoItems;

    [Title("RSE")]
    [SerializeField] private RSE_OpenScene rseOpenScene;

    private void Awake()
    {
        if(rsoItems.Value != null) rsoItems.Value.Clear();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(rsoItems.Value.Count);
        if (other.CompareTag("Player") && rsoItems.Value.Count >= requiredItemQuantity)
        {
            rseOpenScene.Call(nextLevel);
        }
    }
}