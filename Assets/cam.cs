using UnityEngine;
using System.Collections;

public class cam : MonoBehaviour {

	public float height;
	public float speed = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//40 200
		if (Input.mousePosition.x <= 10) {
			transform.Translate(new Vector3(-1,0,0)*speed*Time.deltaTime);
		} else if (Input.mousePosition.x >= Screen.width-10) {
			transform.Translate(new Vector3(1,0,0)*speed*Time.deltaTime);
		} else if (Input.mousePosition.y <= 10) {
			transform.Translate(new Vector3(0,0,-1)*speed*Time.deltaTime);
		} else if (Input.mousePosition.y >= Screen.height - 10) {
			transform.Translate(new Vector3(0,0,1)*speed*Time.deltaTime);
		}

		if (Input.GetAxis ("Mouse ScrollWheel") != 0) {
			if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
				if (transform.position.y >= 40) {
					transform.Translate (new Vector3 (0, -1, 1) * speed * Time.deltaTime);
				}
			} else {
				if (transform.position.y <= 200) {
					transform.Translate (new Vector3 (0, 1, -1) * speed * Time.deltaTime);
				}
			}
		}

	}
}
