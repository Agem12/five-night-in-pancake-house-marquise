using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCameraButton : MonoBehaviour,iCameraButton
{
    [SerializeField] private CameraSwitcher cameraSwitcher;
    [SerializeField] private int index;
    [SerializeField] private CanvasGroup cameraPanel;
    private bool isPanel = true;
   private Button button;
    private void Awake()

    {
        button = GetComponent<Button>();
    }
    private void ChancgeActivity()
    {
        if(isPanel == false)
        {
            cameraPanel.alpha = 1;
            cameraPanel.interactable = true;
            
        }
        else
        {
            cameraPanel.alpha = 0;
            cameraPanel.interactable = false;
            
        }
        isPanel = !isPanel;
    }







    private void OnEnable()
    {
        button.onClick.AddListener(OnMouseClick);
       
    }
    public void OnMouseClick()
    {
        cameraSwitcher.ChangeCameras(index);
        ChancgeActivity();
    }
    private void OnDisable()
    {
        button.onClick.RemoveListener(OnMouseClick);
    }


}
