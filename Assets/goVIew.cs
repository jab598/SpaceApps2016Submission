using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class goVIew : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoSpace() {
		SceneManager.LoadScene ("EarthOrbitThing");
	}
}
