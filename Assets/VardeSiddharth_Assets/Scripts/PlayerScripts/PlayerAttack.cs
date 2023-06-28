using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    bool hasAttackPower = false;

    [SerializeField]
    Transform hasAttackPowerImagetransform;

    // Start is called before the first frame update
    void Start()
    {
        ChangeAttackPowerUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAttackPowerGained()
    {
        hasAttackPower = true;
        ChangeAttackPowerUI();
    }

    void ChangeAttackPowerUI()
    {
        hasAttackPowerImagetransform.gameObject.SetActive(hasAttackPower);
    }

    void OnAttackPowerUsed()
    {
        hasAttackPower = false;
        ChangeAttackPowerUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AnimalMovements animalMovements;
        if(collision.TryGetComponent<AnimalMovements>(out animalMovements))
        {
            if(hasAttackPower)
            {
                animalMovements.AnimalDied();
                OnAttackPowerUsed();
            }
        }
    }
}
