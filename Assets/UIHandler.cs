using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {

	public GameObject researchUIPanel;
	bool isOpen = false;

    public ResourceHolder res;
    public Text daysElapsed;
    public Text money;
    public Text research;
    public Text production;
    public Text power;
    public Text tourists;

    // Use this for initialization
    void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			OpenResearch ();
		}
	}

	void FixedUpdate() {
		daysElapsed.text = System.DateTime.Now.AddDays(Mathf.FloorToInt (Time.timeSinceLevelLoad)).Date.ToString();
        money.text = res.stat_money.ToString();
        research.text = res.stat_research.ToString();
        production.text = res.stat_production.ToString();
        power.text = res.stat_power.ToString();
        tourists.text = "0";
    }

	void OpenResearch() {
		isOpen = !isOpen;
		Time.timeScale = isOpen ? 0.0f : 1.0f;
		researchUIPanel.SetActive (isOpen);
	}
}
