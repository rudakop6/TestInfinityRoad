using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;
public class Panel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{ 
    [SerializeField] private Player _player;
    Action<float> _mousePosition;
    Action pointerUp;
    public void OnPointerDown(PointerEventData data)
    {
        _mousePosition ?.Invoke(Input.mousePosition.x);
    }
    public void OnPointerUp(PointerEventData data)
    {
        pointerUp ?.Invoke();
    }

    void Start()
    {
        _mousePosition += _player.InitializeUpdate;
        pointerUp += _player.DisableMove;
    }
    void OnDestroy()
    {
        _mousePosition -= _player.InitializeUpdate;
        pointerUp -= _player.DisableMove;
    }
}
