using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HP : MonoBehaviour
{
    [SerializeField] private Text _HitPointsText;
    [SerializeField, Range(1, 40)] private int _StartHP;
    [SerializeField] private Slider _HitPoints;
    private float CountHP { get; set; }

    private void Awake()
    {
        CountHP = _StartHP;
        _HitPointsText.text = CountHP.ToString();
    }

    public void ChangeWallHit()
    {
        CountHP--;
        _HitPointsText.text = Mathf.Round(CountHP).ToString();
        _HitPoints.value -= 1f / _StartHP;
    }
    public void ChangeBorderHit()
    {
        CountHP -= 0.1f;
        _HitPointsText.text = Mathf.Round(CountHP).ToString();
        _HitPoints.value -= 0.1f / _StartHP;
    }
}
