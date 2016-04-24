using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class returnB : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoBack() {
		SceneManager.LoadScene ("mainscene");
	}
}
