using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : Monobehavior
{
    public EnemyScriptableObject enemy;

    private Awake()
    {
        enemy = (EnemyScriptableObject)Resources.Load("Enemies/Enemy1", typeof(EnemyData));
    }
}