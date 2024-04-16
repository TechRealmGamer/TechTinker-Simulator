using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectHandling : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float distance;
    [SerializeField] private Transform grabOffset;

    [SerializeField] private Image holdingObjectImage;

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
            selectedObject.GetComponent<Highlight>().SetHighlighter(false);
            selectedObject = null;
        }

        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, layerMask))
        {
            selectedObject = hit.transform;
            selectedObject.GetComponent<Highlight>().SetHighlighter(true);

            if(!Input.GetMouseButtonDown(0))
                return;

            // If the player clicks on the computer, switch to the player computer camera
            if (selectedObject.name == "Player Computer")
            {
                GameManager.INSTANCE.playerComputerCamera.enabled = true;
                mainCamera.enabled = false;
                GameManager.SetCursorVisibility(true);
            }

            // If the player clicks on a computer part, grab it
            else if (grabbedObject == null && selectedObject.CompareTag("Computer Part"))
            {
                if (selectedObject.parent.TryGetComponent<ObjectHolder>(out ObjectHolder holder))
                    holder.ReleaseObject();

                grabbedObject = selectedObject;
                grabbedObject.SetParent(grabOffset.transform);
                grabbedObject.localPosition = Vector3.zero;
                holdingObjectImage.enabled = true;
                holdingObjectImage.sprite = grabbedObject.GetComponent<ComputerPart>().partImage;
            }

            // If the player clicks on a computer part holder, try to place the part
            else if (grabbedObject != null && Input.GetMouseButtonDown(0) && selectedObject.TryGetComponent(out ObjectHolder holder))
            {
                if (holder.HoldObject(grabbedObject))
                {
                    grabbedObject = null;
                    holdingObjectImage.enabled = false;
                }
            }
        }
    }
}
