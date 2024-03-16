using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private DrinkStationScript drinkStation;

    [SerializeField] float step = 2f;
    [SerializeField] public DrinkMovement prefab; 
    [SerializeField] private DrinkMovement prefab2;
    [SerializeField] private DrinkMovement prefab3;
    [SerializeField] private DrinkMovement prefab4;
    [SerializeField] private DrinkMovement SelectedDrinkPrefab;
    [SerializeField] private Transform spawnDrinkPos;

    void Start()
    {
        drinkStation = GameObject.FindGameObjectWithTag("Player").GetComponent<DrinkStationScript>();

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
                    SelectedDrinkPrefab = prefab;
                    break;
                case DrinkStationScript.DrinkMenu.Smoothie:
                    SelectedDrinkPrefab = prefab2;
                    break;
                case DrinkStationScript.DrinkMenu.Beer:
                    SelectedDrinkPrefab = prefab3;
                    break;
                case DrinkStationScript.DrinkMenu.Cocktail:
                    SelectedDrinkPrefab = prefab4;
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
