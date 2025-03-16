using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RSO_Items rsoItems;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rsoItems.Value.Add(this);
            Destroy(gameObject);
        }
    }
}