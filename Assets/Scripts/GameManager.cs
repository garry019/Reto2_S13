using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject pollutionSlider;
    GameObject[] trashCanIcons;
    GameObject forestAreaIcon;
    GameObject sowArea1Icon;
    GameObject sowArea2Icon;
    Slider slider;
    
    [SerializeField] private TextMeshProUGUI trashScore;
    [SerializeField] private TextMeshProUGUI pollutionScore;
    [SerializeField] private TextMeshProUGUI MissionText;
    [SerializeField] private TextMeshProUGUI ScoreGoal;
    public int sliderValue;
    public int score = 5;

    public bool canReforest;
    public bool canTakeOldTrees;
    public int treesCollected;
    public int treesSown;

    public bool canSow;

    private void Start()
    {
        Cursor.visible = false;
        pollutionSlider = GameObject.Find("Slider");
        forestAreaIcon = GameObject.Find("ForestAreaText");
        sowArea1Icon = GameObject.Find("SowArea1");
        sowArea2Icon = GameObject.Find("SowArea2");
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
            MissionText.text = "Ve a la zona de reforestación y tala los arboles muertos.";
            ScoreGoal.text = "/9";
            trashCanIcons = GameObject.FindGameObjectsWithTag("TrashCanIcon");
            foreach (GameObject icon in trashCanIcons)
            {
                icon.GetComponent<MeshRenderer>().enabled = false;
            }
            forestAreaIcon.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            canReforest = false;
        }

        if (treesCollected == 9)
        {
            canSow = true;
            MissionText.text = "Debes sembrar 2 árboles para reforestar la zona afectada.";
            ScoreGoal.text = "/2";
            forestAreaIcon.GetComponent<MeshRenderer>().enabled = false;
            sowArea1Icon.GetComponent<MeshRenderer>().enabled = true;
            sowArea2Icon.GetComponent<MeshRenderer>().enabled = true;
        }

        if (treesSown == 2)
        {
            ScoreGoal.text = "";
            trashScore.text = "";
            MissionText.text = "!Nuestro parque esta libre de contaminación!";
            sowArea1Icon.GetComponent<MeshRenderer>().enabled = false;
            sowArea2Icon.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
