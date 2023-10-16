using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraButtonScript : MonoBehaviour,iCameraButton
{
    [SerializeField] private CameraSwitcher cameraSwitcher;
    [SerializeField] private int index;
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
    }
    public void OnMouseClick()
    {
        cameraSwitcher.ChangeCameras(index);
        
    }
    private void OnEnable()
    {
        button.onClick.AddListener(OnMouseClick);
    }
    private void OnDisable()
    {
        button.onClick.RemoveListener(OnMouseClick);
    }





}
