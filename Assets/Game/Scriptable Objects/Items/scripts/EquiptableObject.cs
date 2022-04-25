using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equiptable Object", menuName = "Item System/Items/Equiptable")]
public class EquiptableObject : ItemObject{
    public void Awake()
    {
        type = ItemType.Equiptable;
    }
}
