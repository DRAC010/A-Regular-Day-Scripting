using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinternaSliderController : MonoBehaviour {

	public LinternaController lc;
	Slider slider;

	void Start () {
		slider = GetComponent<Slider> ();
	}
	

	void Update () {
		slider.value = lc.carga;
	}
}
