using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float step = 2f;
    [SerializeField] private DrinkMovement prefab;
    [SerializeField] private Transform spawnDrinkPos;

    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += Vector3.up * step;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += Vector3.down * step;
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab, spawnDrinkPos.position, Quaternion.identity);
        }
    }
}
