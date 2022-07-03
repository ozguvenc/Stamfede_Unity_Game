using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisableIntroAnimations : MonoBehaviour
{
    private int introAnimationsPlayed;
    private bool alreadyDisabledAnimations;
    public GameObject[] animatedUI = new GameObject[6];
    // Start is called before the first frame update
    void Start()
    {
        introAnimationsPlayed = 0;
        alreadyDisabledAnimations = false;
}

    // Update is called once per frame
    void Update()
    {
        if ((SceneManager.GetActiveScene().name == "0.2_MainMenu") && (introAnimationsPlayed > 0))
        {
            animatedUI = GameObject.FindGameObjectsWithTag("Animated");

            for (int i = 0; i < animatedUI.Length; i++)
            {
                animatedUI[i].GetComponent<Animator>().enabled = false;
            }
            introAnimationsPlayed ++;
            alreadyDisabledAnimations = true;
        }
    }

    public void disableIntroAnimations()
    {
        introAnimationsPlayed ++;
        alreadyDisabledAnimations = false;
    }
}
