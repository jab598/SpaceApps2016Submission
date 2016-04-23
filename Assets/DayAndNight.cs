using UnityEngine;
using System.Collections;

public class DayAndNight : MonoBehaviour {

	public float dayTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		this.transform.Rotate (new Vector3 (dayTime / 360, 0, 0));
	}
}
