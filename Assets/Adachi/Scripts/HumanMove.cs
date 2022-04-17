using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMove : MonoBehaviour
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
    /// <summary>人の移動方向の切り替え(trueなら左）</summary>
    [SerializeField, Header("人の移動方向の切り替え(trueなら左）")] bool _switch;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //スピードをランダムで決める
        _speed = Random.Range(_minimumSpeed,_maximumSpeed);
    }
    private void Update()
    {
        if (_switch)
        {
            //左に移動
            _rb.velocity = Vector2.left * _speed;
        }
        else
        {
            //下に移動
            _rb.velocity = Vector2.down * _speed;
        }
        //タイマー
        _timer += Time.deltaTime;

        /*//時間制限が来たら
        if(_timer >= _timeLimit)
        {
            //オブジェクトを消す
            Destroy(gameObject);
        }*/
         
    }
    void OnBecameInvisible()
    {
        //画面外に行ったら非アクティブにする
        gameObject.SetActive(false);
    }
}
