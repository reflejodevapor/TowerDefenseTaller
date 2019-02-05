using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	public class turretBehaviour : MonoBehaviour {

		public bool LockOn = false;
		public GameObject enemyObjective;
		public GameObject projectile;	
		public GameObject turretHead;
		public float turretHealth;
		public static float turretRateOfFire;
		public int maxLevel = 3;




		// Use this for initialization
		void Start () {
			
		}
		


		void OnTriggerEnter(Collider _col)
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

        void LevelUpTurret(){

		}

	void Shoot()
    {

        if (enemyObjective != null)
        {
            Vector3 bulletPos = new Vector3(turretHead.transform.position.x, turretHead.transform.position.y + 3.0f, turretHead.transform.position.z);
            turretHead.transform.LookAt(enemyObjective.transform.position);

            GameObject bala = Instantiate(projectile, turretHead.transform.position, Quaternion.identity);
            bala.transform.LookAt(enemyObjective.transform.position, Vector3.up);
            //bala.transform.TransformDirection(enemyObjective.transform.position);

            LockOn = false;
        }
        else
            LockOn = false;
       


	}

	}
