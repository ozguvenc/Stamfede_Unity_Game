using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40.0f;
    private float movementMultiplyer;

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.tag == "Animal")
        {
            movementMultiplyer = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().animalMovementMultiplyer;
        }
        else if (gameObject.tag == "Projectile")
        {
            movementMultiplyer = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().projectileMovementMultiplyer;
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed * movementMultiplyer);    
    }
}
