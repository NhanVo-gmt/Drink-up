using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayShatterSound : MonoBehaviour
{
     private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GameObject.FindGameObjectWithTag("Barrier").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Milkshake")|| other.CompareTag("Smoothie")|| other.CompareTag("Beer")|| other.CompareTag("Cocktail"))
        {
           
            source.Play();
        }
    }
}
