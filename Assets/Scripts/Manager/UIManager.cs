using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Reference")] // Fir niw
    [SerializeField] private PlayerConfig playerConfig;

    [Header("Player UI")]
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Image armorBar;
    [SerializeField] private TextMeshProUGUI armorText;
    [SerializeField] private Image energyBar;
    [SerializeField] private TextMeshProUGUI energyText;


    private void Update()
    {

    }

    private void UpdatePlayerUI()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, 
            playerConfig.CurrentHealth / playerConfig.MaxHealth, 10f * Time.deltaTime);
        armorBar.fillAmount = Mathf.Lerp(armorBar.fillAmount,
            playerConfig.Armor / playerConfig.MaxArmor, 10f * Time.deltaTime);
        energyBar.fillAmount = Mathf.Lerp(energyBar.fillAmount,
            playerConfig.Energy / playerConfig.MaxEnergy, 10f * Time.deltaTime);

        healthText.text = $"{playerConfig.CurrentHealth} / {playerConfig.MaxHealth}";
        armorText.text = $"{playerConfig.Armor} / {playerConfig.MaxArmor}";
        energyText.text = $"{playerConfig.Energy} / {playerConfig.MaxEnergy}";
    }

}
