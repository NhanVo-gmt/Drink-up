using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class DrinkStationScript : MonoBehaviour
{
    [SerializeField] public bool isPlayerInsideVolume; // Flag to check if the player is inside the DrinkStationVolume


    // Start is called before the first frame update
    void Start()
    {
        isPlayerInsideVolume = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInsideVolume)
        {
            SelectDrink();
        }
    }

    void SelectDrink()
    {
        // Check for input to select items
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Select item 1

            Debug.Log("Selected Drink: Milkshake");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Select item 2

            Debug.Log("Selected Drink: Smoothie");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // Select item 3

            Debug.Log("Selected Drink: Beer");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            // Select item 4
            Debug.Log("Selected Drink: Cocktail");
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            isPlayerInsideVolume = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isPlayerInsideVolume = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
            isPlayerInsideVolume = false;
    }
}


