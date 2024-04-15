using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public Button startBtn;

    public Button helpBtn;

    public Button closeBtn;

    public GameObject helpPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void starGeme()
    {
        SceneManager.LoadScene(1);
    }
    
    public void backGeme()
    {
        SceneManager.LoadScene(0);
    }

    public void showHelpPanel()
    {
        helpPanel.SetActive(true);
    }

    public void closeHelpPanel()
    {
        helpPanel.SetActive(false);
    }


}
