using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private DrinkStation drinkStation;

    [SerializeField] float step = 2f;
    [SerializeField] public DrinkMovement MilkshakePrefab; 
    [SerializeField] private DrinkMovement SmoothiePrefab;
    [SerializeField] private DrinkMovement BeerPrefab;
    [SerializeField] private DrinkMovement Cocktailprefab;
    [SerializeField] private DrinkMovement SelectedDrinkPrefab;
    [SerializeField] private Transform spawnDrinkPos;

    void Start()
    {
        drinkStation = GameObject.FindGameObjectWithTag("Player").GetComponent<DrinkStation>();
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
            newDrink.drinkType = drinkStation.CurrentDrink; // Set the type of the drink
        }
    }

    void DrinkSelection()
    {
        if (drinkStation != null)
        {
            // Access the CurrentDrink variable from DrinkStation
            DrinkStation.DrinkMenu selectedItem = drinkStation.CurrentDrink;

            switch (selectedItem)
            {
                case DrinkStation.DrinkMenu.Milkshake:
                    SelectedDrinkPrefab = MilkshakePrefab;
                    break;
                case DrinkStation.DrinkMenu.Smoothie:
                    SelectedDrinkPrefab = SmoothiePrefab;
                    break;
                case DrinkStation.DrinkMenu.Beer:
                    SelectedDrinkPrefab = BeerPrefab;
                    break;
                case DrinkStation.DrinkMenu.Cocktail:
                    SelectedDrinkPrefab = Cocktailprefab;
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
