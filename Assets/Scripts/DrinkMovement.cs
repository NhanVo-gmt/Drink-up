using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkMovement : MonoBehaviour
{
    [SerializeField]
    Transform startPos;
    [SerializeField]
    Transform endPos;

    float speed = 1.0f;
    bool shouldMove = false;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos.position;
        shouldMove = true; // Start moving immediately
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, endPos.position, step);

            // Check if the object has reached the end position
            if (Vector3.Distance(transform.position, endPos.position) < 0.001f)
            {
              shouldMove = false;
            }
        }
    }
}
