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

    public bool CheckOrder(List<ComputerPart> attachedParts, out string message)
    {
        List<int> requiredComponentIDs = new List<int>();
        List<int> attachedComponentIDs = new List<int>();

        foreach(ComputerPartSO part in partsRequired)
            requiredComponentIDs.Add(part.prefab.GetComponent<ComputerPart>().componentID);
        foreach (ComputerPart part in attachedParts)
            attachedComponentIDs.Add(part.componentID);

        for(int i=0; i < requiredComponentIDs.Count; i++)
        {
            if (!attachedComponentIDs.Contains(requiredComponentIDs[i]))
            {
                message = "You are missing a component: " + partsRequired[i].name;
                return false;
            }
        }

        message = "Congratulations! You completed the order.";
        return true;
    }
}
