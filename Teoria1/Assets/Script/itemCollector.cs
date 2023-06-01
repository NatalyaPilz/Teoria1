using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{

    private int fruits = 0;

    [SerializeField] private Text fruitsText;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruits"))
        {
            Destroy(collision.gameObject);
            fruits++;
            fruitsText.text = "Fruits: " + fruits;
        }
    }
}
