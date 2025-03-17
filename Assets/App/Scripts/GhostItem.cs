using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GhostItem : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float ghostTime;

    [Header("References")]
    [SerializeField] RSE_CallGhostItemTimer rSE_CallGhostItemTimer;
    

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
            rSE_CallGhostItemTimer.Call(ghostTime);
            gameObject.SetActive(false);
        }
    }
   
}