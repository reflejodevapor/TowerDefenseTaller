﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void cargarnivel(string pnivel)
    {
        SceneManager.LoadScene(pnivel);
    }

    public void Exitgame()
    {
        Application.Quit();
        print("ME SALI");
    }
}
