using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class DrinkStationScript : MonoBehaviour
{
    [SerializeField] public bool isPlayerInsideVolume; // Flag to check if the player is inside the DrinkStationVolume
    [SerializeField] public enum SelectedDrink
    {
        None,
        Milkshake,
        Smoothie,
        Beer,
        Cocktail
    }
    public SelectedDrink CurrentDrink = SelectedDrink.None; // Variable to store the currently selected item

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
            CurrentDrink = SelectedDrink.Milkshake;
           Debug.Log("Selected Drink: Milkshake");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentDrink = SelectedDrink.Smoothie;
            Debug.Log("Selected Drink: Smoothie");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentDrink = SelectedDrink.Beer;
            Debug.Log("Selected Drink: Beer");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CurrentDrink = SelectedDrink.Cocktail;
            Debug.Log("Selected Drink: Cocktail");
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


