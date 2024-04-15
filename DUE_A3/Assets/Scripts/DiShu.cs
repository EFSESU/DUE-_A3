using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiShu : MonoBehaviour
{
    private bool isShowing = false;
    private bool isRuning = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isRuning == false)
        {
            if (gameObject.transform.position.y <= 0.9f)
            {
                gameObject.transform.Translate(Vector3.up * 5f * Time.deltaTime);
            }
        }
        else if (isRuning == true)
        {
            if (gameObject.transform.position.y >= -0.9f)
            {
                gameObject.transform.Translate(Vector3.down * 5f * Time.deltaTime);
                if (gameObject.transform.position.y <= -0.9f)
                {
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                    isShowing = false;
                }
            }
        }
    }

    public void init()
    {
        if (isShowing == false)
        {
            GameManager.gameState = GameState.show;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            if (GameManager.gameState != GameState.jizhong)
            {
                StartCoroutine("GoingMouse");
            }
            isShowing = true;
            isRuning = false;
        }
    }

    public void jizhongs()
    {
        GameManager.gameState = GameState.jizhong;
        GameManager.score += 1;
        gos();

    }

    public void Runings()
    {
        GameManager.gameState = GameState.runying;
        gos();
    }

    private void gos()
    {
        isRuning = true;
    }

    IEnumerator GoingMouse()
    {
        yield return new WaitForSeconds(3f);
        GameManager.gameState = GameState.runying;
        gos();
    }
}
