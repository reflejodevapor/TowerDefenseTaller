using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDowns : MonoBehaviour {

    public float coolDownTimer_AS;
    public float airStrikeCoolDown;

    public float coolDownTimer_IMM;
    public float instantMoneyMultiplierCoolDown;

    public float coolDownTimer_DSS;
    public float doubleShootingSpeedCoolDown;

    public Button buttonAirStrike;
    public Button buttonMoneyMultiplier;
    public Button buttonDoubleShootingSpeed;

	
	// Update is called once per frame
	void Update () {
		
        if(coolDownTimer_AS > 0)
        {
            coolDownTimer_AS -= Time.deltaTime;
        }

        if(coolDownTimer_IMM > 0)
        {
            coolDownTimer_IMM -= Time.deltaTime;
        }

        if(coolDownTimer_DSS > 0)
        {
            coolDownTimer_DSS -= Time.deltaTime;
        }

        ////////////////////////////////////////////

        
        if (coolDownTimer_AS < 0)
        {
            coolDownTimer_AS = airStrikeCoolDown;
        }

        if (coolDownTimer_IMM < 0)
        {
            coolDownTimer_IMM = instantMoneyMultiplierCoolDown;
        }

        if (coolDownTimer_DSS < 0)
        {
            coolDownTimer_DSS = doubleShootingSpeedCoolDown;
        }

        ////////////////////////////////////////////


    }
}
