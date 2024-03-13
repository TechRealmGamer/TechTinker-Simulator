using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerPartCardView : MonoBehaviour
{
    public ComputerPartSO part;

    public TMPro.TMP_Text nameLabel;
    public TMPro.TMP_Text descriptionLabel;
    public TMPro.TMP_Text priceLabel;
    public Image image;

    private void Start()
    {
        nameLabel.text = part.name;
        descriptionLabel.text = part.description;
        priceLabel.text = part.price.ToString("C");
        image.sprite = part.image;
    }

    public void OnClickBuy()
    {
        Debug.Log("Buying " + part.name);
    }
}
