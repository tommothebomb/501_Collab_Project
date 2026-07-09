using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour
{
    // this script is to destroy the falling objects once they leave the screen
    // #optimisation
    // #frames
    // #hashtag

    void Start()
    {
        StartCoroutine(DestroyObject()); 
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(25f);
        Destroy(gameObject);
    }
}
