using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ServerManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        Debug.Log("Started");
        ConnectToMaster();
    }

    public void ConnectToMaster()
    {
        Debug.Log("Connecting to Master Server");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Server: Connected to Master Server");
        Debug.Log("Joining Lobby");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Server: Joined Lobby");
        MenuManager.Instance.OpenMenu(MenuManager.Instance.previousMenuName());
        PhotonNetwork.NickName = "Player " + Random.Range(0, 9999).ToString("0000");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Server: Disconnected from server");
        ConnectToMaster();
    }
}
