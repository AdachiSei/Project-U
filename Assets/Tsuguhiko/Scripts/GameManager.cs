using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>メインゲームの処理を管理するスクリプト</summary>

public class GameManager : MonoBehaviour,IScoreManager
{
    /// <summary>救急車のアニメーターのメンバ変数</summary>
    [SerializeField] Animator _animator;
    /// <summary>ゲームの制限時間のメンバ変数</summary>
    [SerializeField, Header("ゲームタイマー")] float _gameTimer;
    /// <summary>現在のスコアのメンバ変数</summary>
    [SerializeField, Header("現在のスコア")] int _currentScore;
    /// <summary>_currentScoreのプロパティ</summary>
    public int CurrentScore {get => _currentScore;  set => _currentScore = value; }
    /// <summary>リザルト時のトータルスコアのメンバ変数</summary>
    static int _totalScore;
    /// <summary>_totalScoreのプロパティ</summary>
    public static int TotalScore { get => _totalScore; set => _totalScore = value; }
    /// <summary>タイマーテキストのメンバ変数</summary>
    [SerializeField, Header("タイマーテキスト")] Text _timerText;
    /// <summary>スコアテキストのメンバ変数</summary>
    [SerializeField, Header("スコアテキスト")] Text _scoreText;

    /// <summary>
    /// Animatorの取得と現在のスコアのリセット
    /// </summary>
    void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _currentScore = _totalScore = 0;
    }
    /// <summary>
    /// ゲーム開始時にトータルスコアと現在のスコアを同じにする
    /// </summary>
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
       InvincibleMode();
    }

    
   /// <summary>
   /// 敵に当たった時数秒だけ無敵モードになる。
   /// </summary>
   public void InvincibleMode()
   {
        _animator.SetTrigger("Ambulance");
   }

}
