using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackbox : MonoBehaviour
{
    public List<GameObject> objectsToSpawn;
    GameObject instance;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            instance = Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Count)], transform.position, Quaternion.identity);
            instance.AddComponent<BlackBoxReady>();
        }
    }
}
