using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    [SerializeField] Transform _border;
    private void Start()
    {
        Vector3 value = new Vector3(0f, 0f, 0f);

        float bottom, left, right, a;
        a = 0;//_scale / 2 + distance;
        bottom = Camera.main.ScreenToWorldPoint(value).y;
        left = right = Camera.main.ScreenToWorldPoint(value).x;
        right = -right;

        _border.localScale = new Vector3(1, 1, bottom * 2);
        _border.localPosition = new Vector3(left - a, 1f, 0f);
        _border.tag = "Left";
        Instantiate(_border, _border.localPosition, _border.rotation);

        _border.localPosition = new Vector3(right + a, 1f, 0f);
        _border.tag = "Right";
        Instantiate(_border, _border.localPosition, _border.rotation);

        _border.localScale = new Vector3(right * 2, 1, 1);
        _border.localPosition = new Vector3(0f, 1f, -bottom);
        _border.tag = "Bottom";
        Instantiate(_border, _border.localPosition, _border.rotation);
    }
}
