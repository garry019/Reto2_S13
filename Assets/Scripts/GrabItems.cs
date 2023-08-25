using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItems : MonoBehaviour
{
    private bool canTake;
    GameObject gmObject;
    GameManager gameManager;

    private void Start()
    {
        gmObject = GameObject.Find("GameManager");
        gameManager = gmObject.GetComponent<GameManager>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && canTake)
        {
            TakeTrash();
            canTake = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && gameObject.tag == "Grabable_Trash")
        {
            Debug.Log("Take Trash");
            canTake = true;
        }
        else 
        {
            canTake = false;
        }
    }

    private void TakeTrash()
    {
        Debug.Log("Trash to Inventory & Destroy");
        gameManager.score++;
        Destroy(gameObject);
    }
}
