using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour


{

    [SerializeField] private Player player;

    [SerializeField] private Transform[] movePoints;

    [SerializeField] private float mineTime;

    [SerializeField] private float maxTime;

    [SerializeField] private DoorButton doorButton;

    private float correntTime;

    private AudioSource audioSource;

    private int index = 0;

    private void Start()
    {
        correntTime = Random.Range(mineTime, maxTime);
        audioSource = GetComponent<AudioSource>();
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
                    if (doorButton.Active == false)
                    {
                       // audioSource.PlayOneShot(audioSource.clip);
                        transform.position = new Vector3(-5,-2,4);
                        player.Die();
                        
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



}
