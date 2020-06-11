using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerToWall : MonoBehaviour
{
    public GameObject flowerA;
    public GameObject flowerB;
    //public GameObject throwFlowerA;
    
    // Start is called before the first frame update
    void Start()
    {
        flowerA.SetActive(false);
        flowerB.SetActive(true);
        //gameObject.tag = "grabFlower";
        //gameObject.tag = "wall";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Thanks Red
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("grabFlower"))
        {
            //destroys the flower in players hand
            Destroy(other.gameObject);
            //sets wall flower to On
            flowerA.SetActive(true);

        }
        

    }

    
}
