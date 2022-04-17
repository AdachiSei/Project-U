using System.Collections.Generic;
using UnityEngine;

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

    void Update()
    {
        //タイマー
        _timer += Time.deltaTime;
        //タイムリミットになったら
        if(_timer >= _timeLimit)
        {
            //片方のジェネレーターが存在していたら
            if(_generator[1].activeSelf)
            {
                //非表示にする
                _generator[1].SetActive(false);
                //表示する
                _generator[0].SetActive(true);
            }
            else
            {
                //非表示にする
                _generator[0].SetActive(false);
                //表示する
                _generator[1].SetActive(true);
            }
            //タイマーをリセット
            _timer = 0;
            //タイムリミットをランダムで決める
            _timeLimit = Random.Range(_minimumTimeLimit, _maximumTimeLimit);
        }
    }
}
