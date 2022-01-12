using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Player _player;

    [SerializeField] private ItemTooltip _itemTooltip;

    public Player Player { get => _player; set => _player = value; }
    public ItemTooltip ItemTooltip { get => _itemTooltip; set => _itemTooltip = value; }
}
