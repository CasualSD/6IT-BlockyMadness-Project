using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GrappleStamina : MonoBehaviour
{
    public GrapplingGun gp;
    public Slider grappleStaminaBar;
    private int maxStamina = 300;
    private int currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.01f);
    private Coroutine regen;

    public static GrappleStamina instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentStamina = maxStamina;
        grappleStaminaBar.maxValue = maxStamina;
        grappleStaminaBar.value = maxStamina;
    }

    public void UseStamina(int amount)
    {
        if(currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            grappleStaminaBar.value = currentStamina;

            if (regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }
        else
        {
            gp.StopGrapple();
            Debug.Log("Not enough Stamina");
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(1f);

        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 50;
            grappleStaminaBar.value = currentStamina;
            yield return regenTick;
        }
        regen = null;
    }
    
}
