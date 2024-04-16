using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour, Highlight
{
    [SerializeField] private Material normalMaterial;
    [SerializeField] private Material highlightMaterial;

    public ComputerPartType objectType;

    private new Renderer renderer;

    public bool isHoldingObject;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    public void SetHighlighter(bool check)
    {
        renderer.material = check ? highlightMaterial : normalMaterial;
    }

    /// <summary>
    /// Hold the object in the holder
    /// </summary>
    /// <param name="obj">Object that the holder will hold</param>
    /// <returns>true if the holder can successfully hold the object</returns>
    public bool HoldObject(Transform obj)
    {
        // If the holder is already holding an object, give error message
        if (isHoldingObject)
        {
            Debug.Log("This Holder is already holding an object");
            return false;
        }

        // If the computer part is not appropriate for the holder, give error message
        if (objectType != obj.GetComponent<ComputerPart>().partType)
        {
            UIManager.INSTANCE.DisplayErrorMessage("This Part does not fit here");
            return false;
        }

        // If the holder is empty and the part is appropriate, hold the part
        obj.SetParent(transform);
        obj.localPosition = Vector3.zero;
        obj.localRotation = Quaternion.identity;
        obj.localScale = obj.GetComponent<ComputerPart>().originalScale;

        if (GetComponentInParent<Computer>())
        {
            GetComponentInParent<Computer>().computerParts.Add(obj.GetComponent<ComputerPart>());
        }

        GetComponent<Collider>().enabled = false;
        GetComponent<Renderer>().enabled = false;
        return true;
    }

    public void ReleaseObject()
    {
        GetComponent<Collider>().enabled = true;
        GetComponent<Renderer>().enabled = true;
        if (GetComponentInParent<Computer>())
        {
            GetComponentInParent<Computer>().computerParts.Remove(transform.GetChild(0).GetComponent<ComputerPart>());
        }
    }
}
