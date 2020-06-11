using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using System.IO;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    public int currLevel = 0;

    public string[] levelNames = new string[2] { "InM_VerticalSlice_MainMenu_v01", "InM_VerticalSlice_Wall_v01" };

    static LevelSwitch s = null;

    public GameObject teleport;
    public GameObject player;
    private Vector3 playerPos;
    private Vector3 tpPos;
    private Vector3 prox;
    private Vector3 closeEnough;


    

    void Start()
    {
        if (s == null)
            s = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

        playerPos = player.transform.position;
        tpPos = teleport.transform.position;
        closeEnough.Set(0.1f, 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        prox = tpPos - playerPos;
        //Travis is a Wizard
        if(Mathf.Abs (prox.x) <= 1 )
        {
            Debug.Log("You better be seeing roses");
            currLevel = (currLevel + 1) % 2; //next level
            SteamVR_LoadLevel.Begin(levelNames[currLevel]);
        }
    }
}
