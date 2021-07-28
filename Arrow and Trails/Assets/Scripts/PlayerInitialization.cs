using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PlayerInitialization : MonoBehaviourPunCallbacks
{
    [SerializeField] public GameObject PlayerPrefab;
    [SerializeField] public float minX, maxX, minY, maxY, minZ, maxZ;
    [SerializeField] TMP_Text PlayerName;
    Player player;

    private void Start()
    {
        if (SceneManagerHelper.ActiveSceneName == "Game")
        {
            Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
            Debug.Log("Client: Spawning Player at (" + randomPosition.x.ToString() + "," + randomPosition.y.ToString() + "," + randomPosition.z.ToString() + ")");
            PhotonNetwork.Instantiate(PlayerPrefab.name, randomPosition, Quaternion.identity);
        }
    }

    public void SetUp(Player _player)
    {
        player = _player;
        PlayerName.text = player.NickName;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (player == otherPlayer)
            Destroy(gameObject);
    }

    public override void OnLeftRoom()
    {
        Destroy(gameObject);
    }
}
