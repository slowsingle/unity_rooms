using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof(Collider))]
public class BaseButton : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    protected bool isPush = false;
    protected bool isEnter = false;


    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected void Update()
    {
        if (isEnter && CrossPlatformInputManager.GetButtonDown("push"))
        {
            if (isPush)
            {
                // ボタンを押し戻す
                animator.SetBool("try_to_push", false);
                isPush = false;
            }
            else
            {
                // ボタンを押す
                animator.SetBool("try_to_push", true);
                isPush = true;
            }

            DoSomethingAsPushing();
            new WaitForSeconds(1);
        }
    }

    protected virtual void DoSomethingAsPushing()
    {
        // override if you need
    }

    protected void OnTriggerEnter(Collider other)
    {
        isEnter = true;
    }

    protected void OnTriggerExit(Collider other)
    {
        isEnter = false;
    }

}
