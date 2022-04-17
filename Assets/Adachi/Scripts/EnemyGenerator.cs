using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    /// <summary></summary>
    [SerializeField,Header("生成するもの")] List<GameObject> _object = new List<GameObject>();
    /// <summary>オブジェクトの番号</summary>
    int _objectNumber;
    /// <summary>オブジェクトを生成する時間間隔</summary>
    float _intervalTime;
    /// <summary>オブジェクトを生成する位置</summary>
    Vector3 _pos;

    void Start()
    {
        StartCoroutine(Generator());
    }

    void Update()
    {
        
    }


    IEnumerator Generator()
    {
        while(true)
        {
            _objectNumber = Random.Range(0, _object.Count);
            _pos = new Vector3(Random.Range(0f, 5f), Random.Range(0f, 5f), 0f);
            _intervalTime = Random.Range(0.1f,3f);
            Instantiate(_object[0],_pos, Quaternion.identity);
            yield return new WaitForSeconds(_intervalTime);
        }       
    }
}
