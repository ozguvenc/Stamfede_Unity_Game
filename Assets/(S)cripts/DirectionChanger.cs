using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DirectionChanger : MonoBehaviour
{
    public GameObject gameManagerObject;
    private GameObject particleEffects;

    // Start is called just before any of the Update methods is called the first time
    private void Start()
    {
        particleEffects = GameObject.Find("ParticleEffects");
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Chicken(Clone)" )
        {
            gameManagerObject.GetComponent<GameManager>().levelScore -= gameManagerObject.GetComponent<GameManager>().chickenPenalty;

            gameManagerObject.GetComponent<GameManager>().audioSource.PlayOneShot(gameManagerObject.GetComponent<GameManager>().chickenEscape);
            gameManagerObject.GetComponent<GameManager>().chickenMissedCount++;
            GameObject newParticleEffect = Instantiate(gameManagerObject.GetComponent<GameManager>().escapeParticle, other.transform.position, other.transform.rotation);
            newParticleEffect.transform.parent = particleEffects.transform;
            GameObject miss = Instantiate(gameManagerObject.GetComponent<GameManager>().missAnimation, other.transform.position, gameManagerObject.GetComponent<GameManager>().missAnimation.transform.rotation);
            miss.gameObject.transform.GetComponentInChildren<TextMeshPro>().text = gameManagerObject.GetComponent<GameManager>().chickenPenalty.ToString();

            //other.transform.rotation = Quaternion.Euler(0, ChooseDirection(other.gameObject), 0);
            other.gameObject.layer = 6;
            other.GetComponent<MoveForward>().speed = 50;

        }
        else if (other.gameObject.name == "Cow(Clone)" )
        {
            gameManagerObject.GetComponent<GameManager>().levelScore -= gameManagerObject.GetComponent<GameManager>().cowPenalty;
            gameManagerObject.GetComponent<GameManager>().cowMissedCount++;
            gameManagerObject.GetComponent<GameManager>().audioSource.PlayOneShot(gameManagerObject.GetComponent<GameManager>().cowEscape);
            var newParticleEffect = Instantiate(gameManagerObject.GetComponent<GameManager>().escapeParticle, other.transform.position, other.transform.rotation);
            newParticleEffect.transform.parent = particleEffects.transform;
            GameObject miss = Instantiate(gameManagerObject.GetComponent<GameManager>().missAnimation, other.transform.position, gameManagerObject.GetComponent<GameManager>().missAnimation.transform.rotation);
            miss.gameObject.transform.GetComponentInChildren<TextMeshPro>().text = gameManagerObject.GetComponent<GameManager>().cowPenalty.ToString();


            //other.transform.rotation = Quaternion.Euler(0, ChooseDirection(other.gameObject), 0);
            other.gameObject.layer = 6;
            other.GetComponent<MoveForward>().speed = 50;

        }
        else if (other.gameObject.name == "Horse(Clone)" )
        {
            gameManagerObject.GetComponent<GameManager>().levelScore -= gameManagerObject.GetComponent<GameManager>().horsePenalty;
            gameManagerObject.GetComponent<GameManager>().horseMissedCount++;
            gameManagerObject.GetComponent<GameManager>().audioSource.PlayOneShot(gameManagerObject.GetComponent<GameManager>().horseEscape);
            var newParticleEffect = Instantiate(gameManagerObject.GetComponent<GameManager>().escapeParticle, other.transform.position, other.transform.rotation);
            newParticleEffect.transform.parent = particleEffects.transform;
            GameObject miss = Instantiate(gameManagerObject.GetComponent<GameManager>().missAnimation, other.transform.position, gameManagerObject.GetComponent<GameManager>().missAnimation.transform.rotation);
            miss.gameObject.transform.GetComponentInChildren<TextMeshPro>().text = gameManagerObject.GetComponent<GameManager>().horsePenalty.ToString();


            //other.transform.rotation = Quaternion.Euler(0, ChooseDirection(other.gameObject), 0);
            other.gameObject.layer = 6;
            other.GetComponent<MoveForward>().speed = 50;

        }

        
    }

    public float ChooseDirection(GameObject objectToChange)
    {
        if (objectToChange.transform.position.x < 0)
        {
            return -90f;
        }
        else
        {
            return 90f;
        }
    }

}
