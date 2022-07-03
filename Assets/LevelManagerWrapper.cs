using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerWrapper : MonoBehaviour
{
    private GameObject levelManagerObject;

    // Start is called before the first frame update
    void Start()
    {
        levelManagerObject = GameObject.FindGameObjectWithTag("LevelManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadSceneWrapper(string sceneName)
    {
        levelManagerObject.GetComponent<LevelManager>().loadScene(sceneName);
    }

    public void exitGameWrapper()
    {

        levelManagerObject.GetComponent<LevelManager>().exitGame();
        {
            Application.Quit();
        }
    }

}
