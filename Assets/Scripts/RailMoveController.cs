using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RailMoveController : MonoBehaviour
{
    public GameMaster gameMaster;
    [SerializeField]
    private Transform railMoveTarget;
    //���[�����ړ�������ΏہBAR�p�̃J�������w��
    //DOTween��Transform�^

    [SerializeField]
    private RailPathData currentRailPathData;
    //PathSets���A�T�C��

    private Tween tween;

    public bool isLast;
    
    //DOTween�𓮂����N���X
    //DOTween���ꎞ��~�C�ĊJ�̏������ł���

    /// <summary>
    /// ���[���ړ��̊J�n
    /// </summary>
    /// <returns></returns>
    public void Move()
    {
        //�ړ�����n�_���擾���邽�߂̔z��̏����� ����������
        Vector3[] paths = new Vector3[currentRailPathData.GetPathTrans().Length];
        
        float totalTime = 0;

        //�ړ�����ʒu���Ǝ��Ԃ����Ԃɔz��Ɏ擾
        for(int i=0; i < currentRailPathData.GetPathTrans().Length; i++)
        {
            paths[i] = currentRailPathData.GetPathTrans()[i].position;
            totalTime += currentRailPathData.GetRailMoveDurations()[i];
        }
        //���\�b�h�`�F�[��
        //Linear ��葬�x
        //�����_���@�����@�����@���̈������󂯂ă��\�b�h���s�@�����ȃ��\�b�h�i�X�R�[�v���Z���j
        //�����@���\�b�h���B��Ă���@�E���̃��\�b�h���Ăяo��
        //DOPath(Vector3[],�S�[���܂ł̎���)

            tween = railMoveTarget.DOPath(paths, totalTime).SetEase(Ease.Linear).OnWaypointChange((waypointIndex) => CheckArrivalDestination(waypointIndex));
            Debug.Log("�ړ��J�n");
        
    }

    private void CheckArrivalDestination(int waypointIndex)
    {
        Debug.Log("�ڕW�n�_�@�����@�F" + waypointIndex + "�Ԗ�");
        PauseMove();
        gameMaster.currentGameState = GameState.�v���C��;
        Debug.Log(gameMaster.currentGameState);
        if (waypointIndex == currentRailPathData.GetPathTrans().Length - 1)
        {
            isLast = true;
        }
        Debug.Log(isLast);
        //TODO�@�˓I�Q�[�����J�n���邩����
    }

    public void PauseMove()
    {
        tween.Pause();
    }

    public void ResumeMove()
    { 
            tween.Play();
    }
}
