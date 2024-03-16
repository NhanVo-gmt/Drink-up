using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class DrinkStation : MonoBehaviour
{
    private bool isPlayerInsideVolume; // Flag to check if the player is inside the DrinkStationVolume
    [SerializeField] public enum DrinkMenu
    {
        None,
        Milkshake,
        Smoothie,
        Beer,
        Cocktail
    }
    public DrinkMenu CurrentDrink = DrinkMenu.None; // Variable to store the currently selected item

    // Start is called before the first frame update
    void Start()
    {
        isPlayerInsideVolume = false;
      
    }

    Update is called once per frame
    void Update()
    {
        if (isPlayerInsideVolume)
        {
            SelectDrink();
        }
    }
    
    void SelectDrink()
    {
        // // Check for input to select items
        // if (Input.GetKeyDown(KeyCode.U))
        // {
        //     CurrentDrink = DrinkMenu.Milkshake;
        //    Debug.Log("Selected Drink: Milkshake");
        // }
        //
        // if (Input.GetKeyDown(KeyCode.I))
        // {
        //     CurrentDrink = DrinkMenu.Smoothie;
        //     Debug.Log("Selected Drink: Smoothie");
        // }
        //
        // if (Input.GetKeyDown(KeyCode.O))
        // {
        //     CurrentDrink = DrinkMenu.Beer;
        //     Debug.Log("Selected Drink: Beer");
        // }
        //
        // if (Input.GetKeyDown(KeyCode.P))
        // {
        //     CurrentDrink = DrinkMenu.Cocktail;
        //     Debug.Log("Selected Drink: Cocktail");
        // }

        if (Input.GetKeyDown(KeyCode.E))
        {
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DrinkStationVolume"))
        {
            isPlayerInsideVolume = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DrinkStationVolume"))
        {
            isPlayerInsideVolume = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DrinkStationVolume"))
        {
            isPlayerInsideVolume = false;
        }
    }
}


