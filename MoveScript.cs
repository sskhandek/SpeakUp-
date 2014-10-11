using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (speed == 0) {
			transform.position = new Vector3(transform.position.x, 0f, transform.position.z);

				}
				else if (transform.position.y < 1)
			transform.position =new Vector3(transform.position.x,  transform.position.y + speed * Time.deltaTime, transform.position.z);
		else
			this.gameObject.SetActive(false);
	}
}
