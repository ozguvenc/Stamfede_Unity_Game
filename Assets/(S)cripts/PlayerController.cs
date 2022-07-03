using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10;
    public float xRange = 15;
    public GameObject projectilePrefab;
    public GameObject gameManagerObject;
    private GameObject foodsFolder;
    private float movementMultiplyer;
    private GameObject characterManagerObject;
    private int characterIndex;
    private string[] characterStats;
    private float strengthMultiplyer;
    public float spawnRangeX = 1;
    private Vector3 spawnPos;
    private float accuracyMultiplyer;
    private Animator playerAnimator;
    public Animator char1Animator;
    public Animator char2Animator;
    public Animator char3Animator;
    public bool specialReady;
    private GameObject particlesFolder;
    public AudioSource playerAudioSource;
    public bool aSenseOfUrgency;
    public GameObject specialFX_Alisha;
    public GameObject specialFX_Wilbur;
    public GameObject specialFX_Theda;
    public GameObject wilbursWall;



    // Start is called before the first frame update
    void Start()
    {
        wilbursWall.SetActive(false);

        specialFX_Alisha.SetActive(false);
        specialFX_Wilbur.SetActive(false);
        specialFX_Theda.SetActive(false);

        aSenseOfUrgency = false;

        particlesFolder = GameObject.Find("Particles");

        specialReady = true;
        
        foodsFolder = GameObject.Find("Foods");

        characterManagerObject = GameObject.FindGameObjectWithTag("CharacterManager");
        characterIndex = characterManagerObject.GetComponent<CharacterManager>().characterIndex;
        Debug.Log("Index is " + characterIndex);

        if(characterIndex == 0)
        {
            playerAnimator = char1Animator;
            characterStats = characterManagerObject.GetComponent<CharacterManager>().character1Stats;
            gameManagerObject.GetComponent<GameManager>().specialIcon.sprite = characterManagerObject.GetComponent<CharacterManager>().character1SpecialIcon;

            // Set up the special ability name.
            gameManagerObject.GetComponent<GameManager>().specialNameUI.text = characterManagerObject.GetComponent<CharacterManager>().character1Stats[3];

            movementMultiplyer = 1;
            strengthMultiplyer = 0.7f;
            accuracyMultiplyer = 0.2f;
        }

        else if (characterIndex == 1)
        {
            playerAnimator = char2Animator;
            characterStats = characterManagerObject.GetComponent<CharacterManager>().character2Stats;
            gameManagerObject.GetComponent<GameManager>().specialIcon.sprite = characterManagerObject.GetComponent<CharacterManager>().character2SpecialIcon;

            // Set up the special ability name.
            gameManagerObject.GetComponent<GameManager>().specialNameUI.text = characterManagerObject.GetComponent<CharacterManager>().character2Stats[3];

            movementMultiplyer = 0.7f;
            strengthMultiplyer = 1.3f;
            accuracyMultiplyer = 0.6f;
        }

        else if (characterIndex == 2)
        {
            playerAnimator = char3Animator;
            characterStats = characterManagerObject.GetComponent<CharacterManager>().character3Stats;
            gameManagerObject.GetComponent<GameManager>().specialIcon.sprite = characterManagerObject.GetComponent<CharacterManager>().character3SpecialIcon;

            // Set up the special ability name.
            gameManagerObject.GetComponent<GameManager>().specialNameUI.text = characterManagerObject.GetComponent<CharacterManager>().character3Stats[3];

            movementMultiplyer = 1.3f;
            strengthMultiplyer = 1;
            accuracyMultiplyer = 1;

        }
        Debug.Log(movementMultiplyer);

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerObject.GetComponent<GameManager>().levelRunning == true)
        {
            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }
            if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }
            horizontalInput = Input.GetAxis("Horizontal");
            playerAnimator.SetFloat("HorizontalMovement", horizontalInput);
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed * movementMultiplyer);

            // Spawn new animals depending on which key is pressed.

            if (Input.GetKeyDown(gameManagerObject.GetComponent<GameManager>().chickenFoodKeyName) && gameManagerObject.GetComponent<GameManager>().spawnChicken)
            {
                DetermineAccuracy();

                playerAnimator.SetTrigger("Feed");

                GameObject newChickenFoodClone = Instantiate(gameManagerObject.GetComponent<GameManager>().chickenFood, transform.position + spawnPos + new Vector3(0, 0, 1), projectilePrefab.transform.rotation) as GameObject;
                newChickenFoodClone.transform.parent = foodsFolder.transform;
                newChickenFoodClone.transform.localScale = newChickenFoodClone.transform.localScale * strengthMultiplyer;

                gameManagerObject.GetComponent<GameManager>().audioSource.PlayOneShot(gameManagerObject.GetComponent<GameManager>().projectileCornSound);

                if(aSenseOfUrgency == false)
                { 
                gameManagerObject.GetComponent<GameManager>().levelScore -= gameManagerObject.GetComponent<GameManager>().chickenFoodCost;

                GameObject miss = Instantiate(gameManagerObject.GetComponent<GameManager>().missAnimation, transform.position - new Vector3(0,0,3), gameManagerObject.GetComponent<GameManager>().missAnimation.transform.rotation);
                miss.gameObject.transform.GetComponentInChildren<TextMeshPro>().text = gameManagerObject.GetComponent<GameManager>().chickenFoodCost.ToString();
                }
            }

            if (Input.GetKeyDown(gameManagerObject.GetComponent<GameManager>().cowFoodKeyName) && gameManagerObject.GetComponent<GameManager>().spawnCow)
            {
                DetermineAccuracy();

                playerAnimator.SetTrigger("Feed");


                GameObject newCowFoodClone = Instantiate(gameManagerObject.GetComponent<GameManager>().cowFood, transform.position + spawnPos + new Vector3(0, 0, 1), projectilePrefab.transform.rotation);
                newCowFoodClone.transform.parent = foodsFolder.transform;
                newCowFoodClone.transform.localScale = newCowFoodClone.transform.localScale * strengthMultiplyer;


                gameManagerObject.GetComponent<GameManager>().audioSource.PlayOneShot(gameManagerObject.GetComponent<GameManager>().projectileHaySound);

                if (aSenseOfUrgency == false)
                {
                    gameManagerObject.GetComponent<GameManager>().levelScore -= gameManagerObject.GetComponent<GameManager>().cowFoodCost;

                    GameObject miss = Instantiate(gameManagerObject.GetComponent<GameManager>().missAnimation, transform.position - new Vector3(0, 0, 3), gameManagerObject.GetComponent<GameManager>().missAnimation.transform.rotation);
                    miss.gameObject.transform.GetComponentInChildren<TextMeshPro>().text = gameManagerObject.GetComponent<GameManager>().cowFoodCost.ToString();
                }
            }

            if (Input.GetKeyDown(gameManagerObject.GetComponent<GameManager>().horseFoodKeyName) && gameManagerObject.GetComponent<GameManager>().spawnHorse)
            {
                DetermineAccuracy();

                playerAnimator.SetTrigger("Feed");


                GameObject newHorseFoodClone = Instantiate(gameManagerObject.GetComponent<GameManager>().horseFood, transform.position + spawnPos + new Vector3(0, 0, 1), projectilePrefab.transform.rotation);
                newHorseFoodClone.transform.parent = foodsFolder.transform;
                newHorseFoodClone.transform.localScale = newHorseFoodClone.transform.localScale * strengthMultiplyer;

                gameManagerObject.GetComponent<GameManager>().audioSource.PlayOneShot(gameManagerObject.GetComponent<GameManager>().projectileAppleSound);

                if (aSenseOfUrgency == false)
                {
                    gameManagerObject.GetComponent<GameManager>().levelScore -= gameManagerObject.GetComponent<GameManager>().horseFoodCost;

                    GameObject miss = Instantiate(gameManagerObject.GetComponent<GameManager>().missAnimation, transform.position - new Vector3(0, 0, 3), gameManagerObject.GetComponent<GameManager>().missAnimation.transform.rotation);
                    miss.gameObject.transform.GetComponentInChildren<TextMeshPro>().text = gameManagerObject.GetComponent<GameManager>().horseFoodCost.ToString();
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) && specialReady == true)
            {
                specialReady = false;
                UseSpecial();
            }

        }

    }

    void DetermineAccuracy()
    {
        spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, 0) * accuracyMultiplyer;
    }

    void UseSpecial()
    {
        if (characterIndex == 0)
        {
            StartCoroutine(AlishaSpecial(5));
        }

        else if (characterIndex == 1)
        {
            StartCoroutine(WilburSpecial(10));
        }

        else if (characterIndex == 2)
        {
            StartCoroutine(ThedaSpecial(5));

        }
    }

    IEnumerator AlishaSpecial(int duration)
    {
        gameManagerObject.GetComponent<GameManager>().audioSource.volume = 0f;
        playerAudioSource.clip = gameManagerObject.GetComponent<GameManager>().character1SpecialSound;
        playerAudioSource.Play();

        specialFX_Alisha.SetActive(true);
        

        GameObject[] animalsToStop = GameObject.FindGameObjectsWithTag("Animal");
        float[] animalsOriginalSpeed = new float[animalsToStop.Length];

        // Stop all the animals currently in the scene.
        for (int i = 0; i < animalsToStop.Length; i++)
        {
            animalsOriginalSpeed[i] = animalsToStop[i].GetComponent<MoveForward>().speed;
            animalsToStop[i].GetComponent<MoveForward>().speed = 0;
            animalsToStop[i].GetComponent<Animator>().enabled = false;
            GameObject newParticleClone = Instantiate(gameManagerObject.GetComponent<GameManager>().chickenEatParticle, animalsToStop[i].transform.position, animalsToStop[i].transform.rotation);
            newParticleClone.transform.parent = particlesFolder.transform;
        }

        // Start cooldown coroutine.
        StartCoroutine(SpecialCountdown(20));

        yield return new WaitForSeconds(duration);

        playerAudioSource.clip = gameManagerObject.GetComponent<GameManager>().specialOverSound;
        playerAudioSource.Play();

        specialFX_Alisha.SetActive(false);

        gameManagerObject.GetComponent<GameManager>().audioSource.volume = 0.3f;

        // Let the animals start moving again.

        for (int i = 0; i < animalsToStop.Length; i++)
        {
            if(animalsToStop[i] != null)
            {
                animalsToStop[i].GetComponent<MoveForward>().speed = animalsOriginalSpeed[i];
                animalsToStop[i].GetComponent<Animator>().enabled = true;
            }
        }

        yield return null;
    }

    IEnumerator WilburSpecial(int duration)
    {
        playerAudioSource.clip = gameManagerObject.GetComponent<GameManager>().character2SpecialSound;
        playerAudioSource.Play();

        specialFX_Wilbur.SetActive(true);

        wilbursWall.SetActive(true);

        gameManagerObject.GetComponent<GameManager>().specialIconAnimator.SetFloat("animationSpeed", 0.66f);
        Debug.Log("Animator speed" + gameManagerObject.GetComponent<GameManager>().specialIconAnimator.speed);

        // Start cooldown coroutine.
        StartCoroutine(SpecialCountdown(30));

        yield return new WaitForSeconds(duration);

        playerAudioSource.clip = gameManagerObject.GetComponent<GameManager>().specialOverSound;
        playerAudioSource.Play();

        specialFX_Wilbur.SetActive(false);

        wilbursWall.SetActive(false);

        yield return null;

    }

    IEnumerator ThedaSpecial(int duration)
    {
        playerAudioSource.clip = gameManagerObject.GetComponent<GameManager>().character3SpecialSound;
        playerAudioSource.Play();

        specialFX_Theda.SetActive(true);

        aSenseOfUrgency = true;

        // Start cooldown coroutine.
        StartCoroutine(SpecialCountdown(20));

        yield return new WaitForSeconds(duration);

        playerAudioSource.clip = gameManagerObject.GetComponent<GameManager>().specialOverSound;
        playerAudioSource.Play();

        specialFX_Theda.SetActive(false);

        aSenseOfUrgency = false;

        yield return null;
    }

    IEnumerator SpecialCountdown(int duration)
    {
        // Start the special icon countdown animation.
        gameManagerObject.GetComponent<GameManager>().specialIconAnimator.SetBool("Special", true);
        

        yield return new WaitForSeconds(duration);
        gameManagerObject.GetComponent<GameManager>().audioSource.PlayOneShot(gameManagerObject.GetComponent<GameManager>().specialCountDown);
        gameManagerObject.GetComponent<GameManager>().specialIconAnimator.SetBool("Special", false);

        specialReady = true;

        yield return null;
    }
}
