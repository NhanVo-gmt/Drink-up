using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentDrinkUIScript : MonoBehaviour
{
    public Image Milkshake;
    [SerializeField] public Sprite Milkshake1;
    [SerializeField] public Sprite Smoothie;
    [SerializeField] public Sprite Beer;
    [SerializeField] public Sprite Cocktail;
     private DrinkStationScript drinkStation;

    // Start is called before the first frame update
    void Start()
    {
        drinkStation = GameObject.FindGameObjectWithTag("Player").GetComponent<DrinkStationScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (drinkStation != null)
        {
            // Access the CurrentDrink variable from DrinkStationScript
            DrinkStationScript.DrinkMenu selectedItem = drinkStation.CurrentDrink;

            switch (selectedItem)
            {
                case DrinkStationScript.DrinkMenu.Milkshake:
                    Milkshake.sprite = Milkshake1;
                    break;
                case DrinkStationScript.DrinkMenu.Smoothie:
                    Milkshake.sprite = Smoothie;
                    break;
                case DrinkStationScript.DrinkMenu.Beer:
                    Milkshake.sprite = Beer;
                    break;
                case DrinkStationScript.DrinkMenu.Cocktail:
                    Milkshake.sprite = Cocktail;
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

