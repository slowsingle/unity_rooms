using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpZone : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private List<GameObject> warpPlaneList;
    [SerializeField] private List<int> destinationList;

    private bool isWarpActive = true;

    private void Start()
    {
        if (warpPlaneList.Count != destinationList.Count)
        {
            Debug.LogError("warpPlaneList or destinationList is wrong!!!");
        }
    }

    public void Warp(string objName)
    {
        /*
            どこかのワープ板の衝突判定が動作したときに呼ばれる関数
            現在踏んでいるワープ板に対応する、移動先のワープ板の座標を取得し、そこにキャラクターを移動させる
        */

        if (!isWarpActive) return;

        int i_obj = -1;
        for (int i = 0; i < warpPlaneList.Count; i++)
        {
            if (warpPlaneList[i].name == objName)
            {
                i_obj = i;
                break;
            }
        }

        if (i_obj == -1)
        {
            Debug.LogError("Not found index of warpPlane");
            return;
        }

        // ワープ先での衝突判定による、ワープの無限ループを防ぐために非アクティブ化する
        isWarpActive = false;

        int toWarpIndex = destinationList[i_obj];
        Transform destination = warpPlaneList[toWarpIndex].GetComponent<Transform>();
        playerController.SetForcedPosition(destination.position);
    }


    public void ActivateWarp()
    {
        isWarpActive = true;
    }
}
