using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace turretGame{
	public class enemyBehaviour : MonoBehaviour {

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		void OnColliderEnter(Collider _col){
			if(_col.gameObject.CompareTag("bullet")){
				Destroy(_col.gameObject);
				Destroy(this.gameObject);
			}
		}
	}
}