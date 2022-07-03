using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSettings : MonoBehaviour
{
    public string gameScene;
    public bool GamePaused = false;
    public GameObject PauseMenuUI;
    public bool startMenuMusic = false;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    
    // Start is called before the first frame update
    void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != gameScene )
        {
            Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.ForceSoftware);
            Cursor.visible = true;
        }
        else
        {
            Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
            Cursor.visible = false;
        }

        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.ForceSoftware);

        if (startMenuMusic == true)
        {
            //GameObject.FindGameObjectWithTag("Music").GetComponent<MusicLoader>().PlayMusic();
        }
        else
        {
            //GameObject.FindGameObjectWithTag("Music").GetComponent<MusicLoader>().StopMusic();
        }
    }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
            
            if (GamePaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }
    public void ResumeGame()
    {
        GamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
    }

    void PauseGame()
    {
        GamePaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        PauseMenuUI.SetActive(true);
    }
}
