using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    GameObject gmObject;
    GameManager gameManager;
    GameObject notification;
    AudioSource notificationSound;
    private bool canDrop;
    private int pollutionScore;

    // Start is called before the first frame update
    void Start()
    {
        gmObject = GameObject.Find("GameManager");
        gameManager = gmObject.GetComponent<GameManager>();
        notification = GameObject.Find("Notification");
        notificationSound = notification.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && canDrop && gameManager.score > 0)
        {
            canDrop = false;
            DropTrash();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && gameObject.tag == "TrashCan" && gameManager.score == 5)
        {
            canDrop = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canDrop = false;
    }

    private void DropTrash()
    {
        pollutionScore = gameManager.score * 20;
        gameManager.score = 0;
        gameManager.sliderValue = gameManager.sliderValue - pollutionScore;
        notificationSound.Play();
    }
}
