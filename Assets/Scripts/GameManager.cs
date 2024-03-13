using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    public Camera mainCamera;
    public Camera playerComputerCamera;

    private void Awake()
    {
        if(INSTANCE != null && INSTANCE != this)
            Destroy(gameObject);
        INSTANCE = this;            
    }

    public static void SetCursorVisibility(bool check)
    {
        Cursor.lockState = check ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = check;
    }
}
