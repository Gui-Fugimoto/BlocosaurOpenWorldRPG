using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    public GameObject pickButton;
    public bool itemPicked;

    // Start is called before the first frame update
    void Start()
    {
        itemPicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickButton.SetActive(true);
            itemPicked = true;
        }
    }

    public void GetItem()
    {
        if (itemPicked)
        {
            Destroy(gameObject);// mudar para otimizacao 
            pickButton.SetActive(false);
        }
    }
}
