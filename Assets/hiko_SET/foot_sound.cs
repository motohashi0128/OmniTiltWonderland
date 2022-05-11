using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foot_sound : MonoBehaviour
{
    // Start is called before the first frame update
   
    public AudioSource aSource;

    public List<AudioClip> clips;
    //public List<AudioClip> clips_leaf;
	// 足音の最短間隔
	private const float PLAY_INTERVAL_MIN_SEC = 0.6f;
	// 最後に足音鳴らした時刻
	private System.DateTime lastStepTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter (Collider other)
    {
//        print("foot!");
        if ((System.DateTime.Now - lastStepTime).TotalSeconds < PLAY_INTERVAL_MIN_SEC) {
			// タップダンス的な足音連打事故を防ぐ
			return;
		}
            int rand_num = Random.Range(0,clips.Count);
            aSource.clip = clips[rand_num];
			aSource.Play ();
        
			lastStepTime = System.DateTime.Now;
		
    }
}
