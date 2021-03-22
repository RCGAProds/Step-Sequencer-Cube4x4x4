using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectController : MonoBehaviour
{
    [SerializeField]
    private LayerMask controllersClickable;
    private LayerMask buttonsClickable;

    private List<GameObject> selectedObjects;

    private void Start()
    {
        selectedObjects = new List<GameObject>();
    }

    void Update()
    {
        Select();
    }

    public void Select()
    {
        if (Input.GetMouseButtonDown(0)) //Si se hace CLICK
        {
            RaycastHit rayHit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
                out rayHit, Mathf.Infinity, controllersClickable)) //Si se clickea un controlador clickeable
            {
                Controller controllerScript = rayHit.collider.GetComponent<Controller>();

                if (controllerScript != null) //Si tiene el script Controller
                {
                    if (controllerScript.isSelected == false) //Si no está seleccionado
                    {
                        foreach (GameObject obj in selectedObjects)
                        {
                            if (obj != null)
                            {
                                obj.GetComponent<Controller>().isSelected = false;
                                obj.GetComponent<Controller>().UnClick();
                            }
                        }
                        selectedObjects.Clear();
                        selectedObjects.Add(rayHit.collider.gameObject);
                        rayHit.collider.GetComponent<Controller>().Click();
                        controllerScript.isSelected = true;
                    }
                    else //Si está seleccionado
                    {
                        if (selectedObjects.Count > 0) //Si hay algo más seleccionado
                        {
                            foreach (GameObject obj in selectedObjects)
                            {
                                if(obj != null)
                                {
                                    obj.GetComponent<Controller>().isSelected = false;
                                    obj.GetComponent<Controller>().UnClick();
                                }
                            }
                            selectedObjects.Clear();
                        }
                        selectedObjects.Add(rayHit.collider.gameObject);
                        controllerScript.isSelected = true;
                        controllerScript.Click();
                    }
                }
            }
            else if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
                out rayHit, Mathf.Infinity, buttonsClickable)) //Si se clickea un botón clickeable
            {
                return;
            }
            else //Si no se clickea nada
            {
                if (selectedObjects.Count > 0) //Si hay algo seleccionado
                {
                    foreach (GameObject obj in selectedObjects)
                    {
                        if (obj != null)
                        {
                            obj.GetComponent<Controller>().isSelected = false;
                            obj.GetComponent<Controller>().UnClick();
                        }
                    }
                    selectedObjects.Clear();
                }
            }
        }
    }
}
