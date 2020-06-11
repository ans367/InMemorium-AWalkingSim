using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{

    //Travis made this one work too. Hi Val!
    public GameObject grabFlower01;
    public GameObject spawnPoint01;
    public GameObject grabFlower02;
    public GameObject spawnPoint02;
    public GameObject grabFlower03;
    public GameObject spawnPoint03;

    private Vector3 flowerOnePos;
    private Vector3 flowerTwoPos;
    private Vector3 flowerThreePos;

    private Vector3 basketRange;
    public float basketSensitivity;
    public float spawnSensitivity;
    private Vector3 flowerOneProx;
    private Vector3 flowerTwoProx;
    private Vector3 flowerThreeProx;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(grabFlower01, spawnPoint01.transform.position, Quaternion.identity);
        Instantiate(grabFlower02, spawnPoint02.transform.position, Quaternion.identity);
        Instantiate(grabFlower03, spawnPoint03.transform.position, Quaternion.identity);
        basketRange.Set(basketRange.x * basketSensitivity, basketRange.y * basketSensitivity, basketRange.z * basketSensitivity);
    }

    // Update is called once per frame
    void Update()
    {
        flowerOnePos = grabFlower01.transform.position;
        flowerTwoPos = grabFlower02.transform.position;
        flowerThreePos = grabFlower03.transform.position;

        flowerOneProx = basketRange - flowerOnePos;
        flowerTwoProx = basketRange - flowerTwoPos;
        flowerThreeProx = basketRange - flowerThreePos;


        //spawn flower one if not close enough to basket
        if (Mathf.Abs(flowerOneProx.x) >= spawnSensitivity || Mathf.Abs(flowerOneProx.z) >= spawnSensitivity)
        {
            Instantiate(grabFlower01, spawnPoint01.transform.position, Quaternion.identity);
        }

        //spawn flower two if not close enough to basket
        if (Mathf.Abs(flowerTwoProx.x) >= spawnSensitivity || Mathf.Abs(flowerTwoProx.z) >= spawnSensitivity)
        {
            StartCoroutine(SpawnFlowerTwo());
        }

        IEnumerator SpawnFlowerTwo()
        {
            Instantiate(grabFlower02, spawnPoint02.transform.position, Quaternion.identity);
            return null;
        }



        //spawn flower three if not close enough to basket
        if (Mathf.Abs(flowerThreeProx.x) >= spawnSensitivity || Mathf.Abs(flowerThreeProx.z) >= spawnSensitivity)
        {
            Instantiate(grabFlower03, spawnPoint03.transform.position, Quaternion.identity);
        }

    }
}
