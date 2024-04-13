using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.SceneManagement;


public class TreeGenerator : MonoBehaviour
{
    public GameObject treePrefab; 
    public float treeSpawnRange = 5f; 
    public float treeCheckRange = 10f; 
    public GameObject player; 

    public int score = 0; 
    public UnityEngine.UI.Text scoreText; 


    private void Start()
    {
        UpdateScoreText(); 
    }

    public void SpawnTree()
    {
        Vector3 playerPosition = player.transform.position; 

        
        Vector3 spawnPosition = playerPosition + player.transform.forward * treeSpawnRange;

        
        float offsetX = UnityEngine.Random.Range(-20f, 20f); 
        float offsetZ = UnityEngine.Random.Range(-20f, 20f); 
        spawnPosition += new Vector3(offsetX, 0f, offsetZ);

        
        if (Vector3.Distance(playerPosition, spawnPosition) <= treeCheckRange)
        {
            
            Instantiate(treePrefab, spawnPosition, Quaternion.identity);
            score++; 
            UpdateScoreText(); 
        }
        
    }

    void UpdateScoreText()
    {
        
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
    private void Update()
    {
        if (score > 5)
        {
            LoadThanksScene();
        }
    }

    
    private void LoadThanksScene()
    {
        SceneManager.LoadScene("Thanks_Zesheng Su"); 
    }
}






