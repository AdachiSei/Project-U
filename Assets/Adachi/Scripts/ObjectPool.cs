using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    Transform _pool; //オブジェクトを保存する空オブジェクトのtransform
    /// <summary>enemyのタグ</summary>
    [SerializeField,Header("enemyのタグ")]string _enemyTag;
    void Start()
    {
        _pool = new GameObject(_enemyTag).transform;
    }

    void GetObject(GameObject obj, Vector3 pos, Quaternion qua)
    {
        foreach (Transform t in _pool)
        {
            //オブジェが非アクティブなら使い回し
            if (!t.gameObject.activeSelf)
            {
                t.SetPositionAndRotation(pos, qua);
                t.gameObject.SetActive(true);//位置と回転を設定後、アクティブにする
            }
        }
        //非アクティブなオブジェクトがないなら生成
        Instantiate(obj, pos, qua, _pool);//生成と同時にpoolを親に設定
    }
}
