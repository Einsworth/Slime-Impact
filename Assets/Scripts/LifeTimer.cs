using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimer : MonoBehaviour
{
    public GameObject Slime;

    public float lifeTime;
    float StartTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(Slime, lifeTime);
    }

    private void Update()
    {
        StartTime += Time.deltaTime;
        if (StartTime >= lifeTime-1)
        {
            GetComponent<Animator>().enabled = true;
        }
    }
}
