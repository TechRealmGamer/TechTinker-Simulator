using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Computer : MonoBehaviour
{
    [SerializeField] private TMP_Text textMessage;
    public EmailSO order;

    public List<ComputerPart> computerParts;

    private void Update()
    {
        if (textMessage.gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.E))
            TurnOn();
    }

    public void TurnOn()
    {
        order.CheckOrder(computerParts, out string message);
        UIManager.INSTANCE.DisplayErrorMessage(message);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textMessage.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textMessage.gameObject.SetActive(false);
        }
    }
}
