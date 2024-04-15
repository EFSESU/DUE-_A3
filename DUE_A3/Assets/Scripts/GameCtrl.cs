using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameCtrl : MonoBehaviour
{
    public static GameCtrl Instance = null;


    private void Awake()
    {
        Instance = this;
    }
    private Obects[] obects;

    public  int objsCount;
    // Start is called before the first frame update
    void Start()
    {
        obects = FindObjectsOfType<Obects>();
        objsCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        FinishGame();
    }

    private void FinishGame()
    {
        if (objsCount==10)
        {
            SceneManager.LoadScene(4);
        }
    }

    public void AddObjsCount()
    {
        objsCount++;
        Debug.Log(objsCount);
    }
}
