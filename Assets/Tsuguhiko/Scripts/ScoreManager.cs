using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>メインゲームのスコアを管理するスクリプト</summary>

public class ScoreManager : MonoBehaviour
{
   [SerializeField,Header("現在の難易度")] Difficulty _difficulty;

    int _initScore = 0;

    [SerializeField,Header("現在のスコア")]int _currentScore;

    public int CurrentScore 
    { get 
        { 
            return _currentScore;
        }
        set
        {
            _currentScore = value;
        }
    }

    static int _totalScore = 0;

    public static int TotalScore
    {
        get
        {
            return _totalScore;
        }
        set
        {
            _totalScore = value;
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
