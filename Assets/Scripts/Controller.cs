using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KrillAudio.Krilloud;

using System.Reflection; //For ClearLog

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

    [Header("Krilloud Settings")]
    private KLAudioSource kl;

    [KLVariable] public string kl_Variable0;
    [KLVariable] public string kl_Variable1;
    [KLVariable] public string kl_Variable2;
    [KLVariable] public string kl_Variable3;
    [KLVariable] public string kl_Variable4;

    void Start()
    {
        kl = GetComponent<KLAudioSource>();

        //Raycast Setup
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

        if (initialPosition != transform.position)
        {
            GameManager.gM.canBuild = true;
        }else{
            GameManager.gM.canBuild = false;
        }
    }

    private void Detect() //Detects if the Controller can move.
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

    public void OnCollisionEnter(Collision collision) //Here you can define the function of each vertex.
    {
        switch (collision.gameObject.tag)
        {
            case "0z":
                switch (collision.transform.parent.tag)
                {
                    case "0y":
                        GameObject parent1 = collision.transform.parent.gameObject;
                        switch (parent1.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 0y 0z");
                                kl.SetIntVar(kl_Variable0, 0);
                                break;        
                            case "1x":
                                Debug.Log("1x 0y 0z");
                                kl.SetIntVar(kl_Variable0, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 0y 0z");
                                kl.SetIntVar(kl_Variable0, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 0y 0z");
                                kl.SetIntVar(kl_Variable0, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 0y 0z");
                                kl.SetIntVar(kl_Variable0, 4);
                                break;
                        }
                        break;

                    case "1y":
                        GameObject parent2 = collision.transform.parent.gameObject;
                        switch (parent2.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 1y 0z");
                                kl.SetIntVar(kl_Variable0, 0);
                                break;
                            case "1x":
                                Debug.Log("1x 1y 0z");
                                kl.SetIntVar(kl_Variable0, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 1y 0z");
                                kl.SetIntVar(kl_Variable0, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 1y 0z");
                                kl.SetIntVar(kl_Variable0, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 1y 0z");
                                kl.SetIntVar(kl_Variable0, 4);
                                break;
                        }
                        break;

                    case "2y":
                        GameObject parent3 = collision.transform.parent.gameObject;
                        switch (parent3.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 2y 0z");
                                kl.SetIntVar(kl_Variable0, 0);
                                break;
                            case "1x":
                                Debug.Log("1x 2y 0z");
                                kl.SetIntVar(kl_Variable0, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 2y 0z");
                                kl.SetIntVar(kl_Variable0, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 2y 0z");
                                kl.SetIntVar(kl_Variable0, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 2y 0z");
                                kl.SetIntVar(kl_Variable0, 4);
                                break;
                        }
                        break;

                    case "3y":
                        GameObject parent4 = collision.transform.parent.gameObject;
                        switch (parent4.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 3y 0z");
                                kl.SetIntVar(kl_Variable0, 0);
                                break;
                            case "1x":
                                Debug.Log("1x 3y 0z");
                                kl.SetIntVar(kl_Variable0, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 3y 0z");
                                kl.SetIntVar(kl_Variable0, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 3y 0z");
                                kl.SetIntVar(kl_Variable0, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 3y 0z");
                                kl.SetIntVar(kl_Variable0, 4);
                                break;
                        }
                        break;

                    case "4y":
                        GameObject parent5 = collision.transform.parent.gameObject;
                        switch (parent5.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 4y 0z");
                                kl.SetIntVar(kl_Variable0, 0);
                                break;
                            case "1x":
                                Debug.Log("1x 4y 0z");
                                kl.SetIntVar(kl_Variable0, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 4y 0z");
                                kl.SetIntVar(kl_Variable0, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 4y 0z");
                                kl.SetIntVar(kl_Variable0, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 4y 0z");
                                kl.SetIntVar(kl_Variable0, 4);
                                break;
                        }
                        break;
                }
                break;

            case "1z":
                switch (collision.transform.parent.tag)
                {
                    case "0y":
                        GameObject parent1 = collision.transform.parent.gameObject;
                        switch (parent1.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 0y 1z");
                                kl.SetIntVar(kl_Variable1, 0);
                                break;
                            case "1x":
                                Debug.Log("1x 0y 1z");
                                kl.SetIntVar(kl_Variable1, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 0y 1z");
                                kl.SetIntVar(kl_Variable1, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 0y 1z");
                                kl.SetIntVar(kl_Variable1, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 0y 1z");
                                kl.SetIntVar(kl_Variable1, 4);
                                break;
                        }
                        break;

                    case "1y":
                        GameObject parent2 = collision.transform.parent.gameObject;
                        switch (parent2.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 1y 1z");
                                kl.SetIntVar(kl_Variable1, 0);
                                break;
                            case "1x":
                                Debug.Log("1x 1y 1z");
                                kl.SetIntVar(kl_Variable1, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 1y 1z");
                                kl.SetIntVar(kl_Variable1, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 1y 1z");
                                kl.SetIntVar(kl_Variable1, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 1y 1z");
                                kl.SetIntVar(kl_Variable1, 4);
                                break;
                        }
                        break;

                    case "2y":
                        GameObject parent3 = collision.transform.parent.gameObject;
                        switch (parent3.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 2y 1z");
                                kl.SetIntVar(kl_Variable1, 0);
                                break;
                            case "1x":
                                Debug.Log("1x 2y 1z");
                                kl.SetIntVar(kl_Variable1, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 2y 1z");
                                kl.SetIntVar(kl_Variable1, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 2y 1z");
                                kl.SetIntVar(kl_Variable1, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 2y 1z");
                                kl.SetIntVar(kl_Variable1, 4);
                                break;
                        }
                        break;

                    case "3y":
                        GameObject parent4 = collision.transform.parent.gameObject;
                        switch (parent4.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 3y 1z");
                                kl.SetIntVar(kl_Variable1, 0);
                                break;
                            case "1x":
                                Debug.Log("1x 3y 1z");
                                kl.SetIntVar(kl_Variable1, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 3y 1z");
                                kl.SetIntVar(kl_Variable1, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 3y 1z");
                                kl.SetIntVar(kl_Variable1, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 3y 1z");
                                kl.SetIntVar(kl_Variable1, 4);
                                break;
                        }
                        break;

                    case "4y":
                        GameObject parent5 = collision.transform.parent.gameObject;
                        switch (parent5.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 4y 1z");
                                kl.SetIntVar(kl_Variable1, 0);
                                break;
                            case "1x":
                                Debug.Log("1x 4y 1z");
                                kl.SetIntVar(kl_Variable1, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 4y 1z");
                                kl.SetIntVar(kl_Variable1, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 4y 1z");
                                kl.SetIntVar(kl_Variable1, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 4y 1z");
                                kl.SetIntVar(kl_Variable1, 4);
                                break;
                        }
                        break;
                }
                break;

            case "2z":
                switch (collision.transform.parent.tag)
                {
                    case "0y":
                        GameObject parent1 = collision.transform.parent.gameObject;
                        switch (parent1.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 0y 2z");
                                kl.SetIntVar(kl_Variable2, 0);
                                break;
                            case "1x":
                                Debug.Log("1x 0y 2z");
                                kl.SetIntVar(kl_Variable2, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 0y 2z");
                                kl.SetIntVar(kl_Variable2, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 0y 2z");
                                kl.SetIntVar(kl_Variable2, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 0y 2z");
                                kl.SetIntVar(kl_Variable2, 4);
                                break;
                        }
                        break;

                    case "1y":
                        GameObject parent2 = collision.transform.parent.gameObject;
                        switch (parent2.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 1y 2z");
                                kl.SetIntVar(kl_Variable2, 0);
                                break;
                            case "1x":
                                Debug.Log("1x 1y 2z");
                                kl.SetIntVar(kl_Variable2, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 1y 2z");
                                kl.SetIntVar(kl_Variable2, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 1y 2z");
                                kl.SetIntVar(kl_Variable2, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 1y 2z");
                                kl.SetIntVar(kl_Variable2, 4);
                                break;
                        }
                        break;

                    case "2y":
                        GameObject parent3 = collision.transform.parent.gameObject;
                        switch (parent3.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 2y 2z");
                                kl.SetIntVar(kl_Variable2, 0);
                                break;
                            case "1x":
                                Debug.Log("1x 2y 2z");
                                kl.SetIntVar(kl_Variable2, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 2y 2z");
                                kl.SetIntVar(kl_Variable2, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 2y 2z");
                                kl.SetIntVar(kl_Variable2, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 2y 2z");
                                kl.SetIntVar(kl_Variable2, 4);
                                break;
                        }
                        break;

                    case "3y":
                        GameObject parent4 = collision.transform.parent.gameObject;
                        switch (parent4.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 3y 2z");
                                kl.SetIntVar(kl_Variable2, 0);
                                break;
                            case "1x":
                                Debug.Log("1x 3y 2z");
                                kl.SetIntVar(kl_Variable2, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 3y 2z");
                                kl.SetIntVar(kl_Variable2, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 3y 2z");
                                kl.SetIntVar(kl_Variable2, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 3y 2z");
                                kl.SetIntVar(kl_Variable2, 4);
                                break;
                        }
                        break;

                    case "4y":
                        GameObject parent5 = collision.transform.parent.gameObject;
                        switch (parent5.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 4y 2z");
                                kl.SetIntVar(kl_Variable2, 0);
                                break;
                            case "1x":
                                Debug.Log("1x 4y 2z");
                                kl.SetIntVar(kl_Variable2, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 4y 2z");
                                kl.SetIntVar(kl_Variable2, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 4y 2z");
                                kl.SetIntVar(kl_Variable2, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 4y 2z");
                                kl.SetIntVar(kl_Variable2, 4);
                                break;
                        }
                        break;
                }
                break;

            case "3z":
                switch (collision.transform.parent.tag)
                {
                    case "0z":
                        GameObject parent1 = collision.transform.parent.gameObject;
                        switch (parent1.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 0y 3z");
                                kl.SetIntVar(kl_Variable3, 0);
                                break;
                            case "1x":
                                Debug.Log("1x 0y 3z");
                                kl.SetIntVar(kl_Variable3, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 0y 3z");
                                kl.SetIntVar(kl_Variable3, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 0y 3z");
                                kl.SetIntVar(kl_Variable3, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 0y 3z");
                                kl.SetIntVar(kl_Variable3, 4);
                                break;
                        }
                        break;

                    case "1y":
                        GameObject parent2 = collision.transform.parent.gameObject;
                        switch (parent2.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 1y 3z");
                                kl.SetIntVar(kl_Variable3, 0);
                                break;
                            case "1x":
                                Debug.Log("1x 1y 3z");
                                kl.SetIntVar(kl_Variable3, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 1y 3z");
                                kl.SetIntVar(kl_Variable3, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 1y 3z");
                                kl.SetIntVar(kl_Variable3, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 1y 3z");
                                kl.SetIntVar(kl_Variable3, 4);
                                break;
                        }
                        break;

                    case "2y":
                        GameObject parent3 = collision.transform.parent.gameObject;
                        switch (parent3.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 2y 3z");
                                kl.SetIntVar(kl_Variable3, 0);
                                break;
                            case "1x":
                                Debug.Log("1x 2y 3z");
                                kl.SetIntVar(kl_Variable3, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 2y 3z");
                                kl.SetIntVar(kl_Variable3, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 2y 3z");
                                kl.SetIntVar(kl_Variable3, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 2y 3z");
                                kl.SetIntVar(kl_Variable3, 4);
                                break;
                        }
                        break;

                    case "3y":
                        GameObject parent4 = collision.transform.parent.gameObject;
                        switch (parent4.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 3y 3z");
                                kl.SetIntVar(kl_Variable3, 0);
                                break;
                            case "1x":
                                Debug.Log("1x 3y 3z");
                                kl.SetIntVar(kl_Variable3, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 3y 3z");
                                kl.SetIntVar(kl_Variable3, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 3y 3z");
                                kl.SetIntVar(kl_Variable3, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 3y 3z");
                                kl.SetIntVar(kl_Variable3, 4);
                                break;
                        }
                        break;

                    case "4y":
                        GameObject parent5 = collision.transform.parent.gameObject;
                        switch (parent5.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 4y 3z");
                                kl.SetIntVar(kl_Variable3, 0);
                                break;
                            case "1x":
                                Debug.Log("1x 4y 3z");
                                kl.SetIntVar(kl_Variable3, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 4y 3z");
                                kl.SetIntVar(kl_Variable3, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 4y 3z");
                                kl.SetIntVar(kl_Variable3, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 4y 3z");
                                kl.SetIntVar(kl_Variable3, 4);
                                break;
                        }
                        break;
                }
                break;

            case "4z":
                switch (collision.transform.parent.tag)
                {
                    case "0y":
                        GameObject parent1 = collision.transform.parent.gameObject;
                        switch (parent1.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 0y 4z");
                                kl.SetIntVar(kl_Variable4, 0);
                                break;
                            case "1x":
                                Debug.Log("1x 0y 4z");
                                kl.SetIntVar(kl_Variable4, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 0y 4z");
                                kl.SetIntVar(kl_Variable4, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 0y 4z");
                                kl.SetIntVar(kl_Variable4, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 0y 4z");
                                kl.SetIntVar(kl_Variable4, 4);
                                break;
                        }
                        break;

                    case "1y":
                        GameObject parent2 = collision.transform.parent.gameObject;
                        switch (parent2.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 1y 4z");
                                kl.SetIntVar(kl_Variable4, 0);
                                break;
                            case "1x":
                                Debug.Log("1x 1y 4z");
                                kl.SetIntVar(kl_Variable4, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 1y 4z");
                                kl.SetIntVar(kl_Variable4, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 1y 4z");
                                kl.SetIntVar(kl_Variable4, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 1y 4z");
                                kl.SetIntVar(kl_Variable4, 4);
                                break;
                        }
                        break;
                    case "2y":
                        GameObject parent3 = collision.transform.parent.gameObject;
                        switch (parent3.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 2y 4z");
                                kl.SetIntVar(kl_Variable4, 0);
                                break;
                            case "1x":
                                Debug.Log("1x 2y 4z");
                                kl.SetIntVar(kl_Variable4, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 2y 4z");
                                kl.SetIntVar(kl_Variable4, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 2y 4z");
                                kl.SetIntVar(kl_Variable4, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 2y 4z");
                                kl.SetIntVar(kl_Variable4, 4);
                                break;
                        }
                        break;

                    case "3y":
                        GameObject parent4 = collision.transform.parent.gameObject;
                        switch (parent4.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 3y 4z");
                                kl.SetIntVar(kl_Variable4, 0);
                                break;
                            case "1x":
                                Debug.Log("1x 3y 4z");
                                kl.SetIntVar(kl_Variable4, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 3y 4z");
                                kl.SetIntVar(kl_Variable4, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 3y 4z");
                                kl.SetIntVar(kl_Variable4, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 3y 4z");
                                kl.SetIntVar(kl_Variable4, 4);
                                break;
                        }
                        break;

                    case "4y":
                        GameObject parent5 = collision.transform.parent.gameObject;
                        switch (parent5.transform.parent.tag)
                        {
                            case "0x":
                                Debug.Log("0x 4y 4z");
                                kl.SetIntVar(kl_Variable4, 0);
                                break;
                            case "1x":
                                Debug.Log("1x 4y 4z");
                                kl.SetIntVar(kl_Variable4, 1);
                                break;
                            case "2x":
                                Debug.Log("2x 4y 4z");
                                kl.SetIntVar(kl_Variable4, 2);
                                break;
                            case "3x":
                                Debug.Log("3x 4y 4z");
                                kl.SetIntVar(kl_Variable4, 3);
                                break;
                            case "4x":
                                Debug.Log("4x 4y 4z");
                                kl.SetIntVar(kl_Variable4, 4);
                                break;
                        }
                        break;
                }
                break;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        ClearLog();
    }

    void ClearLog() //Clear the console
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
}