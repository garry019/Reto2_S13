using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtons : MonoBehaviour
{
    /*private void Awake()
    {
        transform.localScale = Vector2.zero;
    }*/

    /*private void Start()
    {
        buttonStartAnimation();
    }*/

    /*public void buttonStartAnimation()
    {
        transform.LeanScale(Vector2.one, 1f).setEaseInOutBack();
    }*/

    public void Scene1()
    {
        SceneManager.LoadScene("EPC_Scene_1");
    }
    /*public void TryAgain()
    {
        SceneManager.LoadScene("Reto_1");
    }*/

    public void ExitGame()
    {
        Application.Quit();
    }

    /*public void OnPointerEnter(PointerEventData eventData)
    {
        transform.LeanScale(Vector2.one * 1.5f, 0.2f).setEaseInOutBack();
    }*/

    /*public void OnPointerExit(PointerEventData eventData)
    {
        transform.LeanScale(Vector2.one, 0.2f).setEaseInOutBack();
    }*/
}
