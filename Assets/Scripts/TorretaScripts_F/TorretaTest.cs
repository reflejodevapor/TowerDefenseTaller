using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaTest : MonoBehaviour {
    public GameObject Bala;
    public Transform Enemigo;


    float Damage;
    float FireRate01;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DispTest();

	}

    public void DispTest()
    {
        gameObject.transform.LookAt(Enemigo.transform);
        FireRate01 -= Time.deltaTime;
        if (FireRate01 <= 0)
        {
            if (Vector3.Distance(Enemigo.position, transform.position) < 20)
            {
                GameObject go = Instantiate(Bala, transform.position, Quaternion.identity);
                go.GetComponent<Rigidbody>().AddForce(new Vector3(Enemigo.position.x*3500f*Time.deltaTime,Enemigo.position.y*15000f*Time.deltaTime,transform.position.z*Enemigo.position.z*100*Time.deltaTime));

                Destroy(go, 5f);
            }
            FireRate01 = 2f;
        }

    }

        
}
