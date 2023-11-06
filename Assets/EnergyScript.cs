using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnergyScript : MonoBehaviour
{
    [SerializeField] private DoorButton[] doorButtons;

    [SerializeField] private MainCameraButton mainCameraButton;

    [SerializeField] private float energy = 100;

    [SerializeField] private float spendEnergyAmount = 1;

    private float CourentEnergyAmount = 0;

    public event UnityAction EnergyIsGone;

    private void Update()
    {
        if (energy > 0)
        {
            energy -= CourentEnergyAmount * Time.deltaTime;
        }
        else
        {
            EnergyIsGone?.Invoke();

        }
    }
    private void onGadgetEnedle()
    {
        CourentEnergyAmount += spendEnergyAmount;
    }
    private void onGadgetDiseble()
    {
        CourentEnergyAmount -= spendEnergyAmount;
    }
    private void OnEnable()
    {
        foreach (var item in doorButtons)
        {
            item.GadgetEneble += onGadgetEnedle;
            item.GadgetDisable += onGadgetDiseble;
        }
        mainCameraButton.GadgetEneble += onGadgetEnedle;
        mainCameraButton.GadgetDisable += onGadgetDiseble;
    }







}
