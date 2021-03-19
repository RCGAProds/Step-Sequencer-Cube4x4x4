using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KrillAudio.Krilloud;

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

    private KLAudioSource kl;

    [KLVariable] public string kl_Variable;
    [KLVariable] public string kl_Variable2;
    [KLVariable] public string kl_Variable3;

    void Start()
    {
        kl = GetComponent<KLAudioSource>();

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

    public void OnCollisionEnter(Collision collision)
    {


        switch (collision.gameObject.tag)
        {
            case "Vertex1":
                kl.SetIntVar(kl_Variable, 0); // seleciona la variable de los vertices en krilloud
                Debug.Log("Vertex1");
                switch (collision.transform.parent.tag)
                {

                    case "C1":
                        Debug.Log("C1");
                        kl.SetIntVar(kl_Variable, 0);// seleciona la variable de la columna en krilloud
                        GameObject parent1 = collision.transform.parent.gameObject;
                        switch (parent1.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);// seleciona la variable de la fila en krilloud
                                break;        
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                    case "C2":
                        Debug.Log("C2");
                        GameObject parent2 = collision.transform.parent.gameObject;
                        switch (parent2.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);
                                break;
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                    case "C3":
                        Debug.Log("C3");
                        GameObject parent3 = collision.transform.parent.gameObject;
                        switch (parent3.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);
                                break;
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                    case "C4":
                        Debug.Log("C4");
                        GameObject parent4 = collision.transform.parent.gameObject;
                        switch (parent4.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);
                                break;
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                    case "C5":
                        Debug.Log("C5");
                        GameObject parent5 = collision.transform.parent.gameObject;
                        switch (parent5.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);
                                break;
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                }
                break;
            case "Vertex2":

                Debug.Log("Vertex2");
                switch (collision.transform.parent.tag)
                {

                    case "C1":
                        Debug.Log("C1");
                        GameObject parent1 = collision.transform.parent.gameObject;
                        switch (parent1.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);
                                break;
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                    case "C2":
                        Debug.Log("C2");
                        GameObject parent2 = collision.transform.parent.gameObject;
                        switch (parent2.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);
                                break;
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                    case "C3":
                        Debug.Log("C3");
                        GameObject parent3 = collision.transform.parent.gameObject;
                        switch (parent3.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);
                                break;
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                    case "C4":
                        Debug.Log("C4");
                        GameObject parent4 = collision.transform.parent.gameObject;
                        switch (parent4.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);
                                break;
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                    case "C5":
                        Debug.Log("C5");
                        GameObject parent5 = collision.transform.parent.gameObject;
                        switch (parent5.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);
                                break;
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                }
                break;
            case "Vertex3":

                Debug.Log("Vertex3");
                switch (collision.transform.parent.tag)
                {

                    case "C1":
                        Debug.Log("C1");
                        GameObject parent1 = collision.transform.parent.gameObject;
                        switch (parent1.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);
                                break;
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                    case "C2":
                        Debug.Log("C2");
                        GameObject parent2 = collision.transform.parent.gameObject;
                        switch (parent2.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);
                                break;
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                    case "C3":
                        Debug.Log("C3");
                        GameObject parent3 = collision.transform.parent.gameObject;
                        switch (parent3.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);
                                break;
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                    case "C4":
                        Debug.Log("C4");
                        GameObject parent4 = collision.transform.parent.gameObject;
                        switch (parent4.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);
                                break;
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                    case "C5":
                        Debug.Log("C5");
                        GameObject parent5 = collision.transform.parent.gameObject;
                        switch (parent5.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);
                                break;
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                }
                break;
            case "Vertex4":

                Debug.Log("Vertex4");
                switch (collision.transform.parent.tag)
                {

                    case "C1":
                        Debug.Log("C1");
                        GameObject parent1 = collision.transform.parent.gameObject;
                        switch (parent1.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);
                                break;
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                    case "C2":
                        Debug.Log("C2");
                        GameObject parent2 = collision.transform.parent.gameObject;
                        switch (parent2.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);
                                break;
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                    case "C3":
                        Debug.Log("C3");
                        GameObject parent3 = collision.transform.parent.gameObject;
                        switch (parent3.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);
                                break;
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                    case "C4":
                        Debug.Log("C4");
                        GameObject parent4 = collision.transform.parent.gameObject;
                        switch (parent4.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);
                                break;
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                    case "C5":
                        Debug.Log("C5");
                        GameObject parent5 = collision.transform.parent.gameObject;
                        switch (parent5.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);
                                break;
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                }
                break;
            case "Vertex5":

                Debug.Log("Vertex5");
                switch (collision.transform.parent.tag)
                {

                    case "C1":
                        Debug.Log("C1");
                        GameObject parent1 = collision.transform.parent.gameObject;
                        switch (parent1.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);
                                break;
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                    case "C2":
                        Debug.Log("C2");
                        GameObject parent2 = collision.transform.parent.gameObject;
                        switch (parent2.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);
                                break;
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                    case "C3":
                        Debug.Log("C3");
                        GameObject parent3 = collision.transform.parent.gameObject;
                        switch (parent3.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);
                                break;
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                    case "C4":
                        Debug.Log("C4");
                        GameObject parent4 = collision.transform.parent.gameObject;
                        switch (parent4.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);
                                break;
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                    case "C5":
                        Debug.Log("C5");
                        GameObject parent5 = collision.transform.parent.gameObject;
                        switch (parent5.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("F1");
                                kl.SetIntVar(kl_Variable, 0);
                                break;
                            case "F2":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F2");
                                break;
                            case "F3":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F3");
                                break;
                            case "F4":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F4");
                                break;
                            case "F5":
                                kl.SetIntVar(kl_Variable, 1);
                                Debug.Log("F5");
                                break;
                        }
                        break;
                }
                break;
        }

    }



}


