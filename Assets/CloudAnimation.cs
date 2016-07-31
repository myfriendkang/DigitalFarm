﻿using UnityEngine;
using System.Collections;

public class CloudAnimation : MonoBehaviour {

	public RectTransform target;
	public float rocketTurnSpeed = 90.0f;
	public float rocketSpeed = 10.0f;
	public float turbulence = 10.0f;
	void Update ( )
	{
		Vector3 direction = Distance( ) + Wiggle( );
		direction.Normalize( );
		//transform.rotation = Quaternion.RotateTowards( transform.rotation, Quaternion.LookRotation( direction ), rocketTurnSpeed * Time.deltaTime );
		gameObject.GetComponent<RectTransform>().Translate( Vector3.forward * rocketSpeed * Time.deltaTime );
	}
	private Vector3 Distance ( )
	{
		return target.position - transform.position;
	}
	private Vector3 Wiggle ( )
	{
		return Random.insideUnitSphere * turbulence;
	}
	

}
/*
iTween.MoveTo (displayInfo [0], iTween.Hash ("x", originalX,
	"time", 1.0f,
	"delay", 0.0f,
	"easeType", iTween.EaseType.easeOutExpo));
	*/