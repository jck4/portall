using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Spell : MonoBehaviour
{

    private SphereCollider spellCollider;
    private Rigidbody spellRigidbody;
    public SpellScriptableObject spellToCast;


    private void Awake()
    {
        spellCollider = GetComponent<SphereCollider>();
        spellCollider.isTrigger = true;
        spellCollider.radius = spellToCast.spellRadius;
        spellRigidbody = GetComponent<Rigidbody>();
        spellRigidbody.isKinematic = true;
        Destroy(this.gameObject, spellToCast.lifetime);
    }

    private void Update()
    {
        if (spellToCast.speed > 0) 
            transform.position += (transform.forward * spellToCast.speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {   
        handleEnemyCollision(other.gameObject);
        //Apply Spell effects.
        //Apply particles?
        Destroy(this.gameObject);
    }

    private void handleEnemyCollision(GameObject enemy){
        if(enemy.TryGetComponent(out HealthSystem health)) health.handleDamage(spellToCast.baseDamage);
    }

}
