using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectController : MonoBehaviour
{
    [SerializeField]
    private LayerMask clickable;

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
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit rayHit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
                out rayHit, Mathf.Infinity, clickable))
            {
                Controller controllerScript = rayHit.collider.GetComponent<Controller>();

                if (controllerScript != null)
                {
                    if (controllerScript.isSelected == false)
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
                    else
                    {
                        if (selectedObjects.Count > 0)
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
            else
            {
                if (selectedObjects.Count > 0)
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
