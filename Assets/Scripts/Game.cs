using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Slider _speed;
    [SerializeField] private Transform _wall;
    [SerializeField] private Plane _plain1; 
    [SerializeField] private Plane _plain2;

    [SerializeField] private Transform _player;

    
    void Start()
    {
        Vector3 value = new Vector3(Screen.width/2, Screen.height, 0f);
        Vector3 temp;
        temp.x = Camera.main.ScreenToWorldPoint(value).x;
        temp.y = 1f;
        temp.z = -Camera.main.ScreenToWorldPoint(value).z + _player.localScale.z / 2;
        _player.position = temp;       
        StartCoroutine(ExecuteAfterTime());
    }
    IEnumerator ExecuteAfterTime()
    {
        while (true)
        {
            Vector3 temp;
            if (_plain1.transform.position.z < _player.position.z - 10)
            {
                temp.x = _plain1.transform.position.x;
                temp.y = _plain1.transform.position.y;
                temp.z = _plain1.transform.position.z + 20;
                _plain1.transform.position = temp;

                CreateWall(true);
            }
            else if (_plain2.transform.position.z < _player.position.z - 10)
            {
                temp.x = _plain2.transform.position.x;
                temp.y = _plain2.transform.position.y;
                temp.z = _plain2.transform.position.z + 20;
                _plain2.transform.position = temp;

                CreateWall(false);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void CreateWall(bool plain)
    {
        Vector3 temp;
        temp.x = Random.Range(-1, 2);
        temp.y = 1f;
        temp.z = Random.Range(-1, 2);
        _wall.position = temp;
        if (plain)
        {         
            Instantiate(_wall, _plain1.transform);      
        }
        else
        {
            Instantiate(_wall, _plain2.transform);
        }
    }
}
