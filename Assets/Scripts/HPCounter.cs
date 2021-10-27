using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPCounter : MonoBehaviour
{
    public static int HPValue = 3;
    public static bool Winable;
    Text HP;

    public GameObject MenuPanel;
    public GameObject WinPanel;

    // Start is called before the first frame update
    void Start()
    {
        Winable = false;
        HP = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        HP.text = "HP : " + HPValue;
        if (HPValue <= 0)
        {
            GameOver();
        }
        if (Winable == true)
        {
            VictoryEz();
        }
    }

    //GGEZ
    void GameOver()
    {
        TimeCounter.OverYet = true;
        SpawnControl.spawnAllowed = false;
        SpawnControl.soundEnd = true;
        Destroy(GameObject.FindWithTag("Slime"));
        Destroy(GameObject.FindWithTag("Summon"));
        Destroy(GameObject.FindWithTag("Boss"));
        MenuPanel.SetActive(true);
    }

    //Winable Baby
    void VictoryEz()
    {
        TimeCounter.OverYet = true;
        SpawnControl.SpikeStrike = false;
        SpawnControl.soundEnd = true;
        Destroy(GameObject.FindWithTag("Summon"));
        WinPanel.SetActive(true);
    }
}