using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailPathData : MonoBehaviour
{
    [SerializeField, Tooltip("�ړ�����")]
    private float[] railMoveDurations;

    [SerializeField, Tooltip("�ړ��n�_�ƃJ�����̊p�x")]
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
