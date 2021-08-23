using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plane : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    [SerializeField] Slider _speed;
    private void Awake()
    {
        //rb.AddForce(-this.transform.forward * _speed.value);
    }

    void FixedUpdate()
    {
        rb.velocity = -this.transform.forward * _speed.value;
    }
}
