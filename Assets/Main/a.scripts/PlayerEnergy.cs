using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private PlayerConfig playerConfig;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            UseEnergy(1f);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            RecoverEnergy(1f);
        }
        
    }

    public void UseEnergy(float amount)
    {
        playerConfig.Energy -= amount;
        if (playerConfig.Energy < 0)
        {
            playerConfig.Energy = 0;
        }
    }
        public void RecoverEnergy(float amount)
        {
            playerConfig.Energy += amount;
            if (playerConfig.Energy > playerConfig.MaxEnergy)
            {
                playerConfig.Energy = playerConfig.MaxEnergy;
            }
        }
}

