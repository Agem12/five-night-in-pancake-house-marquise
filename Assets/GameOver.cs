using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private CanvasGroup gemeOver;
    [SerializeField] private CanvasGroup[] elements;

    private void Start()
    {
        DisableElement(gemeOver);   
    }
    private void OnEnable()
    {
        player.Dead += OnDie;
    }

    private void OnDisable()
    {
        player.Dead -= OnDie;
    }
    private void EnableElement(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
    private void DisableElement(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

    }
    private void OnDie ()
    {
        StartCoroutine(Die());
        for (int i = 0; i < elements.Length; i++)
        {
            DisableElement(elements[i]);
        }
        
    }
    private IEnumerator Die()
    {
        yield return new WaitForSeconds(3);
        EnableElement(gemeOver);
    }
    


}
