using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : Singleton<PlayerInventory>
{
    [SerializeField] Image _selectedItemCursor;

    public HashSet<ItemSO> Inventory = new HashSet<ItemSO>();

    private ItemSO _selectedItem;

    public ItemSO SelectedItem { get => _selectedItem; set => _selectedItem = value; }
    public Image SelectedItemCursor { get => _selectedItemCursor; set => _selectedItemCursor = value;}

    private void Start()
    {
        _selectedItemCursor.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    private void Update()
    {
        if(Input.GetMouseButton(1) && SelectedItem != null)
        {
            SelectedItem.ItemIcon.UnSelectItem();
        }

        SelectedItemFollowCursor();
    }

    private void SelectedItemFollowCursor()
    {
        _selectedItemCursor.gameObject.transform.position = Input.mousePosition 
            /*- new Vector3(_selectedItemCursor.rectTransform.rect.width, _selectedItemCursor.rectTransform.rect.height, 0)*/
            ;
    }
}
