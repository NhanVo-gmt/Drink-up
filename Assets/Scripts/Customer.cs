using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField]
    GameObject milkshake;
    [SerializeField]
    GameObject beer;
    [SerializeField] 
    GameObject smoothie;
    [SerializeField] 
    GameObject cocktail;
    string[] drinks = { "Milkshake", "Beer", "Smoothie", "Cocktail" };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey("I"))
        {
            //milkshake
        }

        if (Input.GetKey("J"))
        {
            //beer
        }

        if (Input.GetKey("K"))
        {
            //smoothie
        }

        if (Input.GetKey("L"))
        {
            //cocktail
        }
    }

    void OnCollision2D(Collision2D col)
    {
        if (col.gameObject = )
    }
}
