using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    private static LevelManager levelManagerInstance;

    // Set up parameters for each level.
    private GameObject gameManagerObject;
    public bool chosenLevelLoaded= false;
    private GameObject characterManagerObject;
    public int chosenLevel;
    public TextMeshProUGUI endMessage;
    public int finalScore;
    private GameObject spawnManagerObject;

    [Header("Level-1 Parameters")]
    public int L1_levelNumber;
    public string L1_levelName;
    public string L1_levelHint;
    public bool L1_Chicken;
    public bool L1_Cow;
    public bool L1_Horse;
    public float L1_spawnInterval;
    public Material L1_levelMaterial;
    public GameObject L1_playerSkin;
    public int L1_totalGameTime;
    public int L1_targetScore;
    public float L1_playerMovementMultiplyer;
    public float L1_animalMovementMultiplyer;
    public float L1_projectileMovementMultiplyer;
    public float L1_animalHitBoxMultiplyer;
    public AudioClip L1_levelSoundTrack;

    [Header("Level-2 Parameters")]
    public int L2_levelNumber;
    public string L2_levelName;
    public string L2_levelHint;
    public bool L2_Chicken;
    public bool L2_Cow;
    public bool L2_Horse;
    public float L2_spawnInterval;
    public Material L2_levelMaterial;
    public GameObject L2_playerSkin;
    public int L2_totalGameTime;
    public int L2_targetScore;
    public float L2_playerMovementMultiplyer;
    public float L2_animalMovementMultiplyer;
    public float L2_projectileMovementMultiplyer;
    public float L2_animalHitBoxMultiplyer;
    public AudioClip L2_levelSoundTrack;

    [Header("Level-3 Parameters")]
    public int L3_levelNumber;
    public string L3_levelName;
    public string L3_levelHint;
    public bool L3_Chicken;
    public bool L3_Cow;
    public bool L3_Horse;
    public float L3_spawnInterval;
    public Material L3_levelMaterial;
    public GameObject L3_playerSkin;
    public int L3_totalGameTime;
    public int L3_targetScore;
    public float L3_playerMovementMultiplyer;
    public float L3_animalMovementMultiplyer;
    public float L3_projectileMovementMultiplyer;
    public float L3_animalHitBoxMultiplyer;
    public AudioClip L3_levelSoundTrack;

    [Header("Level-4 Parameters")]
    public int L4_levelNumber;
    public string L4_levelName;
    public string L4_levelHint;
    public bool L4_Chicken;
    public bool L4_Cow;
    public bool L4_Horse;
    public float L4_spawnInterval;
    public Material L4_levelMaterial;
    public GameObject L4_playerSkin;
    public int L4_totalGameTime;
    public int L4_targetScore;
    public float L4_playerMovementMultiplyer;
    public float L4_animalMovementMultiplyer;
    public float L4_projectileMovementMultiplyer;
    public float L4_animalHitBoxMultiplyer;
    public AudioClip L4_levelSoundTrack;

    [Header("Level-5 Parameters")]
    public int L5_levelNumber;
    public string L5_levelName;
    public string L5_levelHint;
    public bool L5_Chicken;
    public bool L5_Cow;
    public bool L5_Horse;
    public float L5_spawnInterval;
    public Material L5_levelMaterial;
    public GameObject L5_playerSkin;
    public int L5_totalGameTime;
    public int L5_targetScore;
    public float L5_playerMovementMultiplyer;
    public float L5_animalMovementMultiplyer;
    public float L5_projectileMovementMultiplyer;
    public float L5_animalHitBoxMultiplyer;
    public AudioClip L5_levelSoundTrack;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Keep Level Manager through the levels to maintain level properties.
        DontDestroyOnLoad(this);

        if (levelManagerInstance == null)
        {
            levelManagerInstance = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }

    // Update is called every frame, if the MonoBehaviour is enabled
    private void Update()
    {
        // Check if spawnManagerObject is assigned.
        if(spawnManagerObject == null)
        {
            spawnManagerObject = GameObject.FindGameObjectWithTag("SpawnManager");
        }


        // Check if a gamemanagerobject is already assigned. If not look for one in the current scene.
        if (SceneManager.GetActiveScene().name == "1.1_Level1")
        {


            if (gameManagerObject == null)
            {
                gameManagerObject = GameObject.FindGameObjectWithTag("GameController");
            }
            else
            {
                if (chosenLevelLoaded == false)
                {
                    LoadChosenLevel();
                    chosenLevelLoaded = true;
                }

            }
        }

        if (characterManagerObject != null)
        {
            return;
        }
        else
        {
            // Check if a charactermanagerobject is already assigned. If not look for one in the current scene.
            characterManagerObject = GameObject.FindGameObjectWithTag("CharacterManager");
        }

        if (SceneManager.GetActiveScene().name == "0.6_GoodbyeScreen")
        {
            Debug.Log("Final screen");
            FinalScreen();
        }


    }

    void LoadChosenLevel()
    {
        // Set up the parameters for this level
        gameManagerObject.GetComponent<GameManager>().currentChapterNumber = 1; // Current Level is changed here.
        gameManagerObject.GetComponent<GameManager>().currentChapterName = "The Petting Farm";

        if (chosenLevel == 1)
        {
            LoadLevelWithParameters
                (
                
                L1_levelNumber,
                L1_levelName,
                L1_levelHint,
                L1_Chicken,
                L1_Cow,
                L1_Horse,
                L1_spawnInterval,
                L1_levelMaterial,
                L1_playerSkin,
                L1_totalGameTime,
                L1_targetScore,
                L1_playerMovementMultiplyer,
                L1_animalMovementMultiplyer,
                L1_projectileMovementMultiplyer,
                L1_animalHitBoxMultiplyer,
                L1_levelSoundTrack
                );
            
        }
        else if (chosenLevel == 2)
        {
            LoadLevelWithParameters
                (
                L2_levelNumber,
                L2_levelName,
                L2_levelHint,
                L2_Chicken,
                L2_Cow,
                L2_Horse,
                L2_spawnInterval,
                L2_levelMaterial,
                L2_playerSkin,
                L2_totalGameTime,
                L2_targetScore,
                L2_playerMovementMultiplyer,
                L2_animalMovementMultiplyer,
                L2_projectileMovementMultiplyer,
                L2_animalHitBoxMultiplyer,
                L2_levelSoundTrack
                );
        }
        else if (chosenLevel == 3)
        {
            LoadLevelWithParameters
                (
                L3_levelNumber,
                L3_levelName,
                L3_levelHint,
                L3_Chicken,
                L3_Cow,
                L3_Horse,
                L3_spawnInterval,
                L3_levelMaterial,
                L3_playerSkin,
                L3_totalGameTime,
                L3_targetScore,
                L3_playerMovementMultiplyer,
                L3_animalMovementMultiplyer,
                L3_projectileMovementMultiplyer,
                L3_animalHitBoxMultiplyer,
                L3_levelSoundTrack
                );
        }
        else if (chosenLevel == 4)
        {
            LoadLevelWithParameters
                (
                L4_levelNumber,
                L4_levelName,
                L4_levelHint,
                L4_Chicken,
                L4_Cow,
                L4_Horse,
                L4_spawnInterval,
                L4_levelMaterial,
                L4_playerSkin,
                L4_totalGameTime,
                L4_targetScore,
                L4_playerMovementMultiplyer,
                L4_animalMovementMultiplyer,
                L4_projectileMovementMultiplyer,
                L4_animalHitBoxMultiplyer,
                L4_levelSoundTrack
                );
        }
        else if (chosenLevel == 5)
        {

            LoadLevelWithParameters
                (
                L5_levelNumber,
                L5_levelName,
                L5_levelHint,
                L5_Chicken,
                L5_Cow,
                L5_Horse,
                L5_spawnInterval,
                L5_levelMaterial,
                L5_playerSkin,
                L5_totalGameTime,
                L5_targetScore,
                L5_playerMovementMultiplyer,
                L5_animalMovementMultiplyer,
                L5_projectileMovementMultiplyer,
                L5_animalHitBoxMultiplyer,
                L5_levelSoundTrack
                );
        }
    }

    void LoadLevelWithParameters
        (
        int levelNumber,
        string levelName,
        string levelHint,
        bool chicken,
        bool cow,
        bool horse,
        float spawnInterval,
        Material levelMaterial,
        GameObject playerSkin,
        int totalGameTime,
        int scoreToWin,
        float playerMovementMultiplyer,
        float animalMovementMultiplyer,
        float projectileMovementMultiplyer,
        float animalHitBoxMultiplyer,
        AudioClip levelSoundTrack
        )
    {
        gameManagerObject.GetComponent<GameManager>().currentLevelNumber = levelNumber; // Current Level is changed here.
        gameManagerObject.GetComponent<GameManager>().currentLevelName = levelName;
        gameManagerObject.GetComponent<GameManager>().levelHint = levelHint;
        gameManagerObject.GetComponent<GameManager>().spawnChicken = chicken;
        gameManagerObject.GetComponent<GameManager>().spawnCow = cow;
        gameManagerObject.GetComponent<GameManager>().spawnHorse = horse;
        gameManagerObject.GetComponent<GameManager>().spawnInterval = spawnInterval;
        gameManagerObject.GetComponent<GameManager>().currentBackground = levelMaterial;
        gameManagerObject.GetComponent<GameManager>().currentCharacter = playerSkin;
        gameManagerObject.GetComponent<GameManager>().totalLevelTime = totalGameTime;
        gameManagerObject.GetComponent<GameManager>().targetScore = scoreToWin;
        gameManagerObject.GetComponent<GameManager>().playerMovementMultiplyer = playerMovementMultiplyer;
        gameManagerObject.GetComponent<GameManager>().animalMovementMultiplyer = animalMovementMultiplyer;
        gameManagerObject.GetComponent<GameManager>().projectileMovementMultiplyer = projectileMovementMultiplyer;
        gameManagerObject.GetComponent<GameManager>().animalHitBoxMultiplyer = animalHitBoxMultiplyer;
        gameManagerObject.GetComponent<GameManager>().soundTrack = levelSoundTrack;
        gameManagerObject.GetComponent<GameManager>().levelManagerExecutionFinished = true;
    }
    public void loadScene(string sceneName)
    {
        if (SceneManager.GetActiveScene().name == "0.5_CharacterCreation")
        {
            if( sceneName == "0.2_MainMenu")
            {
                SceneManager.LoadScene(sceneName);
            }
           else if (characterManagerObject.GetComponent<CharacterManager>().playerNameEntered == true)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void exitGame()
    {
        Application.Quit();
    }

    void FinalScreen()
    {
        endMessage = GameObject.FindGameObjectWithTag("EndMessage").GetComponent<TextMeshProUGUI>();
        Debug.Log(endMessage);
        endMessage.text = "Congratulations!" +
                              "\nYour total game score = " + finalScore + " points.\n" +
                              "\nThank you for playing through this short concept demo. " +
                              "\nIf you liked the game and want to see more levels let me know at: chasetailgames@gmail.com";

    }
}
