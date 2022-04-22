using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

/// <summary>ステージセレクト画面でのボタン動作スクリプト</summary>

public class ButtonBehavior : MonoBehaviour
{
    [SerializeField, Header("ボタン各種")] Button[] _buttons;

    [SerializeField,Header("Touch操作イベントシステム")] EventSystem _eventSystem;

    [SerializeField, Header("シーン切り換え待機時間")] float _second;

    [SerializeField, Header("遷移シーン名")] string _sceneName;

    WaitForSeconds _wfs;


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
