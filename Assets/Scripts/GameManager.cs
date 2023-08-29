using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject pollutionSlider;
    Slider slider;
    
    [SerializeField] private TextMeshProUGUI trashScore;
    [SerializeField] private TextMeshProUGUI pollutionScore;
    public int sliderValue;
    public int score = 5;

    public bool canReforest;
    public bool canTakeOldTrees;
    public int treesCollected;

    public bool canSow;

    private void Start()
    {
        Cursor.visible = false;
        pollutionSlider = GameObject.Find("Slider");
        slider = pollutionSlider.GetComponent<Slider>();
        sliderValue = 100;
        treesCollected = 0;
    }

    private void Update()
    {
        slider.value = sliderValue;
        pollutionScore.text = slider.value.ToString();
        trashScore.text = score.ToString();
 
        if (slider.value == 0)
        {
            canReforest = true;
            canTakeOldTrees = true;
        }
        else
        {
            canReforest = false;
        }

        if (treesCollected == 9)
        {
            canSow = true;
        }
    }
}
