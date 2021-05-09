using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof(Collider))]
public class PushButton : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private DoorController doorController;
    private bool isPush = false;
    private bool isEnter = false;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        //StartCoroutine(ButtonPushAndBack());
    }


    private void Update()
    {
        if (isEnter && CrossPlatformInputManager.GetButtonDown("push"))
        {
            if (isPush)
            {
                animator.SetBool("try_to_push", false);
                doorController.close();
                isPush = false;
            }
            else
            {
                animator.SetBool("try_to_push", true);
                doorController.open();
                isPush = true;
            }
            new WaitForSeconds(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        isEnter = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        isEnter = false;
    }

}
