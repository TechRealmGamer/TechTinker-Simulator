using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPart : MonoBehaviour, Highlight
{
    public int componentID;
    public ComputerPartType partType;
    public Sprite partImage;

    private Renderer outlineRenderer;
    [SerializeField] private Material outlineMaterial;

    [HideInInspector] public Vector3 originalScale;

    private void Start()
    {
        //outlineRenderer = CreateOutline();
        originalScale = transform.localScale;
    }

    Renderer CreateOutline()
    {
        GameObject outlineObject = Instantiate(new GameObject(), transform);
        outlineObject.name = "Outline";
        /*outlineObject.transform.localPosition = Vector3.zero;
        outlineObject.transform.localRotation = Quaternion.identity;
        outlineObject.transform.localScale = Vector3.one;*/

        outlineObject.AddComponent<MeshFilter>().sharedMesh = GetComponent<MeshFilter>().sharedMesh;
        outlineObject.AddComponent<MeshRenderer>();
        Renderer rend = outlineObject.GetComponent<MeshRenderer>();
        rend.material = outlineMaterial;
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        rend.enabled = false;
        return rend;
    }

    public void SetHighlighter(bool check)
    {
        //outlineRenderer.enabled = check;
    }
}
