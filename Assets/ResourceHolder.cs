using UnityEngine;
using System.Collections;
public class ResourceHolder : MonoBehaviour {
	
	public float stat_money = 10;
    public float stat_power = 0;
    public float stat_research = 0;
    public float stat_production = 0;

	float stat_money_gain;
	float stat_power_gain;
	float stat_research_gain;
	float stat_production_gain;

	public Buildings buildingHolder;

	// Use this for initialization
	void Start () {
		Invoke ("RecalculateGains", 1);
	}

	void Awake() {
		
		
	}

	// Update is called once per frame
	void Update () {
		stat_money += stat_money_gain * Time.deltaTime;
		stat_power += stat_power_gain * Time.deltaTime;
		stat_research += stat_research_gain * Time.deltaTime;
		stat_production += stat_production_gain * Time.deltaTime;
		//Debug.Log ("Money: " + stat_money + ", Power: " + stat_power + ", Reseearch: " + stat_research + ", Prod: " + stat_production);
	}

	public void RecalculateGains() {
		stat_money_gain = 0;
		stat_power_gain = 0;
		stat_production_gain = 0;
		stat_research_gain = 0;
		foreach (Building b in buildingHolder.bs) {
			stat_money_gain += b.extraMoney;
			stat_power_gain += b.extraPower;
			stat_production_gain += b.extraProduction;
			stat_research_gain += b.extraResearch;
		}
	}
}