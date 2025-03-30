using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int collectibleQuantity;

    [Header("References")]
    [SerializeField] private List<Transform> collectiblesSpawnPoints;
    [SerializeField] private GameObject collectible;
    [SerializeField] RSO_WallLevel rSO_WallLevel;
    [SerializeField] RSE_CallGhostItemTimer rSE_CallGhostItemTimer;

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
        if(rSO_WallLevel.Value != null) rSO_WallLevel.Value.Clear();
        else rSO_WallLevel.Value = new List<Collider>();
    }
    private void Start()
    {
        GameObject[] wallColliders = GameObject.FindGameObjectsWithTag("Wall");
        for (int i = 0;  i < wallColliders.Length; i++)
        {
            rSO_WallLevel.Value.Add(wallColliders[i].GetComponent<Collider>());
        }

        for(int i = 0; i < collectibleQuantity; i++)
        {
            int index = Random.Range(0, collectibleQuantity);
            Instantiate(collectible, collectiblesSpawnPoints[index]);
            collectiblesSpawnPoints.RemoveAt(index);
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