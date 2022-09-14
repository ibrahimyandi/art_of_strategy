using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class RoomController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    public static List<Units> units;

    [SerializeField]
    private int multiplayerSceneIndex;

    public static List<Units> redPLayer;
    public static List<Units> bluePLayer;

    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            redPLayer = units;
        }
        else if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            bluePLayer = units;
        }
        Debug.Log(PhotonNetwork.PlayerList.Length + " / " + PhotonNetwork.CurrentRoom.MaxPlayers);
        
        if (PhotonNetwork.PlayerList.Length == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            Debug.Log("Oda doldu.");
            StartGame();
        }
    }

    public void StartGame()
    {
        Debug.Log("Starting Game");
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.LoadLevel(multiplayerSceneIndex);
    }
}
