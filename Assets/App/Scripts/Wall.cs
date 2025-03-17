using UnityEngine;
public class Wall : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] string levelToRestart;

    [Header("References")]
    [SerializeField] RSE_OpenScene rSE_OpenScene;

    //[Space(10)]
    // RSO
    // RSF
    // RSP

    //[Header("Input")]
    //[Header("Output")]
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rSE_OpenScene.Call(levelToRestart);
        }
    }
}