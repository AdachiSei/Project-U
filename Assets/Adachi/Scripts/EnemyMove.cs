using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    /// <summary>剛体</summary>
    Rigidbody2D _rb;
    /// <summary>移動方向移動方向(trueならスプライトの下方向）</summary>
    [SerializeField,Header("移動方向(trueならスプライトの下方向）")]bool _dir = true;
    /// <summary>enemyのスピード</summary>
     float _speed;
    /// <summary>最大スピード</summary>
    [SerializeField, Header("最大スピード")] float _maximumSpeed = 10f;
    /// <summary>最小スピード</summary>
    [SerializeField, Header("最小スピード")] float _minimumSpeed = 2f;
    /// <summary>タイマー</summary>
    float _timer;
    /// <summary>タイムリミット</summary>
    float _timeLimit = 10f;
    /// <summary>アニメーションのスピードを補正する</summary>
    [SerializeField,Header("アニメーションのスピードを補正する（_speed / _animSpeedOffset）")]float _animSpeedOffset = 10f;
    /// <summary>アニメーター</summary>
    Animator _animator;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _timer = 0f;     
        //スピードをランダムで決める
        _speed = Random.Range(_minimumSpeed,_maximumSpeed);
    }

    private void Update()
    {     
        //移動速度によってアニメーションのスピードを変える
        if(_animator != null)_animator.speed = _speed / _animSpeedOffset;

        //移動
        if(_dir)
        {           
            _rb.velocity = gameObject.transform.rotation * new Vector3(0, -_speed, 0);
        }
        else
        {
            _rb.velocity = gameObject.transform.rotation * new Vector3(0, _speed, 0);
        }

        //タイマー
        _timer += Time.deltaTime;
        //時間制限が来たら非アクティブにする
        if (_timer >= _timeLimit)gameObject.SetActive(false);
    }
}
