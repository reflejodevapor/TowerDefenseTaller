using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStat : MonoBehaviour 
{


    public int vida = 100;
    public GameObject goImgVida;
    public Image imgVidaImg;
    public GameObject canvasG;
    public RectTransform rectImgVida;
	// Use this for initialization
	void Start () 
    {
        goImgVida = Resources.Load<GameObject>("UI/BarraVida");
        canvasG = GameObject.FindGameObjectWithTag("Canvas");
        GameObject uiBarraVida = Instantiate(goImgVida, transform.position, Quaternion.identity, canvasG.transform);
        imgVidaImg = uiBarraVida.GetComponent<Image>();
        rectImgVida = uiBarraVida.GetComponent<RectTransform>();


    }
	
	// Update is called once per frame
	void Update ()
    {
        rectImgVida.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y +0.5f, transform.position.z));
		
	}
}
