using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectHandling : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float distance;

    [SerializeField] private Transform grabOffset;

    private Camera mainCamera;
    private Transform selectedObject;
    private Transform grabbedObject;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        if(selectedObject != null)
        {
            selectedObject.GetComponent<Outliner>().SetOutline(false);
            selectedObject = null;
        }

        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, layerMask))
        {
            selectedObject = hit.transform;
            selectedObject.GetComponent<Outliner>().SetOutline(true);

            // If the player clicks on the computer, switch to the player computer camera
            if (selectedObject.name == "Player Computer" && Input.GetMouseButtonDown(0))
            {
                GameManager.INSTANCE.playerComputerCamera.enabled = true;
                mainCamera.enabled = false;
                GameManager.SetCursorVisibility(true);
            }

            // If the player clicks on a computer part, grab it
            if (grabbedObject == null && selectedObject.CompareTag("Computer Part") && Input.GetMouseButtonDown(0))
            {
                grabbedObject = selectedObject;
                grabbedObject.SetParent(grabOffset.transform);
                grabbedObject.localPosition = Vector3.zero;
                grabbedObject.localRotation = Quaternion.identity;
            }
            if (grabbedObject != null && Input.GetMouseButtonDown(0) && selectedObject.CompareTag("Computer Part Holder"))
            {
                grabbedObject.SetParent(selectedObject);
                grabbedObject.localPosition = Vector3.zero;
                grabbedObject.localRotation = Quaternion.identity;
                grabbedObject = null;
            }
        }
    }
}
