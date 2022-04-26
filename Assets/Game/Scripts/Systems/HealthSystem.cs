using UnityEngine;
using System;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float minHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private float baseHealthRegeneration = .25f;

    private bool hasEnoughHealth; 

    [SerializeField] private GameObject healthBar;



    private void Update()
    {
        bool hasEnoughHealth = currentHealth > 0f;

        if (!hasEnoughHealth)
        {
           Destroy(gameObject);
        }
        
        handleHealthRegeneration();


        //Apply Updated healh values every frame to health
        if (healthBar.TryGetComponent(out SliderScript slider)) slider.SetSlider(currentHealth,maxHealth);

    }

    public void handleDamage(float damage){
        currentHealth -= damage;
    }

    private void handleHealthRegeneration(){
        if (currentHealth + (baseHealthRegeneration * Time.deltaTime) < 100) currentHealth += (baseHealthRegeneration * Time.deltaTime);
        else if(currentHealth + (baseHealthRegeneration * Time.deltaTime) > 100) currentHealth = maxHealth;
    }

}