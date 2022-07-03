using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    private List<GameObject> animalPrefabs;
    private GameObject levelManagerObject;
    public float spawnRangeX = 20;
    public float spawnPosZ = 50;
    public float startDelay = 2;
    public float spawnInterval;
    private GameObject animalsFolder;
    public GameObject gameManagerObject;
    private bool spawnStarted;

    // Start is called before the first frame update
    void Start()
    {
        spawnInterval = gameManagerObject.GetComponent<GameManager>().spawnInterval;
        levelManagerObject = GameObject.FindGameObjectWithTag("LevelManager");
        animalsFolder = GameObject.Find("Animals");
        spawnStarted = false;
    }

    // Update is called once per frame
    void Update()
    {

        if((gameManagerObject.GetComponent<GameManager>().levelRunning == true) 
            && (spawnStarted == false) 
            && (levelManagerObject.GetComponent<LevelManager>().chosenLevelLoaded = true))
        {

            animalPrefabs = gameManagerObject.GetComponent<GameManager>().animalsInLevel;
            InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);

            spawnStarted = true;
        }
   
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Count);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        GameObject newAnimalClone = Instantiate(animalPrefabs[animalIndex], spawnPos, gameObject.transform.rotation);
        newAnimalClone.transform.parent = animalsFolder.transform;
    }

}
