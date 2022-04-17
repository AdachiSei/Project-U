using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    /// <summary>生成するもの</summary>
    [SerializeField,Header("生成するもの")] List<GameObject> _object = new List<GameObject>();
    /// <summary>オブジェクトの番号</summary>
    int _objectNumber;
    /// <summary>開始時間</summary>
    [SerializeField,Header("開始時間")]float _beginTime = 5f;
    /// <summary>オブジェクト生成の時間間隔</summary>
    float _intervalTime;
    /// <summary>オブジェクト生成の最短時間</summary>
    [SerializeField,Header("オブジェクト生成の最短時間")]float _maximumTime = 5f;
    /// <summary>オブジェクト生成の最長時間</summary>
    [SerializeField, Header("オブジェクト生成の最長時間")] float _minimumTime = 0.1f;
    /// <summary>上限（ｙの限界）</summary>
    [SerializeField,Header("上限（yの限界）")]float _upperLimit = 4f;
    /// <summary>下限（-ｙの限界）</summary>
    [SerializeField, Header("下限（-ｙの限界）")] float _downLimit = -4f;
    /// <summary>右限（xの限界）</summary>
    [SerializeField, Header("右限（xの限界）")] float _rightLimit = 10f;
    /// <summary>左限（-xの限界）</summary>
    [SerializeField, Header("左限（-xの限界）")] float _leftLimit = 10f;
    /// <summary>オブジェクトを生成する位置</summary>
    Vector3 _pos;
    /// <summary>判定回数の制御</summary>
    const float _JUDGMENTTIME = 1 / 60;

    void Start()
    {
        StartCoroutine(Generator());
    }

    IEnumerator Generator()
    {
        yield return new WaitForSeconds(_beginTime);
        Debug.Log("Start!");
        while(true)
        {
            //判定回数の制御
            yield return new WaitForSeconds(_JUDGMENTTIME);
            //生成するオブジェクトをランダムで決める
            _objectNumber = Random.Range(0, _object.Count);
            //生成する座標をランダムで決める
            _pos = new Vector3(Random.Range(_leftLimit, _rightLimit), Random.Range(_downLimit, _upperLimit), 0f);
            //生成頻度をランダムで決める
            _intervalTime = Random.Range(_minimumTime,_maximumTime);
            //生成する
            Instantiate(_object[_objectNumber],_pos, Quaternion.identity);
            //オブジェクト生成の時間間隔
            yield return new WaitForSeconds(_intervalTime);
        }       
    }
}
