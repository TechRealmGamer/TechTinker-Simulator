using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GraphicsSetting : MonoBehaviour
{
    [SerializeField] private TMP_Text uiText;
    [SerializeField] private string[] settings;

    private int index = 0;

    private void Start()
    {
        uiText.text = settings[index];
    }

    public void LeftButton()
    {
        if (index == 0)
            return;
        index--;
        uiText.text = settings[index];
    }

    public void RightButton()
    {
        if(index == settings.Length - 1)
            return;
        index++;
        uiText.text = settings[index];
    }

    public string GetSetting()
    {
        return settings[index];
    }
}
