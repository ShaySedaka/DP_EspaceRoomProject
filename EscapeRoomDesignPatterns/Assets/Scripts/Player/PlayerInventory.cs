using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Image _selectedItemCursor;

    public HashSet<ItemSO> Inventory = new HashSet<ItemSO>();

    private ItemSO _selectedItem;

    public Image SelectedItemCursor { get => _selectedItemCursor; set => _selectedItemCursor = value;}
    public ItemSO SelectedItem { get => _selectedItem; set => _selectedItem = value; }

    private void Start()
    {
        _selectedItemCursor.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            if (SelectedItem != null)
            {
                SelectedItem.ItemIcon.UnSelectItem();
            }
        }

        SelectedItemFollowCursor();
    }

    private void SelectedItemFollowCursor()
    {
        _selectedItemCursor.gameObject.transform.position = Input.mousePosition;
    }
}
