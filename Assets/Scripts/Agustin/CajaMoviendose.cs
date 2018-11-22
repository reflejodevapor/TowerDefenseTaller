using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaMoviendose : MonoBehaviour
{
    public Vector3 Velocidad;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.Translate(Velocidad * Time.deltaTime);
	}
}
