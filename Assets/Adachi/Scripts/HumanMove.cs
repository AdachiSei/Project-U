using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMove : MonoBehaviour
{
    /// <summary>剛体</summary>
    Rigidbody2D _rb;
    /// <summary>人のスピード</summary>
    [SerializeField, Header("")] float _speed;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.left;   
    }
}
