using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using static DrinkStation;

public class Player : MonoBehaviour
{
    [Header("Drink")]
    [SerializeField] public DrinkStation drinkStation;
    [SerializeField] public DrinkStation.DrinkMenu drinkMenu;

    [Header("Movement")]
    [SerializeField] float step = 2f;
    [SerializeField] public DrinkMovement MilkshakePrefab; 
    [SerializeField] private DrinkMovement SmoothiePrefab;
    [SerializeField] private DrinkMovement BeerPrefab;
    [SerializeField] private DrinkMovement Cocktailprefab;
    [SerializeField] private DrinkMovement SelectedDrinkPrefab;
    [SerializeField] private Transform spawnDrinkPos;
    public DrinkMenu CurrentDrink = DrinkMenu.None;
    void Start()
    {
        SelectedDrinkPrefab = MilkshakePrefab;
    }

    void Update()
    {
        Move();
        Shoot();
        DrinkSelection();
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += Vector3.up * step;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += Vector3.down * step;
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DrinkMovement newDrink = Instantiate(SelectedDrinkPrefab, spawnDrinkPos.position, Quaternion.identity).GetComponent<DrinkMovement>();
            newDrink.drinkType = drinkMenu; // Set the type of the drink
        }
    }

    void DrinkSelection()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;
        
        if (drinkStation != null)
        {
            // Access the CurrentDrink variable from DrinkStation
            drinkMenu = drinkStation.CurrentDrink;

            switch (drinkMenu)
            {
                case DrinkStation.DrinkMenu.Milkshake:
                    SelectedDrinkPrefab = MilkshakePrefab;
                    CurrentDrink = DrinkMenu.Milkshake;
                    break;
                case DrinkStation.DrinkMenu.Smoothie:
                    SelectedDrinkPrefab = SmoothiePrefab;
                    CurrentDrink = DrinkMenu.Smoothie;
                    break;
                case DrinkStation.DrinkMenu.Beer:
                    SelectedDrinkPrefab = BeerPrefab;
                    CurrentDrink = DrinkMenu.Beer;
                    break;
                case DrinkStation.DrinkMenu.Cocktail:
                    SelectedDrinkPrefab = Cocktailprefab;
                    CurrentDrink = DrinkMenu.Cocktail;
                    break;
                case DrinkStation.DrinkMenu.None:
                    break;
            }
        }
        else
        {
            Debug.LogWarning("DrinkStation component not found on the player GameObject.");
        }
    }
}
