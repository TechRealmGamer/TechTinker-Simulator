using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;

    private void Awake()
    {
        if(INSTANCE == null)
            INSTANCE = this;
        else
            Destroy(gameObject);
    }

    public static void SetCursorVisibility(bool check)
    {
        Cursor.lockState = check ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = check;
    }
}
