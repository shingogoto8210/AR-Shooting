using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RailMoveController : MonoBehaviour
{
    [SerializeField]
    private Transform railMoveTarget;
    //DOTween��Transform�^

    [SerializeField]
    private RailPathData currentRailPathData;
    //PathSets���A�T�C��

    private Tween tween;
    //DOTween�𓮂����N���X
    //DOTween���ꎞ��~�C�ĊJ�̏������ł���

    void Start()
    {
        StartCoroutine(StartRailMove());    
    }

    public IEnumerator StartRailMove()
    {
        yield return null;
        //1�t���[���҂�

        Vector3[] paths = new Vector3[currentRailPathData.GetPathTrans().Length];
        float totalTime = 0;

        for(int i=0; i < currentRailPathData.GetPathTrans().Length; i++)
        {
            paths[i] = currentRailPathData.GetPathTrans()[i].position;
            totalTime += currentRailPathData.GetRailMoveDurations()[i];
        }
        //���\�b�h�`�F�[��
        //Linear ��葬�x
        //�����_���@�����@�����@���̈������󂯂ă��\�b�h���s�@�����ȃ��\�b�h�i�X�R�[�v���Z���j
        //�����@���\�b�h���B��Ă���@�E���̃��\�b�h���Ăяo��
        tween = railMoveTarget.DOPath(paths, totalTime).SetEase(Ease.Linear).OnWaypointChange((waypointIndex) => CheckArrivalDestination(waypointIndex));
        Debug.Log("�ړ�����");
    }

    private void CheckArrivalDestination(int waypointIndex)
    {
        Debug.Log("�ڕW�n�_�@�����@�F" + waypointIndex + "�Ԗ�");
    }
}
