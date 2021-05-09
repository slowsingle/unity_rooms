using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool coroutineOpenAndClose;
    private bool isOpen = false;
    private bool isNearbyPlayer = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (coroutineOpenAndClose) StartCoroutine(DoorOpenAndClose());
    }

    private IEnumerator DoorOpenAndClose()
    {
        while (true)
        {
            if (isNearbyPlayer)
            {
                isOpen = true;
            }
            else
            {
                if (isOpen)
                {
                    animator.SetBool("character_nearby", false);
                    isOpen = false;
                }
                else
                {
                    animator.SetBool("character_nearby", true);
                    isOpen = true;
                }
            }
            yield return new WaitForSeconds(3);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isNearbyPlayer = true;
            open();
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isNearbyPlayer = false;
            close();
        }
    }


    public void open()
    {
        isOpen = true;
        animator.SetBool("character_nearby", true);
    }


    public void close()
    {
        isOpen = false;
        animator.SetBool("character_nearby", false);
    }
}
