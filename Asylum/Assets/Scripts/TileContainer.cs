using UnityEngine;
using System.Collections;

public class TileContainer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void moveCamera()
	{
		Camera.main.transform.position = new Vector3 (transform.position.x,transform.position.y,Camera.main.transform.position.z);
	}
}
