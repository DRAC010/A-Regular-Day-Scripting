using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class RecogerAnkh : MonoBehaviour {

	public Text pensamientos;
	public ScriptColeccionablesPiramide coleccionables;

	public LayerMask objetos;
	public Image imagenInteractuar;

	void OnTriggerStay(Collider other){
		if (other.tag == "MainCamera") {
			if (Physics.Raycast (other.transform.position, other.transform.forward, 3f, objetos)) {
				Debug.Log ("Mirando a ankh");
				imagenInteractuar.color = new Color (1f, 1f, 1f, 1f);
				inventario invent = GameObject.Find ("Inventario").GetComponent<inventario> ();
				if (Input.GetMouseButtonDown (0)) {
					if(!invent.IsSeleccionado("palanca")){
						StartCoroutine (ShowMessage ("Voy a necesitar algo para arrancarlo.", 4));
					} else{				
						//Sonido
						PlaySound();
						//Fin sonido
						coleccionables.SendMessage ("ActivaAnkh");
						Destroy (transform.parent.gameObject, 0.2f);
						invent.QuitarObjeto ("palanca");
						invent.AñadirObjeto ("ankh");
						imagenInteractuar.color = new Color (1f, 1f, 1f, 0f);
					}
			} else {
				imagenInteractuar.color = new Color (1f, 1f, 1f, 0f);
				}
			}
		}
	}


	void OnTriggerExit(){
		imagenInteractuar.color = new Color (1f, 1f, 1f, 0f);
	}

	void PlaySound(){
		AudioSource source = GetComponent<AudioSource>();
		source.Play ();
	}

	IEnumerator ShowMessage(string message, float delay){
		pensamientos.text = message;
		pensamientos.enabled = true;
		yield return new WaitForSeconds (delay);
		pensamientos.enabled = false;
	}


}
