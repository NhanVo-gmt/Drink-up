using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private NPCBehaviour prefab;

    [SerializeField] private float spawnRate;

    private float spawnElapseTime;

    private void Awake()
    {
        
    }

    private void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        spawnElapseTime += Time.deltaTime;
        if (spawnElapseTime >= spawnRate)
        {
            spawnElapseTime = 0;

            Instantiate(prefab, transform.position, quaternion.identity);
        }
    }
}
