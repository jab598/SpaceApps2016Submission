using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour 
{
	public Transform target;
	public float offset;
	public float inclination;

	void Update ()
	{
		transform.Rotate(Vector3.up*3*Time.deltaTime);
	}
}