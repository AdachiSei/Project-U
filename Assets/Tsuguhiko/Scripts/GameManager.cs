using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>メインゲームの処理を管理するスクリプト</summary>

public class GameManager : MonoBehaviour,IScoreManager
{

    [SerializeField, Header("ゲームタイマー")] float _gameTimer;

    [SerializeField, Header("現在のスコア")] int _currentScore;

    public int CurrentScore {get => _currentScore;  set => _currentScore = value; }

    static int _totalScore;
   
    public static int TotalScore { get => _totalScore; set => _totalScore = value; }

    [SerializeField, Header("タイマーテキスト")] Text _timerText;

    [SerializeField, Header("スコアテキスト")] Text _scoreText;

    void OnEnable()
    {
        _currentScore = _totalScore = 0;
    }
    void Start()
    {
        TotalScore = CurrentScore;
    }

    
    void Update()
    {

        _scoreText.text = TotalScore.ToString();
        _timerText.text = _gameTimer.ToString("F0");
        _gameTimer -= Time.deltaTime;
        InvokeRepeating(nameof(AddScore), 10.0f, 10.0f);
    }

    public void AddScore()
    {
        TotalScore += 10;
        CancelInvoke();
    }

    public void DecreaseScore()
    {
        TotalScore -= 10;
       // InvincibleMode();
    }

    

   //public void InvincibleMode()
   // {
        
   // }

}
