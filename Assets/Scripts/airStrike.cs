using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace turretGame
{
    public class airStrike : MonoBehaviour {

        private Material materialOriginal;
        private Color colorOriginal;
	    // Use this for initialization
	    void Start () {
            materialOriginal = this.gameObject.GetComponent<MeshRenderer>().material;
            colorOriginal = this.gameObject.GetComponent<MeshRenderer>().material.color;
            this.gameObject.GetComponent<MeshRenderer>().material.color = new Color(180, 0, 0);
	    }

        private void OnDestroy()
        {
            Debug.Log("test");
            this.gameObject.GetComponent<MeshRenderer>().material.color = colorOriginal;
        }

        // Update is called once per frame
        void Update () {
		
	    }

        private void OnCollisionStay(Collision collision)
        {
            Enemigo et = collision.gameObject.GetComponent<EnemigoTerrestre>(); //agarra el script
            if (collision.gameObject.CompareTag("Enemigo") && et != null)
            {
                collision.gameObject.GetComponent<NavMeshAgent>().speed = 1.35f;
                if(et.hit == false) { 
                StartCoroutine(damageTurrets(collision.gameObject));
                    et.hit = true;
                }
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemigo"))
            {
                collision.gameObject.GetComponent<NavMeshAgent>().speed = 2.6f;
                StopCoroutine("damageTurrets");
            }
        }


        private IEnumerator damageTurrets(GameObject turret)
        {
            EnemigoTerrestre et = turret.GetComponent<EnemigoTerrestre>(); //agarra el script
            if (turret.CompareTag("Enemigo")){ ///checa si esta y si tiene el tag enemigo
                et.Damage(0.5f); // le quita 0.5 de daño de 3 totales cada 0.8s.
                yield return new WaitForSeconds(0.8f);
                et.GetComponent<Enemigo>().hit = false;
            }
        }
    }
}