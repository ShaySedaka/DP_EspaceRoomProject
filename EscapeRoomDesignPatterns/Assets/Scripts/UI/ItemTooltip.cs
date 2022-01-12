using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private TextMeshProUGUI _itemDescription;

    public void InitializeItemToolTip(ItemSO itemSO)
    {
        _itemImage.sprite = itemSO.ItemSelected;
        _itemDescription.text = itemSO.Description;
    }

    public void ExitItemTooltip()
    {
        gameObject.SetActive(false);
    }

}
