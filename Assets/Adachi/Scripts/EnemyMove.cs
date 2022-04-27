using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    int _number;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _timer = 0f;
        //スピードをランダムで決める
        _speed = Random.Range(_minimumSpeed, _maximumSpeed);
    }

    private void Update()
    {
        //enemyの見た目を変える
        if (_timer == 0)
        {
            _number = Random.Range(0, _enemySprite.Count);
            _sprite.sprite = _enemySprite[_number];
            //アニメーションがあったら変える
            if (_animator != null)
            {
                _animator.runtimeAnimatorController = _enemyAnim[_number];
                //移動速度によってアニメーションのスピードを変える
                _animator.speed = _speed / _animSpeedOffset;
            }            
        }
        
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
