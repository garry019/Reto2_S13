using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtons : MonoBehaviour
{
        public void Scene1()
    {
        SceneManager.LoadScene("EPC_Scene_1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
