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




		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {

		}

		void OnTriggerStay(Collider _col){
			if(LockOn == false){
				Debug.Log("entró al del lockon");
				if(_col.gameObject.CompareTag("Enemigo")){
					Debug.Log("entró al del tag");
					enemyObjective = _col.gameObject;
					InvokeRepeating("Shoot",turretRateOfFire,turretRateOfFire);
					LockOn = true;
				}
			}
		}

		void LevelUpTurret(){

		}

		void Shoot(){
			Vector3 enemyLook = new Vector3(enemyObjective.transform.position.x,enemyObjective.transform.position.y,enemyObjective.transform.position.z);
			Vector3 bulletPos = new Vector3(turretHead.transform.position.x,turretHead.transform.position.y + 3.0f,turretHead.transform.position.z);
			turretHead.transform.LookAt(enemyLook);
			GameObject bala = Instantiate(projectile, turretHead.transform.position,Quaternion.identity);
			bala.transform.LookAt(enemyObjective.transform.position,Vector3.up);
			//bala.transform.TransformDirection(enemyObjective.transform.position);
		}

	}
}