using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>enemyを動かすスクリプト</summary>

public class EnemyMove : MonoBehaviour
{
    /// <summary>剛体</summary>
    Rigidbody2D _rb;
    /// <summary>enemyの絵</summary>
    [SerializeField, Header("enemyの絵")] List<Sprite> _enemySprite = new List<Sprite>();
    /// <summary>enemyのアニメーター</summary>
    [SerializeField,Header("enemyのアニメーター")]List<RuntimeAnimatorController> _enemyAnim = new List<RuntimeAnimatorController>();
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
    /// <summary>スプライトレンダラー</summary>
    SpriteRenderer _sprite;
    /// <summary>ランダムな数字が入る</summary>
    int _number;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        EnemySprite();
    }

    private void OnEnable()
    {
        _timer = 0f;       
        _speed = Random.Range(_minimumSpeed, _maximumSpeed);//スピードをランダムで決める
        EnemySprite();
    }

    private void OnBecameInvisible()
    {
        //画面外に行ったら非アクティブにする
        gameObject.SetActive(false);
    }

    private void Update()
    {   
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
    }

    /// <summary>//enemyの見た目とアニメーションを変える</summary>
    void EnemySprite()
    {
        //enemyの見た目を変える
        _number = Random.Range(0, _enemySprite.Count);
        _sprite.sprite = _enemySprite[_number];//不具合

        //アニメーションがあったら
        if (_animator != null)
        {
            //アニメーションを変える
            _animator.runtimeAnimatorController = _enemyAnim[_number];
            //移動速度によってアニメーションのスピードを変える
            _animator.speed = _speed / _animSpeedOffset;
        }
    }
}
