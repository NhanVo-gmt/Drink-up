using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += -transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<DrinkMovement>())
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("CustomerEnd"))
        {
            LeaveQueue();
        }
    }

    void LeaveQueue()
    {
        
    }
}
