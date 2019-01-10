using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanque : Enemigo {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void TakeDamage(float DamageTaken)
    {
        this.Damage(DamageTaken);
    }

    void DoDamage(float DamageDone)
    {

    }
}
