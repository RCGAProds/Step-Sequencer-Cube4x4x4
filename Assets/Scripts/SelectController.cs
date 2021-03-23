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
        if (Input.GetMouseButtonDown(0)) //If there's a click
        {
            RaycastHit rayHit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
                out rayHit, Mathf.Infinity, controllersClickable)) //If there's a collision of the raycast on the layer "controllersClickable"
            {
                Controller controllerScript = rayHit.collider.GetComponent<Controller>();

                if (controllerScript != null) //If there's a Script called "Controller"
                {
                    if (controllerScript.isSelected == false) //If it is not selected
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
                    else //If it's selected
                    {
                        if (selectedObjects.Count > 0) //If there're something selected.
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
            else //If there's no collision of the raycast
            {
                if (selectedObjects.Count > 0) //If there're something selected.
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
