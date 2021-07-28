using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public string GameState = "Menu";
    public string PreviousGameState = "Menu";

    public static GameManager Instance;
    public void Awake()
    {
        /*if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);*/
        Instance = this;
    }

    public void LoadGame()
    {
        Debug.Log("Client: Loading Game");
        PhotonNetwork.LoadLevel("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
