using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class RoomButton : MonoBehaviour
{
    public Text nameText;

    public string roomName;

    public void SetRoom()
    {
        nameText.text = roomName;
    }

    public void JoinRoomOnClick()
    {
        PhotonNetwork.JoinRoom(roomName);
    }
}
