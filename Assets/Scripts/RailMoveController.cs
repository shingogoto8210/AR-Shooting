using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RailMoveController : MonoBehaviour
{
    public GameMaster gameMaster;
    [SerializeField]
    private Transform railMoveTarget;
    //レールを移動させる対象。AR用のカメラを指定
    //DOTweenはTransform型

    [SerializeField]
    private RailPathData currentRailPathData;
    //PathSetsをアサイン

    private Tween tween;

    public bool isLast;
    
    //DOTweenを動かすクラス
    //DOTweenを一時停止，再開の処理ができる

    /// <summary>
    /// レール移動の開始
    /// </summary>
    /// <returns></returns>
    public void Move()
    {
        //移動する地点を取得するための配列の初期化 ※箱を準備
        Vector3[] paths = new Vector3[currentRailPathData.GetPathTrans().Length];
        
        float totalTime = 0;

        //移動する位置情報と時間を順番に配列に取得
        for(int i=0; i < currentRailPathData.GetPathTrans().Length; i++)
        {
            paths[i] = currentRailPathData.GetPathTrans()[i].position;
            totalTime += currentRailPathData.GetRailMoveDurations()[i];
        }
        //メソッドチェーン
        //Linear 一定速度
        //ラムダ式　引数　＝＞　左の引数を受けてメソッド実行　※即席メソッド（スコープが短い）
        //＝＞　メソッドが隠れている　右側のメソッドを呼び出す
        //DOPath(Vector3[],ゴールまでの時間)

            tween = railMoveTarget.DOPath(paths, totalTime).SetEase(Ease.Linear).OnWaypointChange((waypointIndex) => CheckArrivalDestination(waypointIndex));
            Debug.Log("移動開始");
        
    }

    private void CheckArrivalDestination(int waypointIndex)
    {
        Debug.Log("目標地点　到着　：" + waypointIndex + "番目");
        PauseMove();
        gameMaster.currentGameState = GameState.プレイ中;
        Debug.Log(gameMaster.currentGameState);
        if (waypointIndex == currentRailPathData.GetPathTrans().Length - 1)
        {
            isLast = true;
        }
        Debug.Log(isLast);
        //TODO　射的ゲームが開始するか判定
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
