using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComputerUI : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameManager.INSTANCE.mainCamera.enabled = true;
            GameManager.INSTANCE.playerComputerCamera.enabled = false;
            GameManager.SetCursorVisibility(false);
        }
    }
}
