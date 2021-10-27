using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public static float TimeLeft = 300;
    public static bool OverYet;
    Text TimeText;

    public GameObject MenuPanel;

    // Start is called before the first frame update
    void Start()
    {
        TimeText = GetComponent<Text>();
        OverYet = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (OverYet == false)
        {
            TimeLeft -= Time.deltaTime;
        }

        TimeText.text = "Time : " + (int)TimeLeft;

        if (TimeLeft <= 0)
        {
            GameOver();
        }
    }

    //GGEZ
    void GameOver()
    {
        OverYet = true;
        SpawnControl.spawnAllowed = false;
        SpawnControl.soundEnd = true;
        Destroy(GameObject.FindWithTag("Slime"));
        Destroy(GameObject.FindWithTag("Summon"));
        Destroy(GameObject.FindWithTag("Boss"));
        MenuPanel.SetActive(true);
    }
}
