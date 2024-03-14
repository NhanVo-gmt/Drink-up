using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkMovement : MonoBehaviour
{
    [SerializeField] float speed = 3.0f;

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    
    void Move()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DrinkEnd"))
        {
            Broken();
        }
        
    }

    void Broken()
    {
        //todo
    }
}
