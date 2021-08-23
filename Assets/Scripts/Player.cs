using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Player : MonoBehaviour
{
    [SerializeField] HP _HP;
    [SerializeField, Range(20f, 100f)] private int _moveSpeed;

    Action WallHit;
    Action BorderHit;

    private float time_delay = 0.1f;
    private float time;
    private float move_border_x;

    private float _x;
    bool enableMove = false;

    private float _moveSpeedPlayer;
    public void MovePlayer()
    {
        int value = 0;
        if (_x > Screen.width / 2)
        {
            value = 1;           
        }
        else
        {
            value = -1;            
        }
        Vector3 move;
        float MoveSpeed = _moveSpeedPlayer;
        move.x = transform.position.x + value * Time.deltaTime * MoveSpeed;
        move.y = transform.position.y;
        move.z = transform.position.z;

        move.x = Mathf.Clamp(move.x, -move_border_x, move_border_x);
        transform.position = move;
    }

    public void InitializeUpdate(float x)
    {
        _x = x;
        enableMove = true;
    }

    public void DisableMove()
    {
        enableMove = false;
    }

    void OnDestroy()
    {
        WallHit -= _HP.ChangeWallHit;
        BorderHit -= _HP.ChangeBorderHit;
    }

    private void Start()
    {
        _moveSpeedPlayer = (float)_moveSpeed / 10;
        Vector3 value = new Vector3(transform.localScale.x, transform.localScale.y, 0f);
        move_border_x = -(Camera.main.ScreenToWorldPoint(value).x + 0.5f + transform.localScale.x / 2);

        WallHit += _HP.ChangeWallHit;
        BorderHit += _HP.ChangeBorderHit;

    }

    private void Update()
    {
        if (enableMove)
        {
            MovePlayer();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        time = 0;
        if (other.tag == "Wall")
        {
            WallHit?.Invoke();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(time < time_delay)
        {
            time += Time.deltaTime;
        }
        else
        {
            time -= time_delay;
            BorderHit?.Invoke();
        }
    }
}
