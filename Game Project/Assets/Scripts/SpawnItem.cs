using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public Transform[] SpawnPoints;//Generate an array of location
    public float spawnTime = 3f;//How long would I generate an item
    public GameObject[] Items;//Genarate what item

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnItems",  spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnItems()
    {
        int pointIndex = Random.Range(0, SpawnPoints.Length);
        int itemIndex= Random.Range(0, Items.Length);
        Instantiate(Items[itemIndex], SpawnPoints[pointIndex].position, SpawnPoints[pointIndex].rotation);
    }
}
