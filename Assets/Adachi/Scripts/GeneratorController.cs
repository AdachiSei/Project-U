using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>使用するジェネレーターを切り替えるスクリプト</summary>

public class GeneratorController : MonoBehaviour
{
    //タイマー
    float _timer;
    ///タイムリミット
    float _timeLimit;
    /// <summary>最大のタイムリミット</summary>
    [SerializeField,Header("最大のタイムリミット")]float _maximumTimeLimit = 10f;
    /// <summary>最小のタイムリミット</summary>
    [SerializeField, Header("最小のタイムリミット")] float _minimumTimeLimit = 5f;
    /// <summary>ジェネレーター</summary>
    [SerializeField, Header("ジェネレーター")] List<GameObject> _generator = new List<GameObject>();
    /// <summary>待ち時間（黄色信号）</summary>
    [SerializeField, Header("待ち時間（黄色信号）")] float _waitTime = 2f;
    /// <summary>判定回数の制御</summary>
    const float _JUDGMENTTIME = 1 / 60;
    void OnEnable()
    {
        StartCoroutine(TrafficSignal());
    }

    void Update()
    {
        //タイマー
        _timer += Time.deltaTime;    
    }

    /// <summary>
    /// 信号機のようにジェネレーターを切り替える
    /// </summary>
    /// <returns></returns>
    IEnumerator TrafficSignal()
    {
        while (true)
        {
            //タイムリミットになったら
            if (_timer >= _timeLimit)
            {
                //片方のジェネレーターが存在していたら
                if (_generator[0].activeSelf)
                {
                    //非表示にする（赤信号）
                    _generator[0].SetActive(false);
                    //待機時間（黄色信号）
                    yield return new WaitForSeconds(_waitTime);
                    //表示する（青信号）
                    _generator[1].SetActive(true);
                }
                else
                {
                    //非表示にする（赤信号）
                    _generator[1].SetActive(false);
                    //待機時間（黄色信号）
                    yield return new WaitForSeconds(_waitTime);
                    //表示する（青信号）
                    _generator[0].SetActive(true);
                }
                //タイマーをリセット
                _timer = 0;
                //タイムリミットをランダムで決める
                _timeLimit = Random.Range(_minimumTimeLimit, _maximumTimeLimit);
            }
            yield return new WaitForSeconds(_JUDGMENTTIME);
        }      
    }
}
