using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public EmailSO order;

    public List<ComputerPart> computerParts;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TurnOn();
        }
    }

    public void TurnOn()
    {
        order.CheckOrder(computerParts, out string message);
        UIManager.INSTANCE.DisplayErrorMessage(message);
    }
}
