using TMPro;
using UnityEngine;
public class MovementPointsUI : MonoBehaviour
{
    //[Header("Settings")]

    [Header("References")]
    [SerializeField] RSO_MovementPoints rSO_MovementPoints;
    [SerializeField] TextMeshProUGUI movementPointText;

    //[Space(10)]
    // RSO
    // RSF
    // RSP

    //[Header("Input")]
    //[Header("Output")]
    private void Update()
    {
        movementPointText.text = rSO_MovementPoints.Value.ToString();
    }
}