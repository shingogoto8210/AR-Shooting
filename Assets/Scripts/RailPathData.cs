using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailPathData : MonoBehaviour
{
    [SerializeField, Tooltip("移動時間")]
    private float[] railMoveDurations;

    [SerializeField, Tooltip("移動地点とカメラの角度")]
    private Transform[] pathTrans;

    public float[] GetRailMoveDurations()
    {
        return railMoveDurations;
    }

    public Transform[] GetPathTrans()
    {
        return pathTrans;
    }
}
