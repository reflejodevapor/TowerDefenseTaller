using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGamePlayerResourcesManager : MonoBehaviour
{

    public GameObject paletaDeRecursos;
    public GameObject imagenBloqueadora;
    UnityEngine.EventSystems.EventSystem evento; //Crea evento

    public Vector3 posicionAInstanciar;

    // Use this for initialization
    void Start ()
    {
        evento = GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>(); //Busca eventsystem por referencia

    }

    // Update is called once per frame
    void Update () 
    {

        if ((Input.GetMouseButtonDown(0)))//Checo si no se sobrepone un boton de UI con algo de mundo
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitCast;

            if (Physics.Raycast(ray, out hitCast, Mathf.Infinity))
            {

                if (hitCast.collider != null)
                {
                    if (hitCast.collider.gameObject.CompareTag("FriendSlot"))
                    {
                        posicionAInstanciar = hitCast.collider.gameObject.transform.position;
                        paletaDeRecursos.SetActive(true);
                        imagenBloqueadora.SetActive(true);
                        paletaDeRecursos.transform.position = Camera.main.WorldToScreenPoint(hitCast.collider.gameObject.transform.position);
                    }


                }
            }
        }
    }


    public void DesactivaPaleta()
    {
        paletaDeRecursos.SetActive(false);
        imagenBloqueadora.SetActive(false);
    }

    public GameObject amigo1;
    public void InstanciarAmigo()
    {
        GameObject amigo = Instantiate(amigo1, posicionAInstanciar, Quaternion.identity);
        amigo.transform.position = posicionAInstanciar;
    }
}
