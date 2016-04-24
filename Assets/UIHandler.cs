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

	float thisTourism;

	public Image spaceBar;

	public Button[] researchButtons;

    // Use this for initialization
    void Start () {
		CancelInvoke ("AlterT");
		InvokeRepeating ("AlterT", 0, 1);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			res.RecalculateGains ();
			OpenResearch ();
		}
	}

	void FixedUpdate() {
		daysElapsed.text = System.DateTime.Now.AddDays(Mathf.FloorToInt (Time.timeSinceLevelLoad)).Date.ToString();
		money.text = "$"+Mathf.FloorToInt(res.stat_money).ToString() + "M";
		research.text = Mathf.FloorToInt(res.stat_research).ToString() + " Discoveries ";
		production.text = Mathf.FloorToInt(res.stat_production).ToString() + " Production Power";
		power.text = Mathf.FloorToInt(res.stat_power).ToString() + "KWh";
		tourists.text = Mathf.FloorToInt (thisTourism).ToString () + "K Daily Visits";
        //tourists.text = "0";
    }

	void OpenResearch() {
		isOpen = !isOpen;
		Time.timeScale = isOpen ? 0.0f : 1.0f;
		researchUIPanel.SetActive (isOpen);
		if (isOpen) {
			UpdateButtons ();
		}
	}

	public void UpdateButtons() {
		foreach (Button b in researchButtons) {
			BuyButton bButton = b.GetComponent<BuyButton> ();
			Color c = Color.grey;
			if (bButton.CanPurchase ()) {
				c = Color.cyan;
			} else if (bButton.IsPurchased ()) {
				c = Color.green;
			} else if (bButton.IsResearched ()) {
				c = Color.white;
				b.GetComponent<BuyButton>().UpdateText ();
			}
			bButton.GetComponent<Image> ().color = c;
		}
	}

	void AlterT() {
		thisTourism = res.stat_tourism * Random.Range (0.95f, 1.05f);
	}
}
