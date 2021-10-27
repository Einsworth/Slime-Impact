using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class RandomPatrol : MonoBehaviour
{
    public GameObject Slime;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float speed;
    public int scorePoints;
    public int ATK;
    public int HP;
    public int winCondition;

    public GameObject ClickEffect;
    private AudioSource boob;

    Vector2 TargetPosition;

    // Start is called before the first frame update
    void Start()
    {
        TargetPosition = GetRandomPosition();
        boob = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2)transform.position != TargetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, TargetPosition, speed * Time.deltaTime);
        }
        else
        {
            TargetPosition = GetRandomPosition();
        }
    }

    //Random position
    Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }

    //Touchy
    private void OnMouseDown()
    {
        boob.Play();
        Instantiate(ClickEffect, transform.position, Quaternion.identity);
        HP -= 1;
        if (HP == 0)
        {
            Destroy(Slime, 0.25f);
            HPCounter.HPValue -= ATK;
            ScoreCounter.scoreValue += scorePoints;
            if(winCondition == 1)
            {
                HPCounter.Winable = true;
            }
        }
    }
}