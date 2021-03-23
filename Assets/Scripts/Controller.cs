using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KrillAudio.Krilloud;

using System.Reflection;

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

    [KLVariable] public string Columna;
    [KLVariable] public string Instrumento;
    [KLVariable] public string sonido;

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

        if (initialPosition == transform.position)
        {
            GameManager.gM.canBuild = false;
        }
        else
        {
            GameManager.gM.canBuild = true;
        }
    }

    private void Detect() //Detecta si está en un vertice o en una línea para poder moverse.
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

        //DebugRay();
    }

    void DebugRay() //Muestra el raycast por pantalla
    {
        Debug.DrawRay(ray[0].origin, ray[0].direction, Color.red);
        Debug.DrawRay(ray[1].origin, ray[1].direction, Color.red);
        Debug.DrawRay(ray[2].origin, ray[2].direction, Color.red);
        Debug.DrawRay(ray[3].origin, ray[3].direction, Color.red);
        Debug.DrawRay(ray[4].origin, ray[4].direction, Color.red);
        Debug.DrawRay(ray[5].origin, ray[5].direction, Color.red);
    }

    private void Controls() //Define como se va a mover el controlador
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

    public void Click() //Envia si el controlador está seleccionado
    {
        isSelected = true;
        rend.material = selectedMat;
        GameManager.gM.controllerSelected = this.gameObject;
    }

    public void UnClick() //Envia si el controlador NO está seleccionado
    {
        isSelected = false;
        rend.material = unSelectedMat;
        GameManager.gM.controllerSelected = null;
    }

    public void OnCollisionEnter(Collision collision) 
    {
        switch (collision.gameObject.tag) //Identifica qué vertice está tocando
        {
            case "Vertex1":
                switch (collision.transform.parent.tag) //Identifica en qué columna está dicho vertice
                {
                    case "C1":
                        GameObject parent1 = collision.transform.parent.gameObject;
                        switch (parent1.transform.parent.tag) //Idenfitica en qué fila está dicho vertice
                        {
                            case "F1":
                                Debug.Log("Vertex1 C1 F1");
                                kl.SetIntVar(sonido, 0);
                                break;        
                            case "F2":
                                Debug.Log("Vertex1 C1 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex1 C1 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex1 C1 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex1 C1 F5");
                                kl.SetIntVar(sonido, 1);
                                break;
                        }
                        break;
                    case "C2":
                        GameObject parent2 = collision.transform.parent.gameObject;
                        switch (parent2.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("Vertex1 C2 F1");
                                kl.SetIntVar(sonido, 0);
                                break;
                            case "F2":
                                Debug.Log("Vertex1 C2 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex1 C2 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex1 C2 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex1 C2 F5");
                                kl.SetIntVar(sonido, 1);
                                break;
                        }
                        break;
                    case "C3":
                        GameObject parent3 = collision.transform.parent.gameObject;
                        switch (parent3.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("Vertex1 C3 F1");
                                kl.SetIntVar(sonido, 0);
                                break;
                            case "F2":
                                Debug.Log("Vertex1 C3 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex1 C3 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex1 C3 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex1 C3 F5");
                                kl.SetIntVar(sonido, 1);
                                break;
                        }
                        break;
                    case "C4":
                        GameObject parent4 = collision.transform.parent.gameObject;
                        switch (parent4.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("Vertex1 C4 F1");
                                kl.SetIntVar(sonido, 0);
                                break;
                            case "F2":
                                Debug.Log("Vertex1 C4 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex1 C4 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex1 C4 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex1 C4 F5");
                                kl.SetIntVar(sonido, 1);
                                break;
                        }
                        break;
                    case "C5":
                        GameObject parent5 = collision.transform.parent.gameObject;
                        switch (parent5.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("Vertex1 C5 F1");
                                kl.SetIntVar(sonido, 0);
                                break;
                            case "F2":
                                Debug.Log("Vertex1 C5 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex1 C5 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex1 C5 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex1 C5 F5");
                                kl.SetIntVar(sonido, 1);
                                break;
                        }
                        break;
                }
                break;

            case "Vertex2":
                switch (collision.transform.parent.tag)
                {
                    case "C1":
                        GameObject parent1 = collision.transform.parent.gameObject;
                        switch (parent1.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("Vertex2 C1 F1");
                                kl.SetIntVar(sonido, 0);
                                break;
                            case "F2":
                                Debug.Log("Vertex2 C1 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex2 C1 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex2 C1 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex2 C1 F5");
                                kl.SetIntVar(sonido, 1);
                                break;
                        }
                        break;
                    case "C2":
                        GameObject parent2 = collision.transform.parent.gameObject;
                        switch (parent2.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("Vertex2 C2 F1");
                                kl.SetIntVar(sonido, 0);
                                break;
                            case "F2":
                                Debug.Log("Vertex2 C2 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex2 C2 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex2 C2 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex2 C2 F5");
                                kl.SetIntVar(sonido, 1);
                                break;
                        }
                        break;
                    case "C3":
                        GameObject parent3 = collision.transform.parent.gameObject;
                        switch (parent3.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("Vertex2 C3 F1");
                                kl.SetIntVar(sonido, 0);
                                break;
                            case "F2":
                                Debug.Log("Vertex2 C3 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex2 C3 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex2 C3 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex2 C3 F5");
                                kl.SetIntVar(sonido, 1);
                                break;
                        }
                        break;
                    case "C4":
                        GameObject parent4 = collision.transform.parent.gameObject;
                        switch (parent4.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("Vertex2 C4 F1");
                                kl.SetIntVar(sonido, 0);
                                break;
                            case "F2":
                                Debug.Log("Vertex2 C4 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex2 C4 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex2 C4 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex2 C4 F5");
                                kl.SetIntVar(sonido, 1);
                                break;
                        }
                        break;
                    case "C5":
                        GameObject parent5 = collision.transform.parent.gameObject;
                        switch (parent5.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("Vertex2 C5 F1");
                                kl.SetIntVar(sonido, 0);
                                break;
                            case "F2":
                                Debug.Log("Vertex2 C5 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex2 C5 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex2 C5 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex2 C5 F5");
                                kl.SetIntVar(sonido, 1);
                                break;
                        }
                        break;
                }
                break;

            case "Vertex3":
                switch (collision.transform.parent.tag)
                {
                    case "C1":
                        GameObject parent1 = collision.transform.parent.gameObject;
                        switch (parent1.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("Vertex3 C1 F1");
                                kl.SetIntVar(sonido, 0);
                                break;
                            case "F2":
                                Debug.Log("Vertex3 C1 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex3 C1 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex3 C1 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex3 C1 F5");
                                kl.SetIntVar(sonido, 1);
                                break;
                        }
                        break;
                    case "C2":
                        GameObject parent2 = collision.transform.parent.gameObject;
                        switch (parent2.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("Vertex3 C2 F1");
                                kl.SetIntVar(sonido, 0);
                                break;
                            case "F2":
                                Debug.Log("Vertex3 C2 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex3 C2 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex3 C2 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex3 C2 F5");
                                kl.SetIntVar(sonido, 1);
                                break;
                        }
                        break;
                    case "C3":
                        GameObject parent3 = collision.transform.parent.gameObject;
                        switch (parent3.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("Vertex3 C3 F1");
                                kl.SetIntVar(sonido, 0);
                                break;
                            case "F2":
                                Debug.Log("Vertex3 C3 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex3 C3 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex3 C3 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex3 C3 F5");
                                kl.SetIntVar(sonido, 1);
                                break;
                        }
                        break;
                    case "C4":
                        GameObject parent4 = collision.transform.parent.gameObject;
                        switch (parent4.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("Vertex3 C4 F1");
                                kl.SetIntVar(sonido, 0);
                                break;
                            case "F2":
                                Debug.Log("Vertex3 C4 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex3 C4 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex3 C4 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex3 C4 F5");
                                kl.SetIntVar(sonido, 1);
                                break;
                        }
                        break;
                    case "C5":
                        GameObject parent5 = collision.transform.parent.gameObject;
                        switch (parent5.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("Vertex3 C5 F1");
                                kl.SetIntVar(sonido, 0);
                                break;
                            case "F2":
                                Debug.Log("Vertex3 C5 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex3 C5 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex3 C5 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex3 C5 F5");
                                kl.SetIntVar(sonido, 1);
                                break;
                        }
                        break;
                }
                break;

            case "Vertex4":
                switch (collision.transform.parent.tag)
                {
                    case "C1":
                        GameObject parent1 = collision.transform.parent.gameObject;
                        switch (parent1.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("Vertex4 C1 F1");
                                kl.SetIntVar(sonido, 0);
                                break;
                            case "F2":
                                Debug.Log("Vertex4 C1 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex4 C1 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex4 C1 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex4 C1 F5");
                                kl.SetIntVar(sonido, 1);
                                break;
                        }
                        break;
                    case "C2":
                        GameObject parent2 = collision.transform.parent.gameObject;
                        switch (parent2.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("Vertex4 C2 F1");
                                kl.SetIntVar(sonido, 0);
                                break;
                            case "F2":
                                Debug.Log("Vertex4 C2 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex4 C2 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex4 C2 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex4 C2 F5");
                                kl.SetIntVar(sonido, 1);
                                break;
                        }
                        break;
                    case "C3":
                        GameObject parent3 = collision.transform.parent.gameObject;
                        switch (parent3.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("Vertex4 C3 F1");
                                kl.SetIntVar(sonido, 0);
                                break;
                            case "F2":
                                Debug.Log("Vertex4 C3 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex4 C3 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex4 C3 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex4 C3 F5");
                                kl.SetIntVar(sonido, 1);
                                break;
                        }
                        break;
                    case "C4":
                        GameObject parent4 = collision.transform.parent.gameObject;
                        switch (parent4.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("Vertex4 C4 F1");
                                kl.SetIntVar(sonido, 0);
                                break;
                            case "F2":
                                Debug.Log("Vertex4 C4 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex4 C4 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex4 C4 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex4 C4 F5");
                                kl.SetIntVar(sonido, 1);
                                break;
                        }
                        break;
                    case "C5":
                        GameObject parent5 = collision.transform.parent.gameObject;
                        switch (parent5.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("Vertex4 C5 F1");
                                kl.SetIntVar(sonido, 0);
                                break;
                            case "F2":
                                Debug.Log("Vertex4 C5 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex4 C5 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex4 C5 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex4 C5 F5");
                                kl.SetIntVar(sonido, 1);
                                break;
                        }
                        break;
                }
                break;

            case "Vertex5":
                switch (collision.transform.parent.tag)
                {
                    case "C1":
                        GameObject parent1 = collision.transform.parent.gameObject;
                        switch (parent1.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("Vertex5 C1 F1");
                                kl.SetIntVar(sonido, 0);
                                break;
                            case "F2":
                                Debug.Log("Vertex5 C1 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex5 C1 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex5 C1 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex5 C1 F5");
                                kl.SetIntVar(sonido, 1);
                                break;
                        }
                        break;
                    case "C2":
                        GameObject parent2 = collision.transform.parent.gameObject;
                        switch (parent2.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("Vertex5 C2 F1");
                                kl.SetIntVar(sonido, 0);
                                break;
                            case "F2":
                                Debug.Log("Vertex5 C2 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex5 C2 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex5 C2 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex5 C2 F5");
                                kl.SetIntVar(sonido, 1);
                                break;
                        }
                        break;
                    case "C3":
                        GameObject parent3 = collision.transform.parent.gameObject;
                        switch (parent3.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("Vertex5 C3 F1");
                                kl.SetIntVar(sonido, 0);
                                break;
                            case "F2":
                                Debug.Log("Vertex5 C3 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex5 C3 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex5 C3 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex5 C3 F5");
                                kl.SetIntVar(sonido, 1);
                                break;
                        }
                        break;
                    case "C4":
                        GameObject parent4 = collision.transform.parent.gameObject;
                        switch (parent4.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("Vertex5 C4 F1");
                                kl.SetIntVar(sonido, 0);
                                break;
                            case "F2":
                                Debug.Log("Vertex5 C4 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex5 C4 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex5 C4 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex5 C4 F5");
                                kl.SetIntVar(sonido, 1);
                                break;
                        }
                        break;
                    case "C5":
                        GameObject parent5 = collision.transform.parent.gameObject;
                        switch (parent5.transform.parent.tag)
                        {
                            case "F1":
                                Debug.Log("Vertex5 C5 F1");
                                kl.SetIntVar(sonido, 0);
                                break;
                            case "F2":
                                Debug.Log("Vertex5 C5 F2");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F3":
                                Debug.Log("Vertex5 C5 F3");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F4":
                                Debug.Log("Vertex5 C5 F4");
                                kl.SetIntVar(sonido, 1);
                                break;
                            case "F5":
                                Debug.Log("Vertex5 C5 F5");
                                kl.SetIntVar(sonido, 1);
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

    void ClearLog() //Limpia la consola de Debugs
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }

}


