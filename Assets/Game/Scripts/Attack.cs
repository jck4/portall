using UnityEngine.InputSystem;
using UnityEngine;


public class Attack : MonoBehaviour {

[SerializeField] 
public InputAction castSpell = new InputAction();
public Transform player;

public bool readyToCast;

public virtual void Update(){
    player = GameObject.Find("Player").transform;
}
public virtual void cast(){
    
}

}
