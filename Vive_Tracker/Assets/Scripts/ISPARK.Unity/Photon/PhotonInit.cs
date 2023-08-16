using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using RootMotion.FinalIK;

public class PhotonInit : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        if (PhotonNetwork.IsConnected)
            PhotonNetwork.JoinRandomRoom();
        else
        {
            PhotonNetwork.GameVersion = "5.0";
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected!");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected!");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Falied Join Room!");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 10 });
    }
    
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room!");
        
        GameObject XRRig = PhotonNetwork.Instantiate("XR Rig", new Vector3(-0.27f, -0.719f, 25.71f), Quaternion.Euler(new Vector3(0, 180, 0)), 0);
        XRRig.SetActive(true);
        PhotonNetwork.Instantiate("Player", new Vector3(2, 0, 6), Quaternion.identity, 0);
    }

}