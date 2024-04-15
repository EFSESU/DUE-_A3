using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    start,
    playing,
    show,
    jizhong,
    runying,
    over
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    private void Awake()
    {
        Instance = this;
    }

    public static GameState gameState = GameState.start;
    public Text scoreText;
    public static int score;
    public Slider timeSlider;
    public static float playTime;
    private float timeNum;
    public int dishuIndex = -1;

    public GameObject btnStart;
    public GameObject endWin;
    public GameObject[] didong;

    public GameObject obj;

    private float stopTime = 0.7f;

    public int GameIndex;

    public Action LoadSceneCallBack;

 

    // Start is called before the first frame update
    void Start()
    {
        GameManager.gameState = GameState.start;
        if (int.Parse(SceneManager.GetActiveScene().name)==1)
        {
            playTime = 30;
            timeNum = playTime;
            GameManager.playTime = 30;
            timeNum = GameManager.playTime;
        }
        if (int.Parse(SceneManager.GetActiveScene().name) == 2)
        {
            playTime = 48;
            timeNum = playTime;
            GameManager.playTime = 48;
            timeNum = GameManager.playTime;
        }
        if (int.Parse(SceneManager.GetActiveScene().name) == 3)
        {
            playTime = 60;
            timeNum = playTime;
            GameManager.playTime = 60;
            timeNum = GameManager.playTime;
        }
      

        

        if (int.Parse(SceneManager.GetActiveScene().name) < 2)
        {
            endWin.transform.GetChild(1).gameObject.SetActive(false);
        }
        else 
        {
            endWin.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 scPos = Camera.main.WorldToScreenPoint(obj.transform.position);

        Vector3 mousePos = Input.mousePosition;

        mousePos.z = scPos.z;

        Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(mousePos);

        obj.transform.position = mousePosInWorld;


        if (GameManager.gameState == GameState.start ||
        GameManager.gameState == GameState.over)
        {
            return;
        }

        // 倒计时游戏结束
        GameManager.playTime -= Time.deltaTime;
        timeSlider.value = GameManager.playTime / timeNum;
        print("gameTime == " + timeSlider.value);
        if (timeSlider.value <= 0)
        {
            GameManager.gameState = GameState.over;
            endWin.SetActive(true);
            if (int.Parse(SceneManager.GetActiveScene().name) == 1)
            {
                endWin.GetComponent<EndWin>().Init("下一关");
            }
            if (int.Parse(SceneManager.GetActiveScene().name) == 2)
            {
                endWin.GetComponent<EndWin>().Init("下一关");
            }
            if (int.Parse(SceneManager.GetActiveScene().name) == 3)
            {
                endWin.GetComponent<EndWin>().Init("游戏结束");
            }

          
        }

        // 点击鼠标打老鼠
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "mouse")
                {
                    print("打住小老鼠");
                    // GameManager.gameState = GameState.jizhong;
                    hit.collider.gameObject.GetComponent<DiShu>().jizhongs();
                }
            }

        }

        // 出现老鼠
        if (GameManager.gameState == GameState.runying ||
         GameManager.gameState == GameState.jizhong ||
         GameManager.gameState == GameState.playing)
        {
            stopTime -= Time.deltaTime;
            if (stopTime <= 0)
            {
                ShowMouse();
                stopTime = 0.7f;
            }
        }

        scoreText.text = score.ToString();

        Debug.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction * 100, Color.blue);
    }

    // 出现老鼠
    private void ShowMouse()
    {
        int ran = UnityEngine.Random.Range(0, 9);
        // print("随机值" + ran);
        if (ran != dishuIndex)
        {
            dishuIndex = didong[ran].GetComponent<DiDong>().InitDiDong();
        }
    }

    // 开始按钮
    public void OnStartBtnClick()
    {
        btnStart.SetActive(false);
        GameManager.gameState = GameState.playing;
    }

    public void NextGame()
    {
        GameIndex=int.Parse(SceneManager.GetActiveScene().name);
        if (GameIndex>2)
        {
            GameIndex = -1;
        }
      
        endWin.GetComponent<EndWin>().OnReloadBtnClick(GameIndex+1);

    }
}
