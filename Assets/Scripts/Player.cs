using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private DrinkStationScript drinkStation;

    [SerializeField] float step = 2f;
    [SerializeField] public DrinkMovement MilkshakePrefab; 
    [SerializeField] private DrinkMovement SmoothiePrefab;
    [SerializeField] private DrinkMovement BeerPrefab;
    [SerializeField] private DrinkMovement Cocktailprefab;
    [SerializeField] private DrinkMovement SelectedDrinkPrefab;
    [SerializeField] private Transform spawnDrinkPos;

    void Start()
    {
        drinkStation = GameObject.FindGameObjectWithTag("Player").GetComponent<DrinkStationScript>();
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
            //the prefab is updated here by the DrinkSelection() function below
            //depending on the state of the enum in the DrinkStationScript
            Instantiate(SelectedDrinkPrefab, spawnDrinkPos.position, Quaternion.identity);
        }
    }

    void DrinkSelection()
    {
        if (drinkStation != null)
        {
            // Access the CurrentDrink variable from DrinkStationScript
            DrinkStationScript.DrinkMenu selectedItem = drinkStation.CurrentDrink;

            switch (selectedItem)
            {
                case DrinkStationScript.DrinkMenu.Milkshake:
                    SelectedDrinkPrefab = MilkshakePrefab;
                    break;
                case DrinkStationScript.DrinkMenu.Smoothie:
                    SelectedDrinkPrefab = SmoothiePrefab;
                    break;
                case DrinkStationScript.DrinkMenu.Beer:
                    SelectedDrinkPrefab = BeerPrefab;
                    break;
                case DrinkStationScript.DrinkMenu.Cocktail:
                    SelectedDrinkPrefab = Cocktailprefab;
                    break;
                case DrinkStationScript.DrinkMenu.None:
                    break;
            }
        }
        else
        {
            Debug.LogWarning("DrinkStationScript component not found on the player GameObject.");
        }
    }
}
