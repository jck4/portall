using UnityEngine;

public class Player : MonoBehaviour
{

    public float baseHealth;
    public float baseMana;
    public float movementSpeed;
    public float speed = 1.0f;


    void Awake(){
        gameObject.tag = "Player";
    }

    void Update(){
        
    }

}
