using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colSound : MonoBehaviour
{
     private AudioSource audioSource;
	[SerializeField]
	private AudioClip Sound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent <AudioSource> ();
    }

    // Update is called once per frame
   private void OnCollisionEnter(Collision collision){
    
        audioSource.PlayOneShot (Sound);
        Debug.Log("asdfa");
    }
}
