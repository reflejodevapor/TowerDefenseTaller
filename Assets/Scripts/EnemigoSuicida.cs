using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSuicida : Enemigo {
    public float firingAngle = 45.0f;
    public float gravity = 9.8f;

    void Start()
    {
        /* Todo este desmadre es para que encuentre la torreta que le quede mas cerca */
        GameObject[] torretas = GameObject.FindGameObjectsWithTag("Torreta");
        float distancia = float.MaxValue; // Ups
        int selected = 0;
        for (int i = 0; i < torretas.Length; i++)
        {
            float distanciaTemp = Vector3.Distance(transform.position, torretas[i].transform.position);

            if (distanciaTemp < distancia)
            {
                selected = i;
            }
        }

        meta = torretas[selected]; //La asignamos a la varable meta

        StartCoroutine("SimulateProjectile");
    }

    IEnumerator SimulateProjectile()
    {
        // Short delay added before Projectile is thrown
        yield return new WaitForSeconds(1.5f);

        // Calculate distance to target
        float target_Distance = Vector3.Distance(transform.position, meta.transform.position);

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // Calculate flight time.
        float flightDuration = target_Distance / Vx;

        // Rotate projectile to face the target.
        transform.rotation = Quaternion.LookRotation(meta.transform.position - transform.position);

        float elapse_time = 0;

        while (elapse_time < flightDuration)
        {
            transform.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;

            yield return null;
        }
    }

}
