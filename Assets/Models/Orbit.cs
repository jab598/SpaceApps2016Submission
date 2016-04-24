using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour 
{
	public Transform target;
	public float offset;
	public float inclination;

	void Update () 
	{
		Vector3 relativePos = new Vector3 (Mathf.Sin (Time.time+(offset/360)), Mathf.Sin(Time.time)*inclination, Mathf.Cos (Time.time+offset/360))*4250;
		transform.position = relativePos;
	}
}