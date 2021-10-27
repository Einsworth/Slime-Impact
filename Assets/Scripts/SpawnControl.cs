using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public Transform SpawnPointBoss;
    public Transform[] SpawnSmokes;
    public GameObject[] Slimes;
    public GameObject Boss;
    public GameObject Spike;
    private GameObject[] TotalSlimes;

    int randomSpawnPoints, randomSlimes;
    int SlimesPerScreen = 20;
    public static bool spawnAllowed;
    public static bool spawnBoss;
    public static bool SpikeStrike;
    public static bool soundEnd;
    private bool spawnOnlyOnce;

    public GameObject boom;
    public GameObject smoke;

    public AudioSource bgm1;
    public AudioSource bgm2;
    public AudioSource summon;

    // Start is called before the first frame update
    void Start()
    {
        spawnAllowed = true;
        spawnBoss = false;
        SpikeStrike = false;
        spawnOnlyOnce = true;
        soundEnd = false;
        InvokeRepeating("SpawnSlimes", 0f, 0.5f);
        InvokeRepeating("SummonSpike", 0f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        TotalSlimes = GameObject.FindGameObjectsWithTag("Slime");
        if (TotalSlimes.Length >= SlimesPerScreen)
        {
            spawnAllowed = false;
        }
        else
        {
            spawnAllowed = true;
        }

        if(spawnBoss == true&&spawnOnlyOnce == true)
        {
            BossIncoming();
            SpikeStrike = true;
            spawnOnlyOnce = false;
        }

        if(soundEnd == true)
        {
            bgm1.Stop();
            bgm2.Stop();
        }
    }

    void SpawnSlimes()
    {
        if (spawnAllowed == true)
        {
            randomSlimes = Random.Range(0, Slimes.Length);
            randomSpawnPoints = Random.Range(0, SpawnPoints.Length);
            Instantiate(Slimes[randomSlimes], SpawnPoints[randomSpawnPoints].position, Quaternion.identity);
        }
    }

    void SummonSpike()
    {
        if(SpikeStrike == true)
        {
            randomSpawnPoints = Random.Range(0, SpawnPoints.Length);
            Instantiate(Spike, SpawnPoints[randomSpawnPoints].position, Quaternion.identity);
        }
    }

    void BossIncoming()
    {
        bgm1.Stop();
        bgm2.Play();
        summon.Play();
        Instantiate(boom, SpawnPointBoss.position, Quaternion.identity);
        Instantiate(smoke, SpawnSmokes[0].position, Quaternion.identity);
        Instantiate(smoke, SpawnSmokes[1].position, Quaternion.identity);
        Instantiate(smoke, SpawnSmokes[2].position, Quaternion.identity);
        Instantiate(smoke, SpawnSmokes[3].position, Quaternion.identity);
        Instantiate(Boss, SpawnPointBoss.position, Quaternion.identity);
    }
}
