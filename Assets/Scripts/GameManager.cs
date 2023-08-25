using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI trashScore;
    public int score = 5;

    private void Start()
    {
        //Debug.Log("Hide Cursor");
        Cursor.visible = false;
    }

    private void Update()
    {
        trashScore.text = score.ToString();
    }

}
