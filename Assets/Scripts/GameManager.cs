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

    private void Start()
    {
        //Debug.Log("Hide Cursor");
        Cursor.visible = false;
        pollutionSlider = GameObject.Find("Slider");
        slider = pollutionSlider.GetComponent<Slider>();
        sliderValue = 100;
    }

    private void Update()
    {
        slider.value = sliderValue;
        pollutionScore.text = slider.value.ToString();
        trashScore.text = score.ToString();
    }

}
