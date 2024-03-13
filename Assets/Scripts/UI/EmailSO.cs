using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Order", menuName = "Order")]
public class EmailSO : ScriptableObject
{
    public int orderID;

    public string emailSender;
    public string emailSubject;
    public string emailMessage;

    public float budget;

    public List<ComputerPartSO> partsRequired;
}
