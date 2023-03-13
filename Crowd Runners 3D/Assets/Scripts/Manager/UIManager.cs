using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
public static UIManager instance;

void Awake () {
    if (instance == null)
        instance = this;
}

[SerializeField] private GameObject StartPanel;
[SerializeField] private GameObject WarpEffect;
[SerializeField] private GameObject WinPanel;
[SerializeField] private GameObject LosePanel;

public void StartGame()
{
    StartPanel.SetActive(false);
    WarpEffect.SetActive(true);
    GameState("Game start");
}

public void EndGame(string typeEnd)
{
    if(typeEnd == "Win")
    {
        WinPanel.SetActive(true);
    }
    else
    {
        LosePanel.SetActive(true);
    }
    GameState("Game over");
}

void GameState(string state)
{
    Debug.Log(state);
}
}