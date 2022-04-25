using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;
using System;

public class MagicSystem : MonoBehaviour
{
    [SerializeField] private Spell spellToCast;
    [SerializeField] private float maxMana;
    [SerializeField] private float minMana;
    [SerializeField] private float currentMana;
    [SerializeField] private float baseManaRegeneration;
    [SerializeField] private float baseCastSpeed;
    [SerializeField] private float castTime = 0.25f;
    [SerializeField] private Transform castPoint;

    bool hasEnoughMana; 


    private float currentCastTimer;
    private float currentManaRegenTimer;
    private bool casting = false;
    private bool holdingCast = false;
    private Controls controls;

    private void Awake()
    {
        controls = new Controls();
    }


    private void Update()
    {

        holdingCast = controls.Gameplay.CastSpell1.IsPressed();
        bool hasEnoughMana = currentMana - spellToCast.spellToCast.baseManaCost > 0f;

        if (holdingCast)
        {
            if (!casting && hasEnoughMana)
            {
                casting = true;
                currentMana -= spellToCast.spellToCast.totalManaCost;
                currentCastTimer = 0;
                MovementSystem.agent.SetDestination(this.transform.position);
                MovementSystem.agent.isStopped = true;
                rotateTowardMouse(this.transform);
                castSpell();
                MovementSystem.agent.isStopped = false;

            }


            if (casting)
            {
                currentCastTimer += Time.deltaTime;
                currentManaRegenTimer += Time.deltaTime;
                if (currentCastTimer > castTime) casting = false;
            }

        }

    }

    
    private void rotateTowardMouse(Transform obj)
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            obj.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    private void castSpell()
    {
        Spell spell = Instantiate(spellToCast, castPoint.position, castPoint.rotation);
        spell.gameObject.SetActive(true);
    }
}