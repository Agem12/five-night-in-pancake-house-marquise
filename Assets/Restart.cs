using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();

    }
    private void OnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnEnable()
    {
        button.onClick.AddListener(OnClick);
    }
    private void OnDisable()
    {
        button.onClick.RemoveListener(OnClick);
    }





}
