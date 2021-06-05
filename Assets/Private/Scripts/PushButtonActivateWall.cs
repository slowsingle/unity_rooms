using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButtonActivateWall : BaseButton
{
    [SerializeField] private GameObject gameObj;
    [SerializeField] private bool inverse;

    protected override void Start()
    {
        base.Start();
    }

    protected override void DoSomethingAsPushing()
    {
        base.DoSomethingAsPushing();

        bool doActivate = inverse ? !isPush : isPush;
        gameObj.SetActive(doActivate);
    }
}
