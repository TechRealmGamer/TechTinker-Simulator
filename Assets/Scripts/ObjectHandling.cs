using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectHandling : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float distance;

    private Camera mainCamera;
    private Transform selectedObject;

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
        }
    }
}
