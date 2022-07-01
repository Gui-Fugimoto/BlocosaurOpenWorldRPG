using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    //public GameObject pickButton;
    //public bool potionPicked;

    public Health health;

    // Start is called before the first frame update
    void Start()
    {
        //potionPicked = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //pickButton.SetActive(true);
            //potionPicked = true;
            Destroy(gameObject);
            health.TakeDamage(40);
        }

    }
}
