using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>メインゲームのスコアを管理するスクリプト(インターフェース)</summary>

public interface IScoreManager 
{
    int CurrentScore { get; set; }

    void AddScore();

    void DecreaseScore();
}
