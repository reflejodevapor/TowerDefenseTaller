using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeleccionarTorreta : MonoBehaviour {

    turretGame.turretBehaviour Torreta;

    public Camera cam;

    public LayerMask mascara;

    public Button Mejorar;

    // Use this for initialization
    void Start () {
        cam = gameObject.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray rayo = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(rayo, out hit, Mathf.Infinity, mascara))
            {
                Torreta = hit.collider.GetComponent<turretGame.turretBehaviour>();
                Mejorar.gameObject.SetActive(true);
                Torreta.Seleccionado = true;
                MejorarTorreta.Torreta = Torreta;

                Debug.Log(Torreta);
            }
            else
            {
                if (Torreta != null)
                {
                    Invoke("Unselect", 0.5f);
                }
                else
                {
                    //Mejorar.gameObject.SetActive(false);
                }
            }
        }
    }

    void Unselect()
    {
        Torreta.Seleccionado = false;
        MejorarTorreta.Torreta = Torreta = null;
        Mejorar.gameObject.SetActive(false);
    }
}
