using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoserChooser : MonoBehaviour
{

    private GameObject characterManagerObject;
    private int characterIndex;


    // Start is called before the first frame update
    void Start()
    {

        characterManagerObject = GameObject.FindGameObjectWithTag("CharacterManager");
        characterIndex = characterManagerObject.GetComponent<CharacterManager>().characterIndex;
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Characters");


        for(int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(false);
        }
        characters[characterIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
