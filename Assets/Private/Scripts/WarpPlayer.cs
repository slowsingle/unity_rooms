using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class WarpPlayer : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Transform warpDestination;
    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Warp");
            playerController.SetForcedPosition(warpDestination.position);
            //Debug.Log(warpDestination.position);
        } 
    }
}
