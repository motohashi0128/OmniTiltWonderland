using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pitcher : MonoBehaviour
{

    public List<GameObject> t_objs;
    //public GameObject target_obj;
    private GameObject throwingObj;
    private Rigidbody rig1;
    private List<GameObject> e_objs;

    public int max_count = 100;

    Vector3 tvec;
    Vector3 tpos;
    Vector3 ttor;

    Vector3 sa;
    Vector3 muki;
    // Start is called before the first frame update

    int obj_num;
    int rand_max;

    Vector3 target_pos;

    public float timeOut = 3.0f;
    private float timeElapsed;

    void Start()
    {
        e_objs = new List<GameObject>();
        rand_max = t_objs.Count;
        target_pos = new Vector3(this.transform.position.x, this.transform.position.y+2, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;


        tpos = this.transform.position;

        sa = (target_pos - tpos);
        muki = sa.normalized;

        //print(sa);

        if (Input.GetKeyDown(KeyCode.P))
        {
            ttor = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2));
            obj_throw(obj_num);
        }

        //print(e_objs.Count);

        if (e_objs.Count > max_count)
        {
            Destroy(e_objs[0]);
            e_objs.RemoveAt(0);
        }

        //

        Time.timeScale = 1.0f;

        Time.fixedDeltaTime = 0.02f * Time.timeScale;


        if (timeElapsed >= timeOut)
        {
            // Do anything
            obj_num = Random.Range(0, rand_max);
            ttor = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2));
            obj_throw(obj_num);

            timeElapsed = 0.0f;
        }
    }

    void obj_throw(int num)
    {


        tvec = new Vector3(muki.x * 300 + Random.Range(-70, 70), 500 + Random.Range(-10, 120), muki.z * 300 + Random.Range(-70, 70));


        throwingObj = Instantiate(t_objs[num], tpos, Quaternion.identity) as GameObject;

        e_objs.Add(throwingObj);

        throwingObj.GetComponent<Rigidbody>().useGravity = true;

        rig1 = throwingObj.GetComponent<Rigidbody>();
        rig1.AddTorque(ttor, ForceMode.Impulse);
        rig1.AddForce(tvec);


    }

    public void button_throw(int num){
        ttor = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2));
        obj_throw(num);
    }

   
}
