using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 100.0f;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.position = transform.position + movement * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        Vector3 dir = movement.normalized;
        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(dir);
            _animator.SetBool("is Run", true);
            transform.Translate(Vector3.forward * 5 * Time.deltaTime);
        }
        else
        {
            _animator.SetBool("is Run", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            _animator.Play("axe");
        }

    }
}



