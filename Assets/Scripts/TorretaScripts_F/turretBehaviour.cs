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
		public float turretDamage;
		public int maxLevel;

		// Nivel actual de la torreta
		public int Level = 1;

		public List<float> FireRates = new List<float>();
		public List<float> damages = new List<float> ();

		// Use this for initialization
		void Start () 
		{
			
			turretRateOfFire = FireRates [0];
			turretDamage = damages [0];
		}
		
		// Update is called once per frame
		void Update () 
		{
            Debug.Log(LockOn);

			if(Input.GetKeyDown(KeyCode.Alpha1)){LevelUpTurret ();}

			if (Input.GetKeyDown (KeyCode.Alpha2)) {LevelDownTurret ();}			

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
        void LevelUpTurret()
		{
			
				if (Level < maxLevel) 
					{                                  
						Level = Level + 1;
					}

				turretRateOfFire = FireRates [Level - 1];
				turretDamage = damages [Level - 1];
				Debug.Log ("Aqui subio de nivel");
				print (turretRateOfFire);

		}

		void LevelDownTurret()
		{
				if (Level > 1) 
					{                                  
						Level--;
					}
				turretRateOfFire = FireRates [Level - 1];
		}


		void Shoot(){
			Vector3 bulletPos = new Vector3(turretHead.transform.position.x,turretHead.transform.position.y + 3.0f,turretHead.transform.position.z);
			turretHead.transform.LookAt(enemyObjective.transform.position);

			GameObject bala = Instantiate(projectile, turretHead.transform.position,Quaternion.identity);
			bala.transform.LookAt(enemyObjective.transform.position,Vector3.up);

			bala.GetComponent<projectileBehaviour> ().TorretaPadre = turretHead.gameObject;
            //bala.transform.TransformDirection(enemyObjective.transform.position);

            LockOn = false;
		}

	}
}