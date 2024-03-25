using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneController : MonoBehaviour
{
	public float throttleIncrement = 0.1f;
	public float maxThrust = 200f;
	public float responsiveness = 10f;
	public float lift = 135f;

	private float throttle;
	private float roll;
	private float yaw;
	private float pitch;

	private float responseModifier {
		get {
			return(rb.mass/10f) * responsiveness;
		}
	}
	Rigidbody rb;
	[SerializeField] TextMeshProUGUI hud; 
	[SerializeField] Transform propellor;

	private void Awake(){
		rb = GetComponent<Rigidbody>();
	}

	private void HandleInputs() {
		roll = Input.GetAxis("Roll");
		pitch = Input.GetAxis("Pitch");
		yaw = Input.GetAxis("Yaw");

		if(Input.GetKey(KeyCode.Space)) throttle += throttleIncrement;
		else if (Input.GetKey(KeyCode.LeftControl)) throttle -= throttleIncrement;
		throttle = Mathf.Clamp(throttle, 0f, 100f);
	}

	private void Update() {
		
		HandleInputs();
		UpdateHUD();

		propellor.Rotate(Vector3.right * throttle);
	}

	private void FixedUpdate() {

		rb.AddForce(-transform.right * maxThrust * throttle);
		rb.AddTorque(transform.up * yaw * responseModifier);
		rb.AddTorque(transform.forward * pitch * responseModifier);
		rb.AddTorque(transform.right * roll * responseModifier);
		rb.AddForce(transform.up * rb.velocity.magnitude * lift);

	}
	private void UpdateHUD() {
		hud.text = "Throttle: " + throttle.ToString("F0") + "%\n";
		hud.text += "Airspeed: " + (rb.velocity.magnitude * 1.9f).ToString("F0") + " knots \n";
		hud.text += "Altitude: " + transform.position.y.ToString("F0") + " m";
	}
}
