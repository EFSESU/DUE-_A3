using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class money : MonoBehaviour
{ 
    public float score = 80;
    public Text scoreText;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;
        float remainingTime = 100f - elapsedTime;

        string minutes = ((int)remainingTime / 60).ToString("00");
        string seconds = (remainingTime % 60).ToString("00");
        score = remainingTime-40;
        UpdateScoreText();
        if(score<=0){
            SceneManager.LoadScene("3_Zesheng Su");
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Money: " + score.ToString("0");
        }
    }
}
