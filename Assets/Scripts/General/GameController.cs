using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private GameObject player;
    [SerializeField]
    private Transform playerSpawnPoint;

    private void Awake() {
        Utility.gameController = this;
        player = Utility.playerPrefab;
        SpawnPlayer();
        InstantiateUI();
    }

    public void SpawnPlayer() {
        Instantiate(player, playerSpawnPoint.position, playerSpawnPoint.rotation);
    }

    public void InstantiateUI() {
        Instantiate(Utility.ui, Vector3.zero, new Quaternion(0, 0, 0, 0));
    }
}