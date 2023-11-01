using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private Camera[] cameras;
    [SerializeField] private Player player;
    void Start()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if (i == 0)
                cameras[i].gameObject.SetActive(true);
            else
                cameras[i].gameObject.SetActive(false);
        }

    }

    public void ChangeCameras(int cameraIndex)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameraIndex == i)
                cameras[i].gameObject.SetActive(true);
            else
                cameras[i].gameObject.SetActive(false);
        }
    }
    private void OnDie()
    {
        ChangeCameras(0);
    }
    private void OnEnable()
    {
        player.Dead += OnDie;
    }
    private void OnDisable()
    {
        player.Dead -= OnDie;
    }


}
