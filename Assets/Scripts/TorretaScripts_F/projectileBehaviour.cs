using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace turretGame{
	public class projectileBehaviour : MonoBehaviour {

		private turretBehaviour turretBehaviour;
		public float projectileSpeed;
		private Vector3 enemyPos;
        [SerializeField]
        private float Damage = 2;

		void Start () {}
		
		// Update is called once per frame
		void Update () {

		this.transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime,Space.Self);
		}

		void OnTriggerEnter(Collider _col)
		{
            if(_col.gameObject.GetComponentInParent<Enemigo>() != null)
            {
                _col.gameObject.GetComponentInParent<Enemigo>().Damage(Damage);

                this.gameObject.SetActive(false);
            }


        }

    }

}
