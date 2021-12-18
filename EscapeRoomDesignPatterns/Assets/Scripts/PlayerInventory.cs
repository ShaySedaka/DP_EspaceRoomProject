using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Singleton<PlayerInventory>
{
    public HashSet<ItemSO> Inventory = new HashSet<ItemSO>();

    
}
