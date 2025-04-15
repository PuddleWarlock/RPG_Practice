using System;
using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ScaleParticles : MonoBehaviour {
	[Obsolete("Obsolete")]
	void Update () {
		GetComponent<ParticleSystem>().startSize = transform.lossyScale.magnitude;
	}
}