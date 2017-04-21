using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovinCube : MonoBehaviour {

	//先ほど作成したJoystick
	[SerializeField]
	private MovingJoystick _joystick = null;

	//移動速度
	private const float SPEED = 0.5f;

	private void Update () {
		Vector3 pos = transform.position;

		pos.x += _joystick.Position.x * SPEED;
		pos.z += _joystick.Position.y * SPEED;

		transform.position = pos;
	}
}
