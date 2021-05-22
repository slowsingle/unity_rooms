using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class WarpPlane : MonoBehaviour
{
    [SerializeField] private WarpZone warpZone;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("warp " + gameObject.name);
            warpZone.Warp(gameObject.name);
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        warpZone.ActivateWarp();
    }
}
