using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManagerWrapper : MonoBehaviour
{
    private GameObject characterManagerObject;

    // Start is called before the first frame update
    void Start()
    {
        characterManagerObject = GameObject.FindGameObjectWithTag("CharacterManager");
    }

    public void savePlayerNameWrapper()
    {

        characterManagerObject.GetComponent<CharacterManager>().SavePlayerName();
    }
}
