using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    public DrinkStation.DrinkMenu requestedDrink;

    public SpriteRenderer drinkVisual;

    public Sprite beerSprite;
    public Sprite cocktailSprite;
    public Sprite milkshakeSprite;
    public Sprite smoothieSprite;

    public Vector3 drinkVisualOffset = new Vector3(0, 1, 0);

    private GameObject drinkVisualInstance;

    public GameObject drinkHolderPrefab;

    public ScoreSystem scoreSystem;
    //public Player player;
    public LifeSystem lifeSystem;

    private void Start()
    {
        requestedDrink = (DrinkStation.DrinkMenu)Random.Range(1, 5);
        CreateDrinkVisual();
        scoreSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreSystem>();
        lifeSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<LifeSystem>();
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += -transform.right * speed * Time.deltaTime;
    }

    void CreateDrinkVisual()
    {
        if (drinkHolderPrefab != null)
        {
            // Instantiate the drink visual as a child of the NPC GameObject
            drinkVisualInstance = Instantiate(drinkHolderPrefab, transform.position + drinkVisualOffset, Quaternion.identity, transform);

            // Get the SpriteRenderer of the instantiated drink visual
            SpriteRenderer drinkVisualRenderer = drinkVisualInstance.GetComponent<SpriteRenderer>();
            if (drinkVisualRenderer == null)
            {
                Debug.LogError("The drink visual prefab does not have a SpriteRenderer component.");
                return;
            }

            // Define a standard scale for the drinks
            Vector3 standardScale = new Vector3(0.5f, 0.5f, 0.5f); // You can adjust the values to fit the desired size

            // Update the sprite of the drink visual based on the requested drink and apply the standard scale
            switch (requestedDrink)
            {
                case DrinkStation.DrinkMenu.Beer:
                    drinkVisualRenderer.sprite = beerSprite;
                    drinkVisualRenderer.transform.localScale = standardScale; // Set the standard scale
                    break;
                case DrinkStation.DrinkMenu.Cocktail:
                    drinkVisualRenderer.sprite = cocktailSprite;
                    drinkVisualRenderer.transform.localScale = standardScale;
                    break;
                case DrinkStation.DrinkMenu.Milkshake:
                    drinkVisualRenderer.sprite = milkshakeSprite;
                    drinkVisualRenderer.transform.localScale = standardScale;
                    break;
                case DrinkStation.DrinkMenu.Smoothie:
                    drinkVisualRenderer.sprite = smoothieSprite;
                    drinkVisualRenderer.transform.localScale = standardScale;
                    break;
                default:
                    drinkVisualInstance.SetActive(false); // Deactivate the drink visual if no valid drink is set
                    break;
            }
        }
        else
        {
            Debug.LogError("Drink holder prefab is not assigned.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DrinkMovement drink = other.GetComponent<DrinkMovement>();

        // Check if we collided with a drink
        if (drink != null)
        {
            // Compare the drink type with the NPC's requested drink type
            if (drink.drinkType == requestedDrink)
            {
                // The drinks match, so destroy both the drink and the NPC
                Destroy(drink.gameObject);
                Destroy(gameObject);

                // Add scores depending on which drink was matched
                if (requestedDrink == DrinkStation.DrinkMenu.Milkshake)
                {
                    scoreSystem.AddPoints(100);
                }
                if (requestedDrink == DrinkStation.DrinkMenu.Smoothie)
                {
                    scoreSystem.AddPoints(200);
                }
                if (requestedDrink == DrinkStation.DrinkMenu.Beer)
                {
                    scoreSystem.AddPoints(300);
                }
                if (requestedDrink == DrinkStation.DrinkMenu.Cocktail)
                {
                    scoreSystem.AddPoints(400);
                }
            }
            // If they don't match, do nothing, allowing them to pass through each other
        }
        else if (other.CompareTag("NPCBarrier"))
        {
            // Other functionality for when an NPC hits a barrier
            Destroy(gameObject);
            lifeSystem.TakeDamage(1);
        }
    }
}
