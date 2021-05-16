using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class WarpPlayer : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    
    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Warp");
            playerController.SetForcedPosition(new Vector3(0, 0, -3));
        } 
    }
}
