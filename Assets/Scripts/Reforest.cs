using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reforest : MonoBehaviour
{

    GameObject gmObject;
    GameManager gameManager;
    Renderer treeMesh;

    public bool canTakeOldTree;
    public bool sowing;


    private void Start()
    {
        gmObject = GameObject.Find("GameManager");
        gameManager = gmObject.GetComponent<GameManager>();
        treeMesh = gameObject.GetComponent<MeshRenderer>();
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
            Debug.Log("Sow Now");
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
    }

    private void Sowing()
    {
        treeMesh.enabled = true;
    }
}
