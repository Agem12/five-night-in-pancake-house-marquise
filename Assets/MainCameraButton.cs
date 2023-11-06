using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainCameraButton : MonoBehaviour,iCameraButton
{
    [SerializeField] private CameraSwitcher cameraSwitcher;
    [SerializeField] private int index;
    [SerializeField] private CanvasGroup cameraPanel;
    [SerializeField] private EnergyScript EnergyScript;
   private bool isPanel = true;
   private Button button;
    public event UnityAction GadgetEneble;
    public event UnityAction GadgetDisable;
    private void Awake()


    {
        button = GetComponent<Button>();
    }
    private void ChancgeActivity()
    {
        if(isPanel == false)

        {
            GadgetEneble?.Invoke();
            cameraPanel.alpha = 1;
            cameraPanel.interactable = true;
            
        }

        else
        {
            cameraPanel.alpha = 0;
            cameraPanel.interactable = false;
            GadgetDisable?.Invoke();
        }
        isPanel = !isPanel;
    }

    private void onEnergyIsGone()
    {
        cameraPanel.alpha = 0;
        cameraPanel.interactable = false;
        cameraSwitcher.ChangeCameras(index); 
        GadgetDisable?.Invoke();
    }
    





    private void OnEnable()
    {
        button.onClick.AddListener(OnMouseClick);

        EnergyScript.EnergyIsGone += onEnergyIsGone;
    }
    public void OnMouseClick()
    {
        cameraSwitcher.ChangeCameras(index);
        ChancgeActivity();
    }
    private void OnDisable()
    {
        button.onClick.RemoveListener(OnMouseClick);

        EnergyScript.EnergyIsGone -= onEnergyIsGone;
    }
    


}
