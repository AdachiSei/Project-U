using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScroll : MonoBehaviour
{
    [SerializeField] float _ScrollSpeed = 1;
    RectTransform _rectTransform;
    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }
    void Update()
    {
        _rectTransform.anchoredPosition -= new Vector2(Time.deltaTime * _ScrollSpeed, 0 );

        if (_rectTransform.anchoredPosition.x <= - 1920f)
        {
            _rectTransform.anchoredPosition = new Vector2(2210f, 0);
        }
    }
}
