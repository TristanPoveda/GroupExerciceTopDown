using UnityEngine;
public class FogOfWar : MonoBehaviour
{
    //[Header("Settings")]

    //[Header("References")]

    //[Space(10)]
    // RSO
    // RSF
    // RSP

    //[Header("Input")]
    //[Header("Output")]
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fog"))
        {
            Destroy(gameObject);
        }
    }
}