using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private DrinkStationScript drinkStation;

    [SerializeField] float step = 2f;
    [SerializeField] private DrinkMovement prefab;
    [SerializeField] private DrinkMovement prefab2;
    [SerializeField] private DrinkMovement prefab3;
    [SerializeField] private DrinkMovement prefab4;
    private DrinkMovement SelectedDrinkPrefab;
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
            //when we have prefabs for the drink sprites we can just change it from prefab here to the SelectedDrinkPrefab variable
            //that is set in the DrinkSelection function below.
            Instantiate(prefab, spawnDrinkPos.position, Quaternion.identity);
        }
    }

    void DrinkSelection()
    {
        if (drinkStation != null)
        {
            // Access the currentItem variable from DrinkStationScript
            DrinkStationScript.SelectedDrink selectedItem = drinkStation.CurrentDrink;

            // Now you can use selectedItem in your logic
            switch (selectedItem)
            {
                case DrinkStationScript.SelectedDrink.Milkshake:
                    SelectedDrinkPrefab = prefab;
                   // Debug.Log("Milkshake is selected");
                    break;
                case DrinkStationScript.SelectedDrink.Smoothie:
                    SelectedDrinkPrefab = prefab2;
                    // Debug.Log("Smoothie is selected");
                    break;
                case DrinkStationScript.SelectedDrink.Beer:
                    SelectedDrinkPrefab = prefab3;
                    // Debug.Log("Beer is selected");
                    break;
                case DrinkStationScript.SelectedDrink.Cocktail:
                    SelectedDrinkPrefab = prefab4;
                    //  Debug.Log("Cocktail is selected");
                    break;
                case DrinkStationScript.SelectedDrink.None:
                   // Debug.Log("No drink is selected");
                    break;
            }
        }
        else
        {
            Debug.LogWarning("DrinkStationScript component not found on the player GameObject.");
        }
    }
}
