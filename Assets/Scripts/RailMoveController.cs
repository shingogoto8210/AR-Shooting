using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RailMoveController : MonoBehaviour
{
    [SerializeField]
    private Transform railMoveTarget;
    //DOTweenはTransform型

    [SerializeField]
    private RailPathData currentRailPathData;
    //PathSetsをアサイン

    private Tween tween;
    //DOTweenを動かすクラス
    //DOTweenを一時停止，再開の処理ができる

    void Start()
    {
        StartCoroutine(StartRailMove());    
    }

    public IEnumerator StartRailMove()
    {
        yield return null;
        //1フレーム待つ

        Vector3[] paths = new Vector3[currentRailPathData.GetPathTrans().Length];
        float totalTime = 0;

        for(int i=0; i < currentRailPathData.GetPathTrans().Length; i++)
        {
            paths[i] = currentRailPathData.GetPathTrans()[i].position;
            totalTime += currentRailPathData.GetRailMoveDurations()[i];
        }
        //メソッドチェーン
        //Linear 一定速度
        //ラムダ式　引数　＝＞　左の引数を受けてメソッド実行　※即席メソッド（スコープが短い）
        //＝＞　メソッドが隠れている　右側のメソッドを呼び出す
        tween = railMoveTarget.DOPath(paths, totalTime).SetEase(Ease.Linear).OnWaypointChange((waypointIndex) => CheckArrivalDestination(waypointIndex));
        Debug.Log("移動時間");
    }

    private void CheckArrivalDestination(int waypointIndex)
    {
        Debug.Log("目標地点　到着　：" + waypointIndex + "番目");
    }
}
