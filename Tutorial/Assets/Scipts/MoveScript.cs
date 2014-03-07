using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	public Vector2 speed = new Vector2(10, 10);

	public Vector2 direction = new Vector2(-1, 0);
	private int count = 0;
	public int moveType = 1;
	
	// Update is called once per frame
	void Update () {
		Vector3 movement = new Vector3(0,0,0);
		float moveUp = 0.5f;
		float moveDown = -0.5f;
		if(moveType == 1)
		{
			movement = new Vector3 (speed.x * direction.x, speed.y * direction.y, 0);
		}
		else if(moveType == 2)
		{
			count++;			
			if(count%90 <= 45)
			{
				direction = new Vector2(direction.x, 0.5f);
				movement = new Vector3 (speed.x * direction.x, speed.y * moveUp, 0);
			}
			else if(count%90 > 45)
			{
				direction = new Vector2(direction.x, -0.5f);
				movement = new Vector3 (speed.x * direction.x, speed.y * moveDown, 0);
			}
		}
		//Vector3 movement = new Vector3 (speed.x * direction.x, speed.y * direction.y, 0);
		movement *= Time.deltaTime;
		transform.Translate (movement);
	}
}