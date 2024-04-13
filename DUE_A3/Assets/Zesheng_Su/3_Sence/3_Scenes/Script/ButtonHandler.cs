using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void OnButtonClick()
    {
        LoadMenuScene();
    }

    private void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu"); 
    }
}

