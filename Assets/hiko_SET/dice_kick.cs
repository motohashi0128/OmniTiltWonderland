using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dice_kick : MonoBehaviour
{
    private Rigidbody _rigidbody;
    float limit_time = 3.0f;
    float count_time = 0.0f;

    Vector3 ini_pos;
    // Start is called before the first frame update
    void Start()
    {
        ini_pos = this.gameObject.transform.position;
         _rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        count_time += Time.deltaTime;
        if(count_time > limit_time){
            count_time = 0.0f;
            this.gameObject.transform.position = ini_pos;
            _rigidbody.rotation = Quaternion.Euler(Random.Range(-180,180), Random.Range(-180, 180), Random.Range(-180, 180));

            kick();
        }
    }

    void kick(){
        //print("kick!s");
         Vector3 kick = new Vector3(Random.Range(-6, 6), Random.Range(0, 0), Random.Range(-6, 6));
        _rigidbody.AddForce(kick, ForceMode.Impulse);
        Vector3 kick2 = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50));

        _rigidbody.AddTorque(kick2, ForceMode.Impulse);
    }
}
