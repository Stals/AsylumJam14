﻿using UnityEngine;
using System.Collections;

public enum LevelState{
	Running,
	Ended
}

public class GameManager : MonoBehaviour {

    [SerializeField]
    GameObject player;
	[SerializeField]
    GameObject brother;

    [SerializeField]
    public GameObject activatableImagePrefab;

	//[SerializeField]
	//GameOverController gameOverController;
    
	//CameraShake cameraShake;
   

	// Use this for initialization
	void Start () {
		Game.Instance.init (this);
		//cameraShake = Camera.main.gameObject.AddComponent("CameraShake") as CameraShake;
		//currentLevelLabel.text = "Level: " + (Game.Instance.getCurrentLevelID () + 1).ToString();
		//currentLevelState = LevelState.Running;
	}
	
	// Update is called once per frame
	void Update () {
        // TODO if button pressed -change world

        //if (Input.GetMouseButtonDown(1))
        //{
        //    CreateDeletingLine();
        //}
	}
}
