using UnityEngine;

public class Projectile : Attack{

[SerializeField] public float baseProjectileSpeed;
public GameObject Projectile_Instance;

private void Awake(){
}

public override void cast(){
    readyToCast = true;
}


}
