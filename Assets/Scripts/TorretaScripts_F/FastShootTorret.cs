using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastShootTorret : MonoBehaviour {
    public GameObject Bullet;
    public Transform Enemy;


    float FireRate;
    //float Damage;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShootTest();

    }

    public void ShootTest()
    {
        gameObject.transform.LookAt(Enemy.transform);
        FireRate -= Time.deltaTime;
        if (FireRate <= 0)
        {
            if (Vector3.Distance(Enemy.position, transform.position) < 20)
            {
                GameObject go = Instantiate(Bullet, transform.position, Quaternion.identity);
                go.GetComponent<Rigidbody>().AddForce(transform.forward * 25000f * Time.deltaTime);

                Destroy(go, 1f);
            }
            FireRate = 0.2f;
        }

    }

    

}
