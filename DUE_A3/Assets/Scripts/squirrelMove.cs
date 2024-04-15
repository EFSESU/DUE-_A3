using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class squirrelMove : MonoBehaviour
{


    public float moveSpeed = 5f;
    public float rotateSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        float rotateY = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;

        transform.Translate(moveX, 0, moveZ);

        transform.Rotate(0, rotateY, 0);
    }

    private void OnTriggerEnter(Collider o)
    {
        if (o.tag=="cube")
        {
            SceneManager.LoadScene(2);
        }

        
    }
}
