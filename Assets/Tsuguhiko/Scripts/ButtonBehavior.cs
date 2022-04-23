using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

/// <summary>ステージセレクト画面でのボタン動作スクリプト</summary>

public class ButtonBehavior : MonoBehaviour
{
    /// <summary>それぞれのボタンを設定する配列のメンバ変数</summary>
    [SerializeField, Header("ボタン各種")] Button[] _buttons;

    /// <summary>各デバイスのボタン操作のオンオフを切り換えるメンバ変数(このゲームではスマートフォン操作)</summary>
    [SerializeField,Header("Touch操作イベントシステム")] EventSystem _eventSystem;

    /// <summary>WaitforSecondsでの待機時間のメンバ変数</summary>
    [SerializeField, Header("シーン切り換え待機時間")] float _second;

    /// <summary>移動させるシーン名を設定するメンバ変数</summary>
    [SerializeField, Header("遷移シーン名")] string _sceneName;

    /// <summary>WaitforSecondsのメンバ変数</summary>
    WaitForSeconds _wfs;

    /// <summary>再生した時にWaitforSecondsをキャッシュさせるためのAwakeメソッド(メモリ削減のため)</summary>
    void Awake()
    {
        _wfs = new WaitForSeconds(_second);
    }

    public void LoadScene()
    {
        StartCoroutine(StandByTime());
    }

    IEnumerator StandByTime()
    {
        _eventSystem.enabled = false;

        yield return _wfs;

        SceneManager.LoadScene(_sceneName);

        _eventSystem.enabled = true;
    }
}
