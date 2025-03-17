using System.Collections;
using UnityEngine;
public class PowerUpManager : MonoBehaviour
{
    //[Header("Settings")]

    [Header("References")]
    [SerializeField] RSO_WallLevel rSO_WallLevel;
    [SerializeField] RSE_CallGhostItemTimer rSE_CallGhostItemTimer;
    //[Space(10)]
    // RSO
    // RSF
    // RSP

    //[Header("Input")]
    //[Header("Output")]
    private void OnEnable()
    {
        rSE_CallGhostItemTimer.action += StartGhostPowerUp;
    }
    private void OnDisable()
    {
        rSE_CallGhostItemTimer.action -= StartGhostPowerUp;
    }
    private void Awake()
    {
        rSO_WallLevel.Value.Clear();
    }
    private void Start()
    {
        GameObject[] collider = GameObject.FindGameObjectsWithTag("Wall");
        for (int i = 0;  i < collider.Length; i++)
        {
            rSO_WallLevel.Value.Add(collider[i].GetComponent<Collider>());
        }
       
    }
    private void StartGhostPowerUp(float ghostTime)
    {
        StartCoroutine(StartGhostTimer(ghostTime));
    }
    IEnumerator StartGhostTimer(float time)
    {
        for (int i = 0; i < rSO_WallLevel.Value.Count; i++)
        {
            rSO_WallLevel.Value[i].enabled = false;
        }
        yield return new WaitForSeconds(time);

        for (int i = 0; i < rSO_WallLevel.Value.Count; i++)
        {
            rSO_WallLevel.Value[i].enabled = true;
        }
    }
}