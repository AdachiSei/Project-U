using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    //タイマー
    float _timer;
    ///タイムリミット
    float _timeLimit;
    /// <summary>ジェネレーター</summary>
    [SerializeField, Header("ジェネレーター")] List<GameObject> _generator = new List<GameObject>();

    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer >= _timeLimit)
        {
            if(_generator[1].activeSelf)
            {
                _generator[1].SetActive(false);
                _generator[0].SetActive(true);
            }
            else
            {
                _generator[0].SetActive(false);
                _generator[1].SetActive(true);
            }
            _timer = 0;
            _timeLimit = Random.Range(5f, 10f);
        }
    }
}
