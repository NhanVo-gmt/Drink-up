using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Tilemaps;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private NPCBehaviour prefab;

    [SerializeField] private float spawnRate;

    private float spawnElapseTime;



    bool hasSpawned = false;
    private float randomNumber;

    private void Awake()
    {
        randomNumber = Random.Range(1.20f, 3.00f);
    }

    private void Update()
    {
        Spawn();
      Awake();
    }

    void Spawn()
    {

      
        spawnElapseTime += Time.deltaTime;
        if ((spawnElapseTime >= spawnRate) && !hasSpawned)
        {
             spawnElapseTime = 0;
            hasSpawned = true;
            Instantiate(prefab, transform.position, quaternion.identity);
        }

        if (hasSpawned && spawnElapseTime >= (spawnRate*randomNumber))
        {
            Instantiate(prefab, transform.position, quaternion.identity);
            spawnElapseTime = 0;
            hasSpawned = false;
        }
    }
}
