using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tree : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("treeTag"))
        {
            Destroy(other.gameObject);
            score += 20; // 每次碰撞得分加1
           UpdateScoreText();
            // 当分数达到20时，加载场景2
             if (score >= 40)
            {
                SceneManager.LoadScene("2_Zhibo Liu");
            }
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Money: " + score.ToString();
        }
    }
}

