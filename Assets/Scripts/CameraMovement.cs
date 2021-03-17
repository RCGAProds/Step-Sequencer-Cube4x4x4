using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target;

    [Header("Sensibility Settings")]
    public float sensHorizontal = 50f;
    public float sensVertical = 50f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) // kbhjkvgckgckghckhg
        {
            Movement();
        }
    }
    void Movement()
    {
        float movH = Input.GetAxis("Mouse X");
        float movV = Input.GetAxis("Mouse Y");

        transform.LookAt(target);

        if (movH > 0) //Right
        {
            transform.RotateAround(target.position, target.right, movH * Time.deltaTime * -sensHorizontal);
        }
        else if (movH < 0) //Left
        {
            transform.RotateAround(target.position, target.right, -movH * Time.deltaTime * sensHorizontal);
        }

        if (movV > 0) //Up
        {
            transform.RotateAround(target.position, target.up, -movV * Time.deltaTime * sensVertical);
        }
        else if (movV < 0) //Down
        {
            transform.RotateAround(target.position, target.up, movV * Time.deltaTime * -sensVertical);
        }
    }
}
