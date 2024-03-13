using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    float speed = 5f;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        float moveVertical = Input.GetAxis("Vertical");

        transform.position += new Vector3(0, moveVertical, 0) * speed * Time.deltaTime;
    }
}
