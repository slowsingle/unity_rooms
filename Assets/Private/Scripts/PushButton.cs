using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class PushButton : BaseButton
{
    [SerializeField] private DoorController doorController;

    protected override void Start()
    {
        base.Start();
    }

    protected override void DoSomethingAsPushing()
    {
        base.DoSomethingAsPushing();

        if (isPush)
        {
            doorController.open();
        }
        else
        {
            doorController.close();
        }
    }

}
