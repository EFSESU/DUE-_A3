using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndWin : MonoBehaviour
{
    public Text content;

    int GameIndex;

    private Button nextGameBtn;
    // Start is called before the first frame update
    void Start()
    {
        GameIndex = 1;
        nextGameBtn = transform.Find("NextBtn").GetComponent<Button>();
        nextGameBtn.onClick.AddListener(NextGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(string texts)
    {
        content.text = texts;
    }

    public void OnCloseBtnClick()
    {
        // GameManager.gameState = GameState.playing;
        // GameManager.playTime = 30f;
        // gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void OnReloadBtnClick(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    private void NextGame()
    {
        GameManager.Instance.NextGame();
    }
}
