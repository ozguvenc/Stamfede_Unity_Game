using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager characterManagerInstance;

    [Header("Character UI")]
    private GameObject gameManagerObject;
    public GameObject audioSourceObject;
    private AudioSource audioSource;
    private AudioClip clip1;
    public string currentCharacterName;
    public GameObject[] charactersArray;
    public GameObject currentCharacterObject;
    public TextMeshProUGUI characterNameUI;
    public TextMeshProUGUI characterSpecialNameUI;
    public TextMeshProUGUI characterSpecialDescriptionUI;
    public TextMeshProUGUI playerNameInputUI;
    private string playerNameInputUIInitial;
    private bool characterStatsUpdated = false;

    public TextMeshProUGUI playerNameInputPlaceholderUI;
    public string playerName;

    public int speedAttribute;
    public int accuracyAttribute;
    public int strengthAttribute;
    public string abilityAttribute;
    public string abilityDescription;


    [Header("Character Stats")]
    public int characterIndex;

    [Header("Alisha")]
    public string[] character1Stats = new string[5];
    public Sprite character1SpecialIcon;


    [Header("Alisha")]
    public string[] character2Stats = new string[5];
    public Sprite character2SpecialIcon;


    [Header("Alisha")]
    public string[] character3Stats = new string[5];
    public Sprite character3SpecialIcon;

    public string[] currentCharacterStats = new string[5];
    public GameObject[] speedStars;
    public GameObject[] accuracyStars;
    public GameObject[] strengthStars;

    private bool characterLoaded = false;
    public bool playerNameEntered;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Keep Character Manager through the levels to maintain character properties.
        DontDestroyOnLoad(this);

        if (characterManagerInstance == null)
        {
            characterManagerInstance = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Check to see if you are on the character creation scene.
        if (SceneManager.GetActiveScene().name == "0.5_CharacterCreation")
        {
            // No player name is entered at start.
            playerNameEntered = false;
            playerNameInputUIInitial = playerNameInputUI.text;

            // Set up audiosource and audioclip(s).
            audioSourceObject = GameObject.FindGameObjectWithTag("AudioManager");
            audioSource = audioSourceObject.GetComponent<AudioManager>().GetComponent<AudioSource>();
            clip1 = audioSource.GetComponent<AudioManager>().clip1;

            // Make sure all chosable characters are disabled at start.
            for (int i = 0; i < 3; i++)
            {
                charactersArray[i].SetActive(false);
                speedStars[i].SetActive(false);
                accuracyStars[i].SetActive(false);
                strengthStars[i].SetActive(false);
            }

            characterIndex = 0;

            // Update the first character
            UpdateCharacterStats();
            currentCharacterObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update the character and player names in the Game Manager.
        if (SceneManager.GetActiveScene().name != "0.5_CharacterCreation" && characterLoaded == false)
        {
            characterLoaded = true;
            gameManagerObject = GameObject.FindGameObjectWithTag("GameController");
            if (gameManagerObject != null)
            {
                gameManagerObject.GetComponent<GameManager>().characterName = currentCharacterName;
                gameManagerObject.GetComponent<GameManager>().playerName = playerName;
            }

        }
    }


    public void NextCharacter()
    {
        // Hide the last character model.
        if (currentCharacterObject != null) currentCharacterObject.SetActive(false);

        // Increase the character index.
        characterIndex++;
        characterIndex = characterIndex % 3;


        // Make the updateCharacterStats method condition accessible.
        characterStatsUpdated = false;

        // Update the character stats on screen.
        UpdateCharacterStats();

        // Play a sound when next character is shown.
        audioSource.PlayOneShot(clip1);



        // Show the new character model.
        currentCharacterObject.SetActive(true);
    }

    public void PreviousCharacter()
    {
        // Hide the last character model.
        currentCharacterObject.SetActive(false);

        // Decrease the character index.
        characterIndex--;
        if (characterIndex < 0) characterIndex = 2;

        // Make the updateCharacterStats method condition accessible.
        characterStatsUpdated = false;

        // Update the character stats on screen.
        UpdateCharacterStats();

        // Play a sound when next character is shown.
        audioSource.PlayOneShot(clip1);

        // Show the new character model.
        currentCharacterObject.SetActive(true);

    }

    void StarCalculator(int speedCount, int accuracyCount, int strengthCount)
    {
        // Reset previous stars.
        for (int i = 0; i < 3; i++)
        {
            speedStars[i].SetActive(false);
            accuracyStars[i].SetActive(false);
            strengthStars[i].SetActive(false);
        }

        // Set star rating for each attribute.
        for (int i = 0; i < speedCount; i++)
        {
            speedStars[i].SetActive(true);
        }

        for (int i = 0; i < accuracyCount; i++)
        {
            accuracyStars[i].SetActive(true);
        }

        for (int i = 0; i < strengthCount; i++)
        {
            strengthStars[i].SetActive(true);
        }
    }


    void UpdateCharacterStats()
    {
        // Find the current character's stats array.
        if (characterIndex == 0)
        {
            currentCharacterStats = character1Stats;
        }
        else if (characterIndex == 1)
        {
            currentCharacterStats = character2Stats;
        }
        else if (characterIndex == 2)
        {
            currentCharacterStats = character3Stats;
        }

        // Update character name and model.
        currentCharacterObject = charactersArray[characterIndex];
        currentCharacterName = currentCharacterObject.name;
        characterNameUI.text = currentCharacterName;

        // Update the current character's attributes
        speedAttribute = int.Parse(currentCharacterStats[0]);
        accuracyAttribute = int.Parse(currentCharacterStats[1]);
        strengthAttribute = int.Parse(currentCharacterStats[2]);
        abilityAttribute = currentCharacterStats[3];
        abilityDescription = currentCharacterStats[4];

        // Update the ability and description UI.
        characterSpecialNameUI.text = abilityAttribute;
        characterSpecialDescriptionUI.text = abilityDescription;

        // Call the star calculator method to show the correct star amounts.
        StarCalculator(speedAttribute, accuracyAttribute, strengthAttribute);
    }

    public void SavePlayerName()
    {
        if (playerNameInputUI.text != playerNameInputUIInitial)
        {
            playerName = playerNameInputUI.text;
            playerNameEntered = true;
        }
        else
        {
            playerNameInputPlaceholderUI.color = Color.red;
        }
    }

    public void EnableCharacterUpdate()
    {
        // Make the updateCharacterStats method condition accessible.
        characterStatsUpdated = false;
    }
}
