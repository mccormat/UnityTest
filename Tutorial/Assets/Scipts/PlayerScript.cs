using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public Vector2 speed = new Vector2(25, 25);
	// Update is called once per frame
	void Update () {
		Vector3 dir = Vector3.zero;
		dir.x = Input.acceleration.x * speed.x;
		dir.y = Input.acceleration.y * speed.y;
		Debug.Log (Time.deltaTime);
		Debug.Log (dir.x);

		if (dir.sqrMagnitude > 1) {
			dir.Normalize ();
		}

		dir *= Time.deltaTime*10;

		transform.Translate (dir);
//		float inputX = Input.GetAxis ("Horizontal");
//		float inputY = Input.GetAxis ("Vertical");
//		Vector3 movement = new Vector3 (speed.x * inputX, speed.y * inputY, 0);
//		movement *= Time.deltaTime;
//		transform.Translate (movement);
		bool shoot = Input.GetButtonDown ("Fire1");
		shoot |= Input.GetButtonDown ("Fire2");
		if (shoot) {
			WeaponScript weapon = GetComponent<WeaponScript>();
			if(weapon != null){
				weapon.Attack(false);
				SoundEffectsHelper.Instance.MakePlayerShotSound();
			}
		}
		var dist = (transform.position - Camera.main.transform.position).z;
		
		var leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).x;
		
		var rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, dist)
			).x;
		
		var topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).y;
		
		var bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist)
			).y;
		
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z
			);
	}

	void OnDestroy()
	{
		// Game Over.
		// Add the script to the parent because the current game
		// object is likely going to be destroyed immediately.
		transform.parent.gameObject.AddComponent<GameOverScript>();
	}
}
