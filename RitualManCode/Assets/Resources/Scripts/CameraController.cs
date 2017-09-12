using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

	// Camera frame set to follow the player
	void Start () {
	
		offset = transform.position - player.transform.position;
	}
	
	// LateUpdate is called once per frame, after all items processed
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
