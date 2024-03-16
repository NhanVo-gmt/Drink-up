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
     private DrinkStation drinkStation;

    // Start is called before the first frame update
    void Start()
    {
        drinkStation = GameObject.FindGameObjectWithTag("Player").GetComponent<DrinkStation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (drinkStation != null)
        {
            // Access the CurrentDrink variable from DrinkStation
            DrinkStation.DrinkMenu selectedItem = drinkStation.CurrentDrink;

            switch (selectedItem)
            {
                case DrinkStation.DrinkMenu.Milkshake:
                    Milkshake.sprite = Milkshake1;
                    break;
                case DrinkStation.DrinkMenu.Smoothie:
                    Milkshake.sprite = Smoothie;
                    break;
                case DrinkStation.DrinkMenu.Beer:
                    Milkshake.sprite = Beer;
                    break;
                case DrinkStation.DrinkMenu.Cocktail:
                    Milkshake.sprite = Cocktail;
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

