using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text errorMessageText;

    public void DisplayErrorMessage(string message)
    {
        errorMessageText.text = message;
        errorMessageText.GetComponent<Animator>().SetTrigger("Display");
    }
}
