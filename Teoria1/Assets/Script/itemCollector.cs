using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{
    private Dictionary<string, int> fruitPointValues = new Dictionary<string, int>();
    private Text fruitsText;
    private int fruits = 0;

    private void Start()
    {
        fruitPointValues = new Dictionary<string, int>(); // POLYMORPHISM

        fruitPointValues.Add("Melon", 1);
        fruitPointValues.Add("Banana", 2);
        fruitPointValues.Add("Kiwi", 3);

        fruitsText = GameObject.Find("FruitsText").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Melon"))
        {
            Destroy(collision.gameObject);
            fruits += fruitPointValues["Melon"];
            UpdateFruitsText();
        }

        if (collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);
            fruits += fruitPointValues["Banana"];
            UpdateFruitsText();
        }

        if (collision.gameObject.CompareTag("Kiwi"))
        {
            Destroy(collision.gameObject);
            fruits += fruitPointValues["Kiwi"];
            UpdateFruitsText();
        }
    }

    private void UpdateFruitsText()
    {
        fruitsText.text = "Fruits: " + fruits;
    }
}

