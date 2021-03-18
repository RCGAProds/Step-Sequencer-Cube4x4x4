using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Raycast Settings")]
    public LayerMask layerRaycast;

    Ray[] ray = new Ray[6];
    RaycastHit hit;

    [Header("Movement Settings")]
    public float speed = 0.5f;

    bool canMoveUp, canMoveRight, canMoveDown, canMoveLeft, canMoveIn, canMoveOut;

    [Header("Select Settings")]
    public bool isSelected;
    public Material unSelectedMat;
    public Material selectedMat;

    Renderer rend;

    Vector3 initialPosition;

    void Start()
    {
        ray[0].direction = transform.up;
        ray[1].direction = transform.right;
        ray[2].direction = -transform.up;
        ray[3].direction = -transform.right;
        ray[4].direction = transform.forward;
        ray[5].direction = -transform.forward;

        rend = GetComponent<Renderer>();

        initialPosition = transform.position;
    }

    void Update()
    {
        if (isSelected)
        {
            Detect();
            Controls();
        }

        if (initialPosition == transform.position)
        {
            GameManager.gM.canBuild = false;
        }
        else
        {
            GameManager.gM.canBuild = true;
        }

        //switch (transform.position)
        //{
        //    case Vector3 (0.5f,1f,1.5f):
        //        //Activar Sonido
        //        break;
        //}
    }

    private void Detect() //Detect if the raycast are hitting a edge
    {
        for (int i = 0; i < ray.Length; i++)
        {
            ray[i].origin = transform.position;
        }

        if (Physics.Raycast(ray[0], out hit, Mathf.Infinity, layerRaycast))
        {
            canMoveUp = true;
        }
        else { canMoveUp = false; }
        if (Physics.Raycast(ray[1], out hit, Mathf.Infinity, layerRaycast))
        {
            canMoveRight = true;
        }
        else { canMoveRight = false; }
        if (Physics.Raycast(ray[2], out hit, Mathf.Infinity, layerRaycast))
        {
            canMoveDown = true;
        }
        else { canMoveDown = false; }
        if (Physics.Raycast(ray[3], out hit, Mathf.Infinity, layerRaycast))
        {
            canMoveLeft = true;
        }
        else { canMoveLeft = false; }
        if (Physics.Raycast(ray[4], out hit, Mathf.Infinity, layerRaycast))
        {
            canMoveIn = true;
        }
        else { canMoveIn = false; }
        if (Physics.Raycast(ray[5], out hit, Mathf.Infinity, layerRaycast))
        {
            canMoveOut = true;
        }
        else { canMoveOut = false; }

        DebugRay();
    }

    void DebugRay() //Show the raycast
    {
        Debug.DrawRay(ray[0].origin, ray[0].direction, Color.red);
        Debug.DrawRay(ray[1].origin, ray[1].direction, Color.red);
        Debug.DrawRay(ray[2].origin, ray[2].direction, Color.red);
        Debug.DrawRay(ray[3].origin, ray[3].direction, Color.red);
        Debug.DrawRay(ray[4].origin, ray[4].direction, Color.red);
        Debug.DrawRay(ray[5].origin, ray[5].direction, Color.red);
    }

    private void Controls() //Inputs + Movement
    {
        if (Input.GetKey(KeyCode.W) && canMoveUp)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && canMoveLeft)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && canMoveDown)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) && canMoveRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q) && canMoveIn)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E) && canMoveOut)
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
    }

    public void Click() //Controller Selected
    {
        isSelected = true;
        rend.material = selectedMat;
        GameManager.gM.controllerSelected = this.gameObject;
    }
    public void UnClick() //Controller Unselected
    {
        isSelected = false;
        rend.material = unSelectedMat;
        GameManager.gM.controllerSelected = null;
    }
}
