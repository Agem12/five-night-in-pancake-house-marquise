using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Transform[] movePoints;

    [SerializeField] private float mineTime;

    [SerializeField] private float maxTime;

    private float correntTime;

    private int index = 0;

    private void Start()
    {
        correntTime = Random.Range(mineTime, maxTime);
    }
    private void Update()
    {
        if(correntTime > 0)
        {
            correntTime -= Time.deltaTime;
            if(correntTime <= 0)
            {
                if(index < movePoints.Length - 1)
                {
                    index++;
                    transform.position = movePoints[index].position;
                    correntTime = Random.Range(mineTime, maxTime);

                }
                else
                {
                    index = 0;
                    transform.position = movePoints[index].position;
                    correntTime = Random.Range(mineTime, maxTime);

                }
            }
        }
    }



}
