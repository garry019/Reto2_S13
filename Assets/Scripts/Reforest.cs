using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reforest : MonoBehaviour
{

    GameObject gmObject;
    GameManager gameManager;
    Renderer treeMesh;
    GameObject woodSmash;
    AudioSource woodSmashSound;
    GameObject notification;
    AudioSource notificationSound;
    GameObject treeSow;
    AudioSource treeSowSound;

    public bool canTakeOldTree;
    public bool sowing;


    private void Start()
    {
        gmObject = GameObject.Find("GameManager");
        gameManager = gmObject.GetComponent<GameManager>();
        treeMesh = gameObject.GetComponent<MeshRenderer>();
        woodSmash = GameObject.Find("WoodSmash");
        woodSmashSound = woodSmash.GetComponent<AudioSource>();
        notification = GameObject.Find("Notification");
        notificationSound = notification.GetComponent<AudioSource>();
        treeSow = GameObject.Find("Sowing");
        treeSowSound = treeSow.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if ((Input.GetKey(KeyCode.R) && gameManager.canReforest) && ((gameManager.canTakeOldTrees && canTakeOldTree) || gameManager.canSow))
        {
            if (gameManager.canTakeOldTrees && canTakeOldTree)
                DestroyTree();
            if (gameManager.canSow && sowing)
                Sowing();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && gameObject.tag == "Old_Tree")
        {
            canTakeOldTree = true;
        }

        if (other.gameObject.tag == "Player" && gameObject.tag == "TreeToSow")
        {
            sowing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canTakeOldTree = false;
        sowing = false;
    }

    private void DestroyTree()
    {
        Destroy(gameObject);
        gameManager.treesCollected++;
        canTakeOldTree = false;
        gameManager.score++;
        woodSmashSound.Play();

        if (gameManager.treesCollected == 9)
        {
            gameManager.score = 0;
            notificationSound.Play();
        }
    }

    private void Sowing()
    {
        gameManager.treesSown++;
        gameManager.score = gameManager.treesSown;
        treeMesh.enabled = true;
        sowing = false;
        treeSowSound.Play();

        if (gameManager.treesSown == 2)
        {
            notificationSound.Play();
        }
    }
}
