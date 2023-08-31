using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItems : MonoBehaviour
{
    private bool canTake;
    GameObject gmObject;
    GameManager gameManager;
    GameObject notification;
    AudioSource notificationSound;

    [SerializeField] public AudioSource pickUp;

    private void Start()
    {
        gmObject = GameObject.Find("GameManager");
        gameManager = gmObject.GetComponent<GameManager>();
        notification = GameObject.Find("Notification");
        notificationSound = notification.GetComponent<AudioSource>();
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
        pickUp.Play();
        if (gameManager.score == 5)
        {
            notificationSound.Play();
        }
    }
}
