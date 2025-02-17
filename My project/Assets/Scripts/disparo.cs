using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    private Rigidbody2D rigibody;
    public float speed = 2f;

    void Start()
    {
        rigibody = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        rigibody.velocity = transform.right * speed;
    }
}
