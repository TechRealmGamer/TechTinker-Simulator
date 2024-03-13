using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Part", menuName = "Computer Part")]
public class ComputerPartSO : ScriptableObject
{
    public ComputerPartType type;
    public new string name;
    [TextArea(5,7)]
    public string description;
    public float price;
    public Sprite image;
    public GameObject prefab;
}
