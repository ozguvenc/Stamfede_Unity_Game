using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBoxChanger : MonoBehaviour
{
    private float animalColliderMultiplyer;

    // Start is called before the first frame update
    void Start()
    {
        animalColliderMultiplyer = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().animalHitBoxMultiplyer;
        BoxCollider animalCollider = gameObject.GetComponent<BoxCollider>();
        animalCollider.size = new Vector3(animalCollider.size.x * animalColliderMultiplyer, animalCollider.size.y, animalCollider.size.z);
    }
}
