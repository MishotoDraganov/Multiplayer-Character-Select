using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class CharacterSpawner : NetworkBehaviour
{
    [Header("References")]
    [SerializeField] Vector3 spawnPos;

    //  [SerializeField] private CharacterDatabase characterDatabase;
    [SerializeField] GameObject playerPrefab;

    public override void OnNetworkSpawn()
    {
        if (!IsServer) { return; }

        foreach (var client in MatchplayNetworkServer.Instance.ClientData)
        {
            GameObject spawnedPlayer = Instantiate(playerPrefab, spawnPos, Quaternion.identity);
            spawnedPlayer.GetComponent<NetworkObject>().SpawnAsPlayerObject(client.Value.clientId);
        }
    }
}
