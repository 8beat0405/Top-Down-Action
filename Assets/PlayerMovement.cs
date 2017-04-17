using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private float m_speedScale = 7.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float vertical      = CrossPlatformInputManager.GetAxis( "Vertical" );
		float horizontal    = CrossPlatformInputManager.GetAxis( "Horizontal" );
		Vector3 addPos      = new Vector3( horizontal, vertical, 0.0f ) * m_speedScale;
		transform.position += addPos * Time.deltaTime;
	}
}
