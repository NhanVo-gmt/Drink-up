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

    public Player player = null;
    
    // Start is called before the first frame update
    void Start()
    {
        isPlayerInsideVolume = false;
      
    }

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
        //     CurrentDrink = DrinkStation.Milkshake;
        //    Debug.Log("Selected Drink: Milkshake");
        // }
        //
        // if (Input.GetKeyDown(KeyCode.I))
        // {
        //     CurrentDrink = DrinkStation.Smoothie;
        //     Debug.Log("Selected Drink: Smoothie");
        // }
        //
        // if (Input.GetKeyDown(KeyCode.O))
        // {
        //     CurrentDrink = DrinkStation.Beer;
        //     Debug.Log("Selected Drink: Beer");
        // }
        //
        // if (Input.GetKeyDown(KeyCode.P))
        // {
        //     CurrentDrink = DrinkStation.Cocktail;
        //     Debug.Log("Selected Drink: Cocktail");
        // }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.drinkStation = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // if (collision.GetComponent<Player>())
        // {
        //     this.player = null;
        // }
    }
}


