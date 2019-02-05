using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace turretGame { 
    public class CoolDowns : MonoBehaviour {

        private float coolDownTimer_AS;
        public float airStrikeCoolDown;

        private float coolDownTimer_IMM;
        public float instantMoneyMultiplierCoolDown;

        private float coolDownTimer_DSS;
        public float doubleShootingSpeedCoolDown;

        public static bool airStrikeIndicator = false;

        public Button buttonAirStrike;
        public Button buttonMoneyMultiplier;
        public Button buttonDoubleShootingSpeed;

        public Text airStrikeText;
        public Text moneyText;
        public Text speedText;

        private string cdIndicator;

            void Start()
            {
                coolDownTimer_AS = airStrikeCoolDown;
                coolDownTimer_DSS = doubleShootingSpeedCoolDown;
                coolDownTimer_IMM = instantMoneyMultiplierCoolDown;
                moneyText.enabled = false;
                speedText.enabled = false;
                airStrikeText.enabled = false;
                turretBehaviour.turretRateOfFire = 0.8f;
            }

            // Update is called once per frame
            void Update() {

            if (buttonAirStrike.CompareTag("used"))
            {

                if (coolDownTimer_AS > 0)
                {
                    coolDownTimer_AS -= Time.deltaTime;
                }
            }

            if (buttonMoneyMultiplier.CompareTag("used"))
            {
                Debug.Log("entro a used de 2");
                if (coolDownTimer_IMM > 0)
                {
                    coolDownTimer_IMM -= Time.deltaTime;
                }
            }
        
            if (buttonDoubleShootingSpeed.CompareTag("used"))
            {
                Debug.Log("entro a used de 3");
                if (coolDownTimer_DSS > 0)
                {
                    coolDownTimer_DSS -= Time.deltaTime;
                }
            }
        

            ////////////////////////////////////////////


            if (coolDownTimer_AS <= 0)
            {
                buttonAirStrike.tag = "unused";
                coolDownTimer_AS = airStrikeCoolDown;
            }

            if (coolDownTimer_IMM <= 0)
            {
                buttonMoneyMultiplier.tag = "unused";
                coolDownTimer_IMM = instantMoneyMultiplierCoolDown;
            }

            if (coolDownTimer_DSS <= 0)
            {
                buttonDoubleShootingSpeed.tag = "unused";
                coolDownTimer_DSS = doubleShootingSpeedCoolDown;
            }

            /////////////////////////////////////////////

            if (buttonAirStrike.CompareTag("used"))
            {
                airStrikeText.enabled = true;
                buttonAirStrike.interactable = false;

            }
            else
            {

                airStrikeText.enabled = false;
                buttonAirStrike.interactable = true;

            }

            if (buttonDoubleShootingSpeed.CompareTag("used"))
            {
                speedText.enabled = true;
                buttonDoubleShootingSpeed.interactable = false;

            }
            else
            {
                speedText.enabled = false;
                buttonDoubleShootingSpeed.interactable = true;
            
            }

            if (buttonMoneyMultiplier.CompareTag("used"))
            {
                moneyText.enabled = true;
                buttonMoneyMultiplier.interactable = false;
            }
            else
            {
                moneyText.enabled = false;
                buttonMoneyMultiplier.interactable = true;
            }

            ////////////////////////////////////////////

            moneyText.text = Mathf.Round(coolDownTimer_IMM).ToString();
            speedText.text = Mathf.Round(coolDownTimer_DSS).ToString();
            airStrikeText.text = Mathf.Round(coolDownTimer_AS).ToString();

            cdIndicator = "CD Air Strike: " + coolDownTimer_AS.ToString() + "- CD Money Multiplier: " + coolDownTimer_IMM.ToString() + " - CD Double Speed: " + coolDownTimer_DSS.ToString();



            //Debug.Log(cdIndicator);


        }

        public void button_airstrike_clicked()
        {
            airStrikeIndicator = true;
            buttonAirStrike.tag = "used";
            Debug.Log(airStrikeIndicator.ToString());

        }

        public void button_money_clicked()
        {
            buttonMoneyMultiplier.tag = "used";

            UIManager.dinero *= 2;
        }

        public void button_speed_clicked()
        {
            buttonDoubleShootingSpeed.tag = "used";
            StartCoroutine("speedforturrets");
        }

        private IEnumerator speedforturrets()
        {
            turretBehaviour.turretRateOfFire /= 1.2f;
            yield return new WaitForSeconds(2.5f);
            turretBehaviour.turretRateOfFire *= 1.2f;
        }
    }
}