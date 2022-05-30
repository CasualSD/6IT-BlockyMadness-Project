using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WallStamina : MonoBehaviour
{
    public WallRun wl;
    public Slider wallRunStaminaBar;
    private int maxStamina = 100;
    public int currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.01f);
    private Coroutine regen;

    void Start()
    {
        currentStamina = maxStamina;
        wallRunStaminaBar.maxValue = maxStamina;
        wallRunStaminaBar.value = maxStamina;
    }

    public void UseStamina(int amount)
    {
        if(currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            wallRunStaminaBar.value = currentStamina;

            if (regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }
        else
        {
            wl.StopWallRun();
            Debug.Log("Not enough Stamina");
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(1f);

        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 50;
            wallRunStaminaBar.value = currentStamina;
            yield return regenTick;
        }
        regen = null;
    }
    
}
