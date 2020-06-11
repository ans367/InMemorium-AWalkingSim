using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialLightGuyTalk : MonoBehaviour
{

    public GameObject one;
    public GameObject two;
    public GameObject three;
    void Start()
    {
        one.SetActive(true);
       //two.SetActive(false);
       //three.SetActive(false);
        StartCoroutine(WaitXSeconds(5));
        one.SetActive(false);
        StartCoroutine(WaitXSeconds(6));
        two.SetActive(true);
        StartCoroutine(WaitXSeconds(11));
        two.SetActive(false);
        StartCoroutine(WaitXSeconds(12));
        three.SetActive(true);
        StartCoroutine(WaitXSeconds(17));
        three.SetActive(false);

      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitXSeconds(float x)
    {
        yield return new WaitForSeconds(x);
    }
}
