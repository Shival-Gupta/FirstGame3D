using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class RoomInitializer : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField RoomCode;
    [SerializeField] TMP_Text ErrorMessage;
    [SerializeField] TMP_Text RoomName;
    [SerializeField] Transform PlayerList;
    [SerializeField] GameObject PlayerListItem;
    [SerializeField] GameObject StartButton;

    string roomCode="";

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(RoomCode.text))
            return;
        Debug.Log("Client: Creating Room");
        roomCode = RoomCode.text;
        MenuManager.Instance.OpenMenu("Loading");
        PhotonNetwork.CreateRoom(roomCode);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {

        MenuManager.Instance.OpenMenu("PlayMenu");
        ErrorMessage.text = "Room Creation failed\n" + message;
        Debug.Log("Server: " + ErrorMessage.text);
    }

    public void JoinRoom()
    {
        Debug.Log("Client: Joining Room");
        roomCode = RoomCode.text;
        MenuManager.Instance.OpenMenu("Loading");
        PhotonNetwork.JoinRoom(roomCode);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Server: Joined Room");
        MenuManager.Instance.OpenMenu("Room");
        RoomName.text = "" + roomCode;

        Player[] players = PhotonNetwork.PlayerList;

        for (int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i++)
            Instantiate(PlayerListItem, PlayerList).GetComponent<PlayerInitialization>().SetUp(players[i]);
        StartButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        ErrorMessage.text = "Failed joining room\n" + message;
        MenuManager.Instance.OpenMenu("PlayMenu");

        Debug.Log("Server: " + ErrorMessage.text);
    }

    public void LeaveRoom()
    {
        Debug.Log("Client: Leaving Room");
        PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("Loading");

        foreach(Transform child in PlayerList)
        {
            Destroy(child.gameObject);
        }
    }

    public override void OnLeftRoom()
    {
        Debug.Log("Server: Left Room");
        MenuManager.Instance.PreviousMenuName = "PlayMenu";
    }
}
