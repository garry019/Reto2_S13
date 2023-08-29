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
            canTake = false;
            TakeTrash();
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && gameObject.tag == "Grabable_Trash")
        {
            canTake = true;
        }
        else 
        {
            canTake = false;
        }
    }

    private void TakeTrash()
    {
        gameManager.score++;
        Destroy(gameObject);
    }
}
