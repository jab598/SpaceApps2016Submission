using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour {

	public Text myText;
	public Building thisB;
	public ResourceHolder res;
	public BuyButton[] buildingsToUnlock;

	void Awake() {
		res = GameObject.FindObjectOfType <ResourceHolder>();
	}

	// Use this for initialization
	void Start () {
		Text[] txts = this.gameObject.GetComponentsInChildren<Text> ();
		foreach (Text t in txts) {
			if (t.transform.name == "ResearchText") {
				myText = t;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Clicked() {
		if (CanPurchase()) {
			UpdateText ();
			res.stat_money -= thisB.moneyCost;
			res.stat_research -= thisB.researchCost;
			res.stat_production -= thisB.prodCost;
			thisB.gameObject.SetActive (true);
			foreach (BuyButton b in buildingsToUnlock) {
				b.thisB.isResearched = true;
			}
			thisB.isPurchased = true;
			GameObject.FindObjectOfType<UIHandler> ().UpdateButtons ();
			res.RecalculateGains ();
			GameObject.FindObjectOfType<UIHandler> ().spaceBar.rectTransform.sizeDelta = new Vector2 (100, GameObject.FindObjectOfType<UIHandler> ().spaceBar.rectTransform.sizeDelta.y + 50);
		}
	}

	public bool CanAfford() {
		return thisB.prodCost <= res.stat_production
		&& thisB.moneyCost <= res.stat_money
		&& thisB.researchCost <= res.stat_research;
	}

	public bool CanPurchase() {
		if (CanAfford () && IsResearched () && !IsPurchased()) {
			return true;
		} else {
			return false;
		}
	}

	public bool IsResearched() {
		return thisB.isResearched;
	}

	public bool IsPurchased() {
		return thisB.isPurchased;
	}

	public void UpdateText() {
		myText.text = "Money: " + thisB.extraMoney
			+ "\nPower: " + thisB.extraPower
			+ "\nResearch: " + thisB.extraProduction
			+ "\nProduction: " + thisB.extraProduction
			+ "\n\nClick to purchase: $" + thisB.moneyCost
			+ ", " + thisB.prodCost + " Prod, "
			+ thisB.researchCost + " Sci.";
	}

}
