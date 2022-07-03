using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void LateUpdate()
    {
        if (Input.GetButton("Cancel"))
        {
            Application.Quit();
        }
    }
    public void exitgame()
    {
        Application.Quit();
    }
    public void Scene1()
    {
        SceneManager.LoadScene("Scene1");
    }
    public void Scene2()
    {
        SceneManager.LoadScene("Scene2");
    }
    public void Scene3()
    {
        SceneManager.LoadScene("Scene3");
    }
}
