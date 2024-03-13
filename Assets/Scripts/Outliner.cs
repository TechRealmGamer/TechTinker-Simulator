using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outliner : MonoBehaviour
{
    [SerializeField] private Material outlineMaterial;
    [SerializeField] private float outlineScaleFactor;
    [SerializeField] private Color outlineColor;

    private Renderer outlineRenderer;

    private void Start()
    {
        outlineRenderer = CreateOutline(outlineMaterial, outlineScaleFactor, outlineColor);
    }

    Renderer CreateOutline(Material outlineMaterial, float scaleFactor, Color color)
    {
        GameObject outlineObject = Instantiate(this.gameObject, transform.position, transform.rotation, transform);
        outlineObject.transform.localScale = Vector3.one;
        Renderer rend = outlineObject.GetComponent<Renderer>();

        rend.material = outlineMaterial;
        rend.material.SetColor("_Color", color);
        rend.material.SetFloat("_Scale", scaleFactor);
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        
        outlineObject.GetComponent<Outliner>().enabled = false;
        outlineObject.GetComponent<Collider>().enabled = false;
        rend.enabled = false;
        return rend;
    }

    public void SetOutline(bool check)
    {
        outlineRenderer.enabled = check;
    }
}
