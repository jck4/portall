using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Spell Object", menuName = "Spell System/Spells/Spell")]
public class SpellScriptableObject : ScriptableObject
{
    public float baseDamage = 10f;
    public float baseManaCost = 10f;
    [SerializeField]
    public float lifetime = 4f;
    public float speed = 15f;
    public float spellRadius = 0.5f;
    public float totalManaCost;
    

    private void Awake()
    {
        //Add a way to modify mana cost. 
        totalManaCost = (baseManaCost);
    }


}
