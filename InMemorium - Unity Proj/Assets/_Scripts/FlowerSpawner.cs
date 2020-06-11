using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FlowerSpawner : MonoBehaviour
{
    //Red is the coding Wizard
    public float spawnInterval = 10f;
    public float range = 0.15f;

    public GameObject flowerPrefab;
    public GameObject spawnPoint;
    
    private float timeSinceLastSpawn = 0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        // At every interval, check spawn points
        if (timeSinceLastSpawn >= spawnInterval)
        {
            timeSinceLastSpawn = 0f;
            CheckSpawnPoints();
        }
    }


    void CheckSpawnPoints()
    {
        Vector3 position = spawnPoint.transform.position;
        Quaternion rotation = spawnPoint.transform.rotation;

        // Get names of all objects near the point
        List<string> objectsAtPoint = new List<string>();
        Collider[] colliders = Physics.OverlapSphere(position, range);
        foreach(Collider c in colliders)
        {
            string item = c.gameObject.name;
            if (!objectsAtPoint.Contains(item))
            {
                objectsAtPoint.Add(item);
            }
        }

        // Spawn and Attach
        if (!ListContainsName(objectsAtPoint, flowerPrefab.gameObject.name))
        {
            Instantiate(flowerPrefab, position, rotation);
        }
    }

    bool ListContainsName(List<String> list, string name)
    {
        return list.Contains(name) || list.Contains(name + "(Clone)");
    }
}