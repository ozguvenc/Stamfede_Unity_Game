using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(selfDestroy(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator selfDestroy(int time)
    {
        yield return new WaitForSecondsRealtime(time);
        Destroy(gameObject);
    }
}
