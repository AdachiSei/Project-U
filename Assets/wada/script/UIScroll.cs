using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScroll : MonoBehaviour
{
    [SerializeField] float _ScrollSpeed = 1;
    [SerializeField] float _scrollMinimum = 0f ;
    [SerializeField] float _scrollMax = 0f;
    [SerializeField] ScrollDirection _scrollDirection;
    RectTransform _rectTransform;
    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }
    void Update()
    {
        switch (_scrollDirection)
        {
            case ScrollDirection.Horizontal:
                _rectTransform.anchoredPosition -= new Vector2(Time.deltaTime * _ScrollSpeed, 0 );

                if (_rectTransform.anchoredPosition.x <= _scrollMinimum)
                {
                    _rectTransform.anchoredPosition = new Vector2(_scrollMax, 0);
                }
                break;
            case ScrollDirection.Vertical:
                _rectTransform.anchoredPosition -= new Vector2(0,Time.deltaTime * _ScrollSpeed);
                if (_rectTransform.anchoredPosition.y <= _scrollMinimum)
                {
                    _rectTransform.anchoredPosition = new Vector2(0, _scrollMax);
                }
                break;
        }
    }
    enum ScrollDirection
    {
        Horizontal,
        Vertical
    }
}
