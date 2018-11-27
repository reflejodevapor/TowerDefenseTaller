using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace turretGame{
	public class projectileBehaviour : MonoBehaviour {

		private turretBehaviour turretBehaviour;
		public float projectileSpeed;
		private Vector3 enemyPos;

		void Start () {}
		
		// Update is called once per frame
		void Update () {

		this.transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime,Space.Self);
		}

		void OnCollisionEnter(Collision _col)
		{
			_col.gameObject.GetComponent<Enemigo> ().Damage (1.0f);

			Destroy (gameObject);

		}

	}
}