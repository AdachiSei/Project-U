using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>救急車を移動させるスクリプト(横移動のみ)</summary> ///

public class ResqueCarMove : MonoBehaviour
{
    GameManager _gameManager => GetComponent<GameManager>();

    /// <summary>救急車のRigidBody2Dのメンバ変数</summary>
    Rigidbody2D _rb2d ;

    /// <summary>救急車の横操作のメンバ変数</summary>
    float _xInput;

    /// <summary>救急車のスピードのメンバ変数</summary>
    float _speed;

    /// <summary>救急車の横操作の移動量のメンバ変数</summary>
    [SerializeField,Header("横操作の移動量")] float _inputSpeed;

    /// <summary>
    ///  救急車の横操作に必要なコンポーネントを取得する
    /// </summary>
    void Start()
    {
        
        _rb2d = GetComponent<Rigidbody2D>(); // 救急車のRigidBody2Dを取得 (救急車の操作に必要)
    }

    /// <summary>
    /// 救急車の横操作入力をUpdateで取得
    /// </summary>
    void Update()
    {
        _xInput = Input.GetAxis("Horizontal"); // 救急車の横操作の入力を取得 (左右の矢印キー、AとDで操作できる(スマホ操作はビルド時に再考))
    }

    /// <summary>
    /// 横操作の量と移動量、救急車の向きの調整を更新
    /// </summary>
    void FixedUpdate()
    {
        
        if (_xInput == 0) // 何も操作してないとき
        {
            _speed = 0; // 救急車のスピードを0にする
        }
        else if (_xInput > 0) //右移動操作のとき
        {
            _speed = _inputSpeed; // 救急車のスピードを入力した方向に加える

            transform.localScale = new Vector3(1, -1, 1); // 救急車の向きを右にする
        }
        else if (_xInput < 0) //左移動操作のとき
        {
            _speed = _inputSpeed * -1; // 救急車のスピードを入力した方向とは逆の方に加える

            transform.localScale = new Vector3(1, 1, 1); // 救急車の向きを左にする
        }
        
        _rb2d.velocity = new Vector2(_speed, _rb2d.velocity.y); // 救急車を移動 Vextor2(x軸スピード、y軸スピード(元のまま))
    }


    void OnTriggerEnter2D(Collider2D col2D)
    {
        _gameManager.DecreaseScore();
    }
}
