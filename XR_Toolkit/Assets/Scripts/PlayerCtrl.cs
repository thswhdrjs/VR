using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
using RootMotion.FinalIK;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SpatialTracking;

public class PlayerCtrl : MonoBehaviour
{
    private PhotonView pv;

    //타 플레이어 모음
    private GameObject players;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.Find("Players") ? GameObject.Find("Players") : players = new GameObject("Players");
        pv = GetComponent<PhotonView>();

        if (pv.IsMine)
        {
            GameObject myPlayer = GameObject.Find("XR Rig(Clone)");
            myPlayer.name = "XR Rig";
            gameObject.name = "Player";

            transform.GetChild(9).gameObject.SetActive(false);
            player = myPlayer;
        }
        else
        {
            int num = players.transform.childCount + 1;

            GameObject playerNum = new GameObject("Player" + num);
            playerNum.transform.parent = players.transform;

            GameObject otherPlayer = GameObject.Find("XR Rig(Clone)");
            otherPlayer.name = "XR Rigs" + num;
            otherPlayer.transform.parent = playerNum.transform;

            gameObject.name = "Players" + num;
            transform.parent = playerNum.transform;
            
            Destroy(otherPlayer.transform.GetChild(0).GetChild(0).GetComponent<Camera>());
            Destroy(otherPlayer.transform.GetChild(0).GetChild(0).GetComponent<AudioListener>());
            Destroy(otherPlayer.transform.GetChild(0).GetChild(0).GetComponent<TrackedPoseDriver>());

            Destroy(otherPlayer.transform.GetChild(0).GetChild(1).GetComponent<XRController>());
            Destroy(otherPlayer.transform.GetChild(0).GetChild(2).GetComponent<XRController>());

            player = otherPlayer;
        }

        GetComponent<VRIK>().solver.spine.headTarget = player.transform.GetChild(0).GetChild(0).GetChild(0).transform;
        GetComponent<VRIK>().solver.leftArm.target = player.transform.GetChild(0).GetChild(2).GetChild(0).transform;
        GetComponent<VRIK>().solver.rightArm.target = player.transform.GetChild(0).GetChild(1).GetChild(0).transform;
    }
}