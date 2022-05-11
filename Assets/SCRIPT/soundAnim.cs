using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundAnim : MonoBehaviour {

    private AudioSource audioSource;
	[SerializeField]
	private AudioClip appearSE;

	void Start(){
		audioSource = GetComponent <AudioSource> ();
		
	}
    void walkSound() {
        audioSource.PlayOneShot (appearSE);
		
    }

}