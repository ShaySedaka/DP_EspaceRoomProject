using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Player _player;

    public Player Player { get => _player; set => _player = value; }

    public void QuitGame()
    {
        Application.Quit();
    }
}
