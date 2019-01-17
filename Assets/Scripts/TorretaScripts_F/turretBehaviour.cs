using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace turretGame{
	public class turretBehaviour : MonoBehaviour {

		public bool LockOn = false;
		public GameObject enemyObjective;
		public GameObject projectile;	
		public GameObject turretHead;
		public float turretHealth;
		public float turretRateOfFire;
		public int maxLevel = 3;

		//Stats base para las torretas
		public float StatLvl2 = 0.05f;
		public float Statlvl3 = 0.1f;



		// Use this for initialization
		void Start () {
			
			
		}
		
		// Update is called once per frame
		void Update () {
            Debug.Log(LockOn);
			LevelUpTurret ();

		}

		void OnTriggerStay(Collider _col)
		{
			if(LockOn == false){
				
				if(_col.gameObject.CompareTag("Enemigo")){
					
					enemyObjective = _col.gameObject;
                    Invoke("Shoot", turretRateOfFire);
					//InvokeRepeating("Shoot",turretRateOfFire,turretRateOfFire);
					LockOn = true;
				}
			}
		}

        private void OnTriggerExit(Collider other)
        {
            if(other.gameObject.CompareTag("Enemigo"))
            {
                LockOn = false;
				CancelInvoke ("Shoot");
            }
        }


		///es solo un test para saber si cambia de fire rate la torreta. 
        void LevelUpTurret(){

			if (Input.GetKeyDown(KeyCode.Alpha1)) //en esta condicional originalmente va la interaccion con las variables del compra o mejora.
			{
				maxLevel = 2;
				Debug.Log ("Aqui subio de nivel");
				if (maxLevel == 2)
				{
					turretRateOfFire -= StatLvl2;
					Debug.Log ("Estoy disparando de acuerdo a la mejora del level 2");
				}
			}

			if (Input.GetKeyDown(KeyCode.Alpha2)) //en esta condicional originalmente va la interaccion con las variables del compra o mejora.
			{
				maxLevel = 3;
				Debug.Log ("Aqui subio de nivel de nuevo ");
				if (maxLevel == 3)
				{
					turretRateOfFire -= Statlvl3;
					Debug.Log ("mejora de level 3");
				}
			}


		}



		void Shoot(){
			Vector3 bulletPos = new Vector3(turretHead.transform.position.x,turretHead.transform.position.y + 3.0f,turretHead.transform.position.z);
			turretHead.transform.LookAt(enemyObjective.transform.position);

			GameObject bala = Instantiate(projectile, turretHead.transform.position,Quaternion.identity);
			bala.transform.LookAt(enemyObjective.transform.position,Vector3.up);
            //bala.transform.TransformDirection(enemyObjective.transform.position);

            LockOn = false;
		}

	}
}