using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace turretGame {
    public class UIGamePlayerResourcesManager : MonoBehaviour
    {

        public GameObject paletaDeRecursos;
        public GameObject imagenBloqueadora;
        UnityEngine.EventSystems.EventSystem evento; //Crea evento
        public LayerMask capaSlots;
        public GameObject slotToUse;
        public Vector3 posicionAInstanciar;
        public GameObject dineroInsuficienteText;
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

                if (Physics.Raycast(ray, out hitCast, Mathf.Infinity, capaSlots))
                {

                    if (hitCast.collider != null)
                    {
                        Debug.Log("HIT "+  hitCast.collider.gameObject);
                        if (hitCast.collider.gameObject.CompareTag("FriendSlot"))
                        {
                            if (hitCast.collider.gameObject.GetComponent<SlotStatus>().used == false)
                            {
                                posicionAInstanciar = hitCast.collider.gameObject.transform.position;
                                paletaDeRecursos.SetActive(true);
                                imagenBloqueadora.SetActive(true);
                                paletaDeRecursos.transform.position = Camera.main.WorldToScreenPoint(hitCast.collider.gameObject.transform.position);
                                slotToUse = hitCast.collider.gameObject;
                            }

                        }

                        if (CoolDowns.airStrikeIndicator == true && hitCast.collider.gameObject.CompareTag("enemyPath"))
                        {
                            Debug.Log("yea boi");
                            posicionAInstanciar = hitCast.collider.gameObject.transform.position;
                            StartCoroutine(addAirStrikeScript(hitCast.collider.gameObject));
                            CoolDowns.airStrikeIndicator = false;
                        }

                    }

                }
            }
        }


        public void DesactivaPaleta()
        {
            slotToUse = null;
            paletaDeRecursos.SetActive(false);
            imagenBloqueadora.SetActive(false);
        }

        public GameObject amigo1;
        public GameObject amigo2;
        public GameObject amigo3;

        public void InstanciarAmigo(int _i)
        {
            if(_i == 1)
            {
                if(UIManager.dinero >= 20)
                {
                    GameObject amigo = Instantiate(amigo1, posicionAInstanciar, Quaternion.identity);
                    amigo.transform.position = posicionAInstanciar;
                    slotToUse.GetComponent<SlotStatus>().used = true;
                    UIManager.dinero -= 20;
                }
                else
                {
                    dineroInsuficienteText.SetActive(true);
                }

            }
            if(_i == 2)
            {
                if (UIManager.dinero >= 15)
                {
                    GameObject amigo = Instantiate(amigo2, posicionAInstanciar, Quaternion.identity);
                    amigo.transform.position = posicionAInstanciar;
                    slotToUse.GetComponent<SlotStatus>().used = true;
                    UIManager.dinero -= 15;

                }
                else
                {
                    dineroInsuficienteText.SetActive(true);
                }
            }
            if (_i == 3)
            {
                if (UIManager.dinero >= 10)
                {
                    GameObject amigo = Instantiate(amigo3, posicionAInstanciar, Quaternion.identity);
                    amigo.transform.position = posicionAInstanciar;
                    slotToUse.GetComponent<SlotStatus>().used = true;
                    UIManager.dinero -= 10;

                }
                else
                {
                    dineroInsuficienteText.SetActive(true);
                }
            }
        }

        private IEnumerator addAirStrikeScript(GameObject cuadro)
        {
            if (cuadro.CompareTag("enemyPath") && !cuadro.GetComponent<airStrike>()){
                cuadro.AddComponent<airStrike>();
            }
            yield return new WaitForSeconds(6f);
            if (cuadro.CompareTag("enemyPath") && cuadro.GetComponent<airStrike>())
            {
                Debug.Log("hehe xd");
                Destroy(cuadro.GetComponent<airStrike>());
            }
        }

      
    }
}
