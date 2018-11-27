using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

    public GameObject goVidaBase;
    public float vidaBase;
    public Text vidaBaseTxt; 

	// Use this for initialization
	void Start ()
    {
        vidaBase = 100;

        vidaBaseTxt =  goVidaBase.GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () 
    {

        vidaBaseTxt.text = vidaBase.ToString();

        vidaBase = vidaBase -  Time.deltaTime;
		
	}
}
