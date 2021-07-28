using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Photon.Pun;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public GameObject PlayerPrefab;
    [SerializeField] PhotonView PV;
    [SerializeField] public float minX, maxX, minY, maxY, minZ, maxZ;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    void Start()
    {
        if (PV.IsMine)
        {
            CreateController();
        }
    }

    void CreateController()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        Debug.Log("Client: Spawning Player at (" + randomPosition.x.ToString() + "," + randomPosition.y.ToString() + "," + randomPosition.z.ToString() + ")");
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", PlayerPrefab.name), randomPosition, Quaternion.identity);
    }
}
