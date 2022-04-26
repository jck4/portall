using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Enemy Object", menuName = "Enemy System/Enemies/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public float baseSpeed = 1f;
    public float maxHealth;
    public float currentHealth;
}
