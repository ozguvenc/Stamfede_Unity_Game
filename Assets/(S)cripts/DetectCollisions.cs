using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DetectCollisions : MonoBehaviour
{
    private string objectName;
    private GameObject gameManagerObject;
    //public string targetName;
    private GameObject particlesFolder;


    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");
        //gameManagerObject.GetComponent<GameManager>().audioSource.PlayOneShot(gameManagerObject.GetComponent<GameManager>().projectileLaunch);
        objectName = gameObject.name;
        particlesFolder = GameObject.Find("Particles");
    }

    // Update is called once per frame
    void Update()
    {

    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if ((objectName == "chickenFood(Clone)") && (other.gameObject.name == "Chicken(Clone)"))
        {
            Debug.Log("Hit made");
            gameManagerObject.GetComponent<GameManager>().levelScore += gameManagerObject.GetComponent<GameManager>().chickenScore;
            gameManagerObject.GetComponent<GameManager>().chickenFedCount ++;
            
            gameManagerObject.GetComponent<GameManager>().audioSource.PlayOneShot(gameManagerObject.GetComponent<GameManager>().chickenEat);

            // Create new particles and place them in the corresponding folder.
            GameObject newParticleClone = Instantiate(gameManagerObject.GetComponent<GameManager>().chickenEatParticle, other.transform.position, other.transform.rotation);
            newParticleClone.transform.parent = particlesFolder.transform;

            // Create heart icon and score gained when an animal is fed.
            GameObject heart = Instantiate(gameManagerObject.GetComponent<GameManager>().heartAnimation, other.transform.position, gameManagerObject.GetComponent<GameManager>().heartAnimation.transform.rotation);
            heart.gameObject.transform.GetComponentInChildren<TextMeshPro>().text = gameManagerObject.GetComponent<GameManager>().chickenScore.ToString();

            other.transform.rotation = Quaternion.Euler(0, ChooseDirection(other.gameObject), 0);
            other.gameObject.layer = 6; ;

            other.GetComponent<MoveForward>().speed = 30;

            //Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if ((objectName == "cowFood(Clone)") && (other.gameObject.name == "Cow(Clone)"))
        {
            gameManagerObject.GetComponent<GameManager>().levelScore += gameManagerObject.GetComponent<GameManager>().cowScore;
            gameManagerObject.GetComponent<GameManager>().cowFedCount++;

            gameManagerObject.GetComponent<GameManager>().audioSource.PlayOneShot(gameManagerObject.GetComponent<GameManager>().cowEat);
            
            // Create new particles and place them in the corresponding folder.
            GameObject newParticleClone = Instantiate(gameManagerObject.GetComponent<GameManager>().cowEatParticle, other.transform.position, other.transform.rotation);
            newParticleClone.transform.parent = particlesFolder.transform;

            // Create heart icon and score gained when an animal is fed.
            GameObject heart = Instantiate(gameManagerObject.GetComponent<GameManager>().heartAnimation, other.transform.position, gameManagerObject.GetComponent<GameManager>().heartAnimation.transform.rotation);
            heart.gameObject.transform.GetComponentInChildren<TextMeshPro>().text = gameManagerObject.GetComponent<GameManager>().cowScore.ToString();

            other.transform.rotation = Quaternion.Euler(0,ChooseDirection(other.gameObject),0);
            other.gameObject.layer = 6;
            other.GetComponent<MoveForward>().speed = 40;

            Destroy(gameObject);
        }
        else if ((objectName == "horseFood(Clone)") && (other.gameObject.name == "Horse(Clone)"))
        {
            gameManagerObject.GetComponent<GameManager>().levelScore += gameManagerObject.GetComponent<GameManager>().horseScore;
            gameManagerObject.GetComponent<GameManager>().horseFedCount++;
            
            gameManagerObject.GetComponent<GameManager>().audioSource.PlayOneShot(gameManagerObject.GetComponent<GameManager>().horseEat);

            // Create new particles and place them in the corresponding folder.
            GameObject newParticleClone = Instantiate(gameManagerObject.GetComponent<GameManager>().horseEatParticle, other.transform.position, other.transform.rotation);
            newParticleClone.transform.parent = particlesFolder.transform;

            // Create heart icon and score gained when an animal is fed.
            GameObject heart = Instantiate(gameManagerObject.GetComponent<GameManager>().heartAnimation, other.transform.position, gameManagerObject.GetComponent<GameManager>().heartAnimation.transform.rotation);
            heart.gameObject.transform.GetComponentInChildren<TextMeshPro>().text = gameManagerObject.GetComponent<GameManager>().horseScore.ToString();

            other.transform.rotation = Quaternion.Euler(0, ChooseDirection(other.gameObject), 0);
            other.gameObject.layer = 6; ;
            other.GetComponent<MoveForward>().speed = 50;

            //Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if ((objectName == "Wilbur's Wall"))
        {

            gameManagerObject.GetComponent<GameManager>().audioSource.PlayOneShot(gameManagerObject.GetComponent<GameManager>().character2SpecialSound);

            // Create new particles and place them in the corresponding folder.
            GameObject newParticleClone = Instantiate(gameManagerObject.GetComponent<GameManager>().chickenEatParticle, other.transform.position, other.transform.rotation);
            newParticleClone.transform.parent = particlesFolder.transform;

            // Create heart icon and score gained when an animal is fed.
            GameObject heart = Instantiate(gameManagerObject.GetComponent<GameManager>().missAnimation, other.transform.position, gameManagerObject.GetComponent<GameManager>().heartAnimation.transform.rotation);
            heart.gameObject.transform.GetComponentInChildren<TextMeshPro>().text = "0";

            other.transform.rotation = Quaternion.Euler(0, ChooseDirection(other.gameObject), 0);
            other.gameObject.layer = 6; ;

            other.GetComponent<MoveForward>().speed = 30;
        }
    }

    public float ChooseDirection(GameObject objectToChange)
    {
        if (objectToChange.transform.position.x <0)
        {
            return -90f;
        }
        else
        {
            return 90f;
        }
    }
}
