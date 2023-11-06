using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorButton : MonoBehaviour
{
    [SerializeField] private Material buttonon;
    [SerializeField] private Material buttonoff;
    [SerializeField] private EnergyScript energyScript;
    
    private MeshRenderer meshRenderer;
    private bool active = false;
    public bool Active => active;
    public event UnityAction GadgetEneble;
    public event UnityAction GadgetDisable;

    private void OnMouseDown()
    {
        active = !active;
        if (active == true)
        {
            meshRenderer.material = buttonon;
            GadgetEneble?.Invoke();
        } 
        else
        {
            meshRenderer.material = buttonoff;
            GadgetDisable?.Invoke();
        }
           
    }
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void OnEnergyIsGone()
    {
        active = false;
        meshRenderer.material = buttonoff;
        GadgetDisable?.Invoke();
    }
    private void OnEnable()
    {
        energyScript.EnergyIsGone += OnEnergyIsGone;
    }
    private void OnDisable()
    {
        energyScript.EnergyIsGone -= OnEnergyIsGone;
    }




}
