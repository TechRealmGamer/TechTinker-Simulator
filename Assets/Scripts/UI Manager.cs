using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager INSTANCE;
    public TMP_Text errorMessageText;

    private void Awake()
    {
        INSTANCE = this;
    }

    public void DisplayErrorMessage(string message)
    {
        errorMessageText.text = message;
        errorMessageText.GetComponent<Animator>().Play("Display");
    }
}
