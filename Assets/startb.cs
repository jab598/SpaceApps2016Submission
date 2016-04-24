using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class startb : MonoBehaviour {

	public GameObject[] thingsToHide;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Go() {
		Time.timeScale = 1;
		foreach (GameObject g in thingsToHide) {
			g.SetActive (false);
		}
	}
}
