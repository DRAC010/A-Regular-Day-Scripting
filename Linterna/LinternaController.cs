using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinternaController : MonoBehaviour {

	Light linterna;
	public float carga;

	void Start () {
		linterna = GetComponent<Light> ();
		linterna.intensity = 0;
		carga = 100;
	}

	void Update () {
		if (Input.GetMouseButtonDown(1)) {
			if (linterna.intensity == 0) {
				linterna.intensity = 10;
			} else {
				linterna.intensity = 0;
			}
		}

		if (linterna.intensity == 10) {
			carga = carga - 5 * Time.deltaTime;
		}

		if (carga < 100 && linterna.intensity == 0) {
			carga = carga + 5 * Time.deltaTime;
			if (carga > 100) {
				carga = 100;
			}
		}

		if (carga <= 0) {
			linterna.intensity = 0;
		}
			
		if (carga > 100) {
			Debug.Log ("La carga es " + carga + 
				" y debería ser 100 o menos, o sea que chungo pelota");
		}

	}
}