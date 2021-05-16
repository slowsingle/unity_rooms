using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaHandler : MonoBehaviour
{
    [SerializeField] private doorOpenPanel doorOpenPanel;
    
    private void Start()
    {
        doorOpenPanel.activate(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            doorOpenPanel.activate(true);
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            doorOpenPanel.activate(false);
        }
    }
}
