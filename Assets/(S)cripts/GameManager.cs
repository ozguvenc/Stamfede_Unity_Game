using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Player Settings")]
    public Vector3 playerStartPosition;
    public GameObject currentCharacter;
    private bool currentCharacterSet;
    public GameObject playerObject;
    public GameObject characterManagerObject;
    public string playerName;
    private bool playerNameSet = false;
    public string characterName;
    private bool characterNameSet = false;
    public GameObject[] characters;
    public GameObject playerManagerObject;

    [Header("Control Settings")]
    public KeyCode chickenFoodKeyName;
    public KeyCode cowFoodKeyName;
    public KeyCode horseFoodKeyName;

    [Header("Difficulty Settings")]
    string[] difficultyLevels = new string[4];
    public string currentDifficulty;
    
    [Header("Level Settings")]
    public int currentLevelNumber;
    public string currentLevelName;
    public int finalLevel;
    public int finalChapter;
    public int currentChapterNumber;
    public string currentChapterName;
    public bool levelManagerExecutionFinished = false;

    public Material currentBackground;
    public GameObject groundObject;
    public GameObject levelManagerObject;
    public GameObject gameSettings;
    public bool levelAlreadySetUp;
    public string levelHint;


    [Header("Time Settings")]
    public TextMeshProUGUI timeUI;
    public int totalLevelTime;
    public int levelTimeLeft;
    private bool gamePaused;
    public bool levelRunning;
    private bool countDownStarted;
    private bool levelEnd;
    private bool levelEndSequenceCompleted;
    public Coroutine timerCoroutine;

    [Header("Info Panel Settings")]
    [Header("UI Variables")]
    public TextMeshProUGUI playerNameUI;
    public TextMeshProUGUI characterNameUI;

    public GameObject messagesPanel;
    public TextMeshProUGUI playerMessages;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI targetScoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI totalScoreText;

    public TextMeshProUGUI chickenFedCountText;
    public TextMeshProUGUI cowFedCountText;
    public TextMeshProUGUI horseFedCountText;

    public TextMeshProUGUI chickenMissedCountText;
    public TextMeshProUGUI cowMissedCountText;
    public TextMeshProUGUI horseMissedCountText;

    public TextMeshProUGUI chickenFedPointsText;
    public TextMeshProUGUI cowFedPointsText;
    public TextMeshProUGUI horseFedPointsText;

    public TextMeshProUGUI chickenMissedPointsText;
    public TextMeshProUGUI cowMissedPointsText;
    public TextMeshProUGUI horseMissedPointsText;

    public TextMeshProUGUI chickenFoodCostText;
    public TextMeshProUGUI cowFoodCostText;
    public TextMeshProUGUI horseFoodCostText;

    public TextMeshProUGUI levelNameUI;
    public TextMeshProUGUI levelNumberUI;
    public TextMeshProUGUI levelNameMessageUI;
    public TextMeshProUGUI chapterNameMessageUI;
    public TextMeshProUGUI levelHintUI;

    public TextMeshProUGUI chickenFoodKeyUI;
    public TextMeshProUGUI cowFoodKeyUI;
    public TextMeshProUGUI horseFoodKeyUI;

    public Image specialIcon;
    public Animator specialIconAnimator;
    public TextMeshProUGUI specialNameUI;

    public GameObject chickenInfoPanel;
    public GameObject cowInfoPanel;
    public GameObject horseInfoPanel;

    public Vector3[] animalInfoPanelPositions = new Vector3[3];

    [Header("Score Variables")]
    public int totalScore;
    public int levelScore;
    public int targetScore;

    public int chickenFedCount;
    public int cowFedCount;
    public int horseFedCount;

    public int chickenMissedCount;
    public int cowMissedCount;
    public int horseMissedCount;

    public int chickenScore;
    public int cowScore;
    public int horseScore;

    public int chickenPenalty;
    public int cowPenalty;
    public int horsePenalty;

    public int chickenFoodCost;
    public int cowFoodCost;
    public int horseFoodCost;

    [Header("Multiplyer Settings")]
    public float playerMovementMultiplyer;
    public float animalMovementMultiplyer;
    public float animalHitBoxMultiplyer;
    public float projectileMovementMultiplyer;

    [Header("Animal Settings")]
    public GameObject[] animalsToSpawn;
    public bool spawnChicken;
    public bool spawnCow;
    public bool spawnHorse;
    public List<GameObject> animalsInLevel;
    public float spawnInterval = 0;

    [Header("Particle Settings")]
    public GameObject chickenEatParticle;
    public GameObject cowEatParticle;
    public GameObject horseEatParticle;
    public GameObject escapeParticle;

    [Header("Projectile Settings")]
    public GameObject chickenFood;
    public GameObject cowFood;
    public GameObject horseFood;
    public GameObject heartAnimation;
    public GameObject missAnimation;

    [Header("Audio Settings")]
    public AudioSource audioSource;
    public AudioClip soundTrack;
    public AudioClip projectileCornSound;
    public AudioClip projectileAppleSound;
    public AudioClip projectileHaySound;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip countSound;
    public AudioClip startSoundClip;

    public AudioClip chickenEat;
    public AudioClip cowEat;
    public AudioClip horseEat;

    public AudioClip chickenEscape;
    public AudioClip cowEscape;
    public AudioClip horseEscape;

    public AudioClip character1SpecialSound;
    public AudioClip character2SpecialSound;
    public AudioClip character3SpecialSound;
    public AudioClip specialCountDown;
    public AudioClip specialOverSound;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Do not start level until initial countdown.
        levelRunning = false;
        countDownStarted = false;
        levelEnd = false;
        levelEndSequenceCompleted = true;
        UnityEngine.Cursor.visible = false;
        levelAlreadySetUp = false;
    }

    // Start is called before the first frame update
    private void Start()
    {

        // Set up audio source.
        audioSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
        audioSource.Stop();
        audioSource.clip = soundTrack;
        audioSource.volume = 0.3f;
        audioSource.Play();

        // Set up a reference for the level manager.
        levelManagerObject = GameObject.FindGameObjectWithTag("LevelManager");

        // Set up characterManagerObject
        characterManagerObject = GameObject.FindGameObjectWithTag("CharacterManager");


        // Set the total score. (ADD SAVED SCORE LATER WHEN SAVE CLASS IS CREATED)
        totalScore = 0;

        // Set up the player and character names.
        playerNameUI.text = playerName;
        characterNameUI.text = characterName;

        // Set up difficulty levels
        difficultyLevels[0] = "Easy";
        difficultyLevels[1] = "Medium";
        difficultyLevels[2] = "Hard";
        difficultyLevels[3] = "Stamfede";

        // Get the positions for animal info panels.
        for(int i = 0; i < animalInfoPanelPositions.Length; i++)
        {
            animalInfoPanelPositions[i] = new Vector3(0, 0, 0); // chickenInfoPanel.transform.position;
        }

        animalInfoPanelPositions[0] = chickenInfoPanel.transform.position;
        animalInfoPanelPositions[1] = cowInfoPanel.transform.position;
        animalInfoPanelPositions[2] = horseInfoPanel.transform.position;

        // Store player's initial position.
        playerStartPosition = playerObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        // Set up player name in the UI.
        if(playerName != null && playerNameSet == false)
        {
            playerNameUI.text = playerName;
            playerNameSet = true;
        }
        // Display character name in the UI.
        if (characterName != null && characterNameSet == false)
        {
            characterNameUI.text = characterName;
            characterNameSet = true;
        }

        // Switch the character chosen in character choice screen.
        if (currentCharacterSet == false)
        {
            currentCharacter = characters[characterManagerObject.GetComponent<CharacterManager>().characterIndex];
            for(int i = 0; i < characters.Length; i++)
            {
                characters[i].SetActive(false);
            }
            currentCharacter.SetActive(true);
            currentCharacterSet = true;
        }

        if (levelAlreadySetUp == false && levelManagerExecutionFinished == true)
        {
            SetUpNewLevel();
        }

        if (Input.anyKeyDown && countDownStarted == false)
        {
            StartCoroutine(startSequence(3));
        }

        UpdateInfoPanel();

        // If the levelScore requirement is met, then start the win sequence. 
        if(levelScore >= targetScore && levelRunning == true)
        {
            StartCoroutine(winSequence());
        }
        
        if (levelEndSequenceCompleted == false && Input.anyKeyDown)
        {
            LevelEndSequence();
        }

        // If time is up, start the lose sequence.
        if (levelTimeLeft <= 0 && levelRunning == true)
        {
            StartCoroutine(loseSequence());
        }

    }

    // Set up the parameters for chosen level.
    void SetUpNewLevel()
    {
        levelAlreadySetUp=true;
        levelManagerExecutionFinished = false;

        // Set game difficulty.
        SetDifficulty();

        // Set the player to tarting position
        playerObject.transform.position = playerStartPosition;

        // Hide panels in the beginning.
        messagesPanel.SetActive(false);
        chickenInfoPanel.SetActive(false);
        cowInfoPanel.SetActive(false);
        horseInfoPanel.SetActive(false);

        // Set up the parameters for chosen level.
        groundObject.GetComponent<MeshRenderer>().material = currentBackground;
        levelNameUI.GetComponent<TextMeshProUGUI>().text = currentLevelName;
        levelNumberUI.GetComponent<TextMeshProUGUI>().text = currentLevelNumber.ToString();
        levelHintUI.GetComponent<TextMeshProUGUI>().text = "Hint: " + levelHint;
        levelScore = 0;
        chickenMissedCount = 0;
        cowMissedCount = 0;
        horseMissedCount = 0;
        

        chapterNameMessageUI.GetComponent<TextMeshProUGUI>().text = "Chapter-" + currentChapterNumber + "\n" + "'" + currentChapterName + "'";
        levelNameMessageUI.GetComponent<TextMeshProUGUI>().text = "Level-" + currentLevelNumber + "\n" + "'" + currentLevelName + "'";

        // Choose which animals to spawn.
        ChooseAnimals(spawnChicken, spawnCow, spawnHorse);

        // Time is paused.
        Time.timeScale = 0f;
        gamePaused = true;

        // Show "Press any key to start." message.
        playerMessages.text = "Press any key to start.";
        messagesPanel.gameObject.SetActive(true);

        // Set the total time left for this level.
        levelTimeLeft = totalLevelTime;
        timeUI.text = levelTimeLeft.ToString();

        // Update the initial info panel information.
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        targetScoreText.text = targetScore.ToString();

        chickenFedPointsText.text = chickenScore.ToString();
        cowFedPointsText.text = cowScore.ToString();
        horseFedPointsText.text = horseScore.ToString();

        chickenMissedPointsText.text = chickenPenalty.ToString();
        cowMissedPointsText.text = cowPenalty.ToString();
        horseMissedPointsText.text = horsePenalty.ToString();

        chickenFoodCostText.text = chickenFoodCost.ToString();
        cowFoodCostText.text = cowFoodCost.ToString();
        horseFoodCostText.text = horseFoodCost.ToString();

        chickenFoodKeyUI.text = chickenFoodKeyName.ToString();
        cowFoodKeyUI.text = cowFoodKeyName.ToString();
        horseFoodKeyUI.text = horseFoodKeyName.ToString();
    }

    void UpdateInfoPanel()
    {
        // Update the Info Panel
        chickenFedCountText.text = chickenFedCount.ToString();
        cowFedCountText.text = cowFedCount.ToString();
        horseFedCountText.text = horseFedCount.ToString();

        chickenMissedCountText.text = chickenMissedCount.ToString();
        cowMissedCountText.text = cowMissedCount.ToString();
        horseMissedCountText.text = horseMissedCount.ToString();

        totalScoreText.text = totalScore.ToString();

        // Do not allow the score to fall below 0.
        if (levelScore <= 0) { levelScore = 0; }
        scoreText.text = levelScore.ToString();
    }

    IEnumerator startSequence(int countingFrom)
    {
        // Start game countdown.
        countDownStarted = true;

        int timeLeft;

        // Count from 3 to 1.
        for (timeLeft = countingFrom; timeLeft > 0; timeLeft--)
        {
            audioSource.PlayOneShot(countSound);
            playerMessages.text = timeLeft.ToString();
            yield return new WaitForSecondsRealtime(1);

        }
        // Show "Start" message when countdown reaches 0.
        if (timeLeft == 0)
        {
            playerMessages.text = "Start!";
            audioSource.PlayOneShot(startSoundClip);
            yield return new WaitForSecondsRealtime(1);
            messagesPanel.gameObject.SetActive(false);
        }

        // Start playing background music.
        
        if(!audioSource.isPlaying)
        {
            audioSource.clip = soundTrack;

            audioSource.volume = 0.3f;
            audioSource.Play();

        }

        // Start game timer.

        timerCoroutine = StartCoroutine(timer(totalLevelTime));

        // Start the game (player controller, animal spawn).
        levelRunning = true;

        // Unpause the game
        Time.timeScale = 1f;

        yield return null;
    }

    IEnumerator winSequence()
    {
        levelRunning = false;
        StopCoroutine(timerCoroutine);
        gamePaused = true;
        Time.timeScale = 0f;

        audioSource.Stop();
        audioSource.PlayOneShot(winSound);

        int totalLevelScore = levelScore + levelTimeLeft;
        totalScore += totalLevelScore;

        chapterNameMessageUI.text = "Level Score =" + totalLevelScore;


        levelNameMessageUI.text = "You collected " + levelScore + " hearts with " + levelTimeLeft + " seconds left."; 

        // Oranize the number of animals fed and missed for stats display.
        string chickenMessage = "";
        string cowMessage = "";
        string horseMessage = "";

        if (spawnChicken) 
        {
            chickenMessage = "You have fed " + chickenFedCount + " chickens and missed " + chickenMissedCount + "."; 
        }
        if(spawnCow) 
        {
            cowMessage = "You have fed " + cowFedCount + " cows and missed " + cowMissedCount + ".";
        }
        if(spawnHorse)
        {
            horseMessage = "You have fed " + horseFedCount + " horses and missed " + horseMissedCount + ".";
        }
        
        // Display fed/miss stats.
        levelHintUI.text = chickenMessage + "\n" + cowMessage + "\n" + horseMessage;

        playerMessages.text = "Well Done! \nPress any key to continue.";
        messagesPanel.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        levelEndSequenceCompleted = false;
    }

    IEnumerator loseSequence()
    {
        levelRunning = false;
        StopCoroutine(timerCoroutine);
        gamePaused = true;
        Time.timeScale = 0f;

        audioSource.Stop();
        audioSource.PlayOneShot(loseSound);


        int totalLevelScore = levelScore + levelTimeLeft;

        chapterNameMessageUI.text = "Level Score =" + totalLevelScore;


        levelNameMessageUI.text = "You collected " + levelScore + " hearts with " + levelTimeLeft + " seconds left.";

        // Oranize the number of animals fed and missed for stats display.
        string chickenMessage = "";
        string cowMessage = "";
        string horseMessage = "";

        if (spawnChicken)
        {
            chickenMessage = "You have fed " + chickenFedCount + " chickens and missed " + chickenMissedCount + ".";
        }
        if (spawnCow)
        {
            cowMessage = "You have fed " + cowFedCount + " cows and missed " + cowMissedCount + ".";
        }
        if (spawnHorse)
        {
            horseMessage = "You have fed " + horseFedCount + " horses and missed " + horseMissedCount + ".";
        }

        // Display fed/miss stats.
        levelHintUI.text = chickenMessage + "\n" + cowMessage + "\n" + horseMessage;

        playerMessages.text = "Nice try! \nPress any key to try again.";
        messagesPanel.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        levelEndSequenceCompleted = false;
    }

    IEnumerator timer(int time)
    {
        // Count from totalLevelTime to 0
        for (var i = time; i >= 0; i--)
        {
            if (levelEnd == false)
            {
                yield return new WaitForSeconds(1);
                levelTimeLeft--;
                timeUI.text = levelTimeLeft.ToString();
            }
            else
            {
                yield return null;
            }
        }
    }

    void CleanLevel()
    {
        GameObject[] animalsToClean = GameObject.FindGameObjectsWithTag("Animal");
        
        for(int i = 0; i < animalsToClean.Length; i++)
        {
            Destroy(animalsToClean[i]);
        }

        GameObject[] projectilesToClean = GameObject.FindGameObjectsWithTag("Projectile");

        for (int i = 0; i < projectilesToClean.Length; i++)
        {
            Destroy(projectilesToClean[i]);
        }

        playerManagerObject.GetComponent<PlayerController>().specialReady = true;
        playerManagerObject.GetComponent<PlayerController>().char1Animator.SetBool("Special", false);


        return;
    }

    public List<GameObject> ChooseAnimals(bool chicken, bool cow, bool horse)
    {
        animalsInLevel.Clear();
        int panelPosition = 0;

        if (chicken)
        {
            animalsInLevel.Add(animalsToSpawn[0]);
            chickenInfoPanel.transform.position = animalInfoPanelPositions[panelPosition];

            panelPosition++;
            chickenInfoPanel.SetActive(true);

        }
        if (cow)
        {
            animalsInLevel.Add(animalsToSpawn[1]);
            cowInfoPanel.transform.position = animalInfoPanelPositions[panelPosition];
            panelPosition++;
            cowInfoPanel.SetActive(true);
        }
        if (horse)
        {
            animalsInLevel.Add(animalsToSpawn[2]);
            horseInfoPanel.transform.position = animalInfoPanelPositions[panelPosition];
            panelPosition++;
            horseInfoPanel.SetActive(true);
        }
        return animalsInLevel;
    }

    void LevelEndSequence()
    {
        levelRunning = false;
        levelManagerObject.GetComponent<LevelManager>().chosenLevelLoaded = false;
        messagesPanel.gameObject.SetActive(false);
        levelScore = 0;

        // INCREASE THE CHOSEN LEVEL BY 1 (other scripts will make necessary changes based on this increase)
        if (currentLevelNumber == finalLevel)
        {
            levelManagerObject.GetComponent<LevelManager>().finalScore = totalScore;
            SceneManager.LoadScene(4);
        }
        else
        {
            if(levelTimeLeft > 0)
            {
                levelManagerObject.GetComponent<LevelManager>().chosenLevel++;
            }
         
            levelAlreadySetUp = false;
            countDownStarted = false;
            gamePaused = false;
            Time.timeScale = 1f;
            CleanLevel();
        }
        levelEndSequenceCompleted = true;
    }

    void SetDifficulty()
    {
        if(gameSettings != null)
        {
            currentDifficulty = gameSettings.GetComponent<GameSettings>().gameDifficulty;
        }

        if(currentDifficulty == difficultyLevels[0])
        {
            //Debug.Log("Difficulty is set to " + currentDifficulty);
        }
        else if (currentDifficulty == difficultyLevels[1])
        {
            //Debug.Log("Difficulty is set to " + currentDifficulty);
        }
        else if (currentDifficulty == difficultyLevels[2])
        {
            //Debug.Log("Difficulty is set to " + currentDifficulty);
        }
        else if (currentDifficulty == difficultyLevels[3])
        {
            //Debug.Log("Difficulty is set to " + currentDifficulty);
        }
    }
}

