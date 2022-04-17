using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    /// <summary>剛体</summary>
    Rigidbody2D _rb;
    /// <summary>人のスピード</summary>
     float _speed;
    /// <summary>最大スピード</summary>
    [SerializeField, Header("最大スピード")] float _maximumSpeed = 10f;
    /// <summary>最小スピード</summary>
    [SerializeField, Header("最小スピード")] float _minimumSpeed = 2f;
    /// <summary>タイマー</summary>
    float _timer;
    /// <summary>タイムリミット</summary>
    float _timeLimit = 10f;

    private void OnEnable()
    {
        _timer = 0f;
        _rb = GetComponent<Rigidbody2D>();
        //スピードをランダムで決める
        _speed = Random.Range(_minimumSpeed,_maximumSpeed);
    }
    private void Update()
    {
        //移動
        _rb.velocity = gameObject.transform.rotation * new Vector3(0, -_speed, 0);
        //タイマー
        _timer += Time.deltaTime;

        //時間制限が来たら
        if (_timer >= _timeLimit)
        {
            //非アクティブにする
            gameObject.SetActive(false);
        }
    }
}
