using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] private Material buttonon;
    [SerializeField] private Material buttonoff;
    private MeshRenderer meshRenderer;
    private bool active = false;
    public bool Active => active;

    private void OnMouseDown()
    {
        active = !active;
        if (active == true)
            meshRenderer.material = buttonon;
        else
            meshRenderer.material = buttonoff;
    }
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
}
