using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
public class MenuManager : Singleton<MenuManager>
{
        [Header("Config")]  
        [SerializeField] private PlayerCreation[] players;

        [Header("UI")]
        [SerializeField] private GameObject playerPanal;
        [SerializeField] private Image playerIcon;
        [SerializeField] private TextMeshProUGUI playerName;
        [SerializeField] private TextMeshProUGUI playerLevel;
        [SerializeField] private TextMeshProUGUI playerHealthMaxstat;
        [SerializeField] private TextMeshProUGUI playerArmorMaxstat;
        [SerializeField] private TextMeshProUGUI playerEnergyMaxstat;
        [SerializeField] private TextMeshProUGUI playerCriticalMaxstat;
        [SerializeField] private TextMeshProUGUI coinsTMP;
        [SerializeField] private TextMeshProUGUI playerUpgrageCostTMP;
        [SerializeField] private TextMeshProUGUI playerUnlockCostTMP;

        [Header("Bars")]
        [SerializeField] Image healhBar;
        [SerializeField] Image armorBar;
        [SerializeField] Image enegryBar;
        [SerializeField] Image critialBar;
        

        [Header("Button")]    
        [SerializeField] private GameObject unlockButton;
        [SerializeField] private GameObject upgrageButton;
        [SerializeField] private GameObject selectButton;

private SelectablePlayer currentPlayer;
private void Start()
        {
            CreatePlayer();
        }

     

private void Update()
        {
            coinsTMP.text = CoinManger.Instance.Coins.ToString();
        }

private void CreatePlayer()
        {
            for (int i = 0; i < players.Length; i++)
            {

                PlayerMove player = Instantiate(players[i].Player, players[i].CreationPos.position, Quaternion.identity, players[i].CreationPos);
                player.enabled = true;

            }
        }

public void ClickPlayer(SelectablePlayer selectablePlayer)
        {
            currentPlayer = selectablePlayer;
            VerifyPlayer();
            ShowPlayerStats();
        }

public void SelectPlayer()
        {
            if (currentPlayer.Config.Unlocked)
            {
                currentPlayer.GetComponent<PlayerMove>().enabled = true;
                currentPlayer.Config.ResetPlayerStats();
                ClosePlayerPanel();

            }
        }
public void UpgragePlayer()
        {
        if (CoinManger.Instance.Coins >= currentPlayer.Config.UpgrageCost)
            {
            CoinManger.Instance.RemoveCoins(currentPlayer.Config.UpgrageCost);
                UpgragePLayerStats();
                ShowPlayerStats();
            }
        }
        
        public void UnlockPlayer()
    {
        if (CoinManger.Instance.Coins >= currentPlayer.Config.UnlockCost)
        {
            CoinManger.Instance.RemoveCoins(currentPlayer.Config.UnlockCost);
            currentPlayer.Config.Unlocked = true;
            VerifyPlayer();
            ShowPlayerStats();
        }
    }
        
private void UpgragePLayerStats()
        {
            PlayerConfig config = currentPlayer.Config;
            config.Level++;
            config.MaxHealth++;
            config.MaxArmor += 10f;
            config.CriticalChance += 2f;
            config.CriticalDamage += 5f;

            config.MaxHealth = Mathf.Min(config.MaxHealth, config.HealthMaxUpgrage );
            config.MaxArmor = Mathf.Min(config.MaxArmor, config.ArmorMaxUpgrage );
            config.MaxEnergy = Mathf.Min(config.MaxEnergy, config.EnergyMaxUpgrage );
            config.CriticalChance = Mathf.Min(config.CriticalChance, config.CritialMaxUpgrage );

            float upgrage = config.UpgrageCost;
        config.UpgrageCost = upgrage + (upgrage * (config.UpgrageMultiplier / 100f));

        }


private void ShowPlayerStats()
        {
            playerPanal.SetActive(true);
            playerIcon.sprite = currentPlayer.Config.Icon;
            playerName.text = currentPlayer.Config.Name;
            playerLevel.text = $"Level {currentPlayer.Config.Level}";
            playerHealthMaxstat.text = currentPlayer.Config.MaxHealth.ToString();
            playerArmorMaxstat.text = currentPlayer.Config.MaxArmor.ToString();
            playerEnergyMaxstat.text = currentPlayer.Config.MaxEnergy.ToString();
            playerCriticalMaxstat.text = currentPlayer.Config.CriticalChance.ToString();
            playerUnlockCostTMP.text = currentPlayer.Config.UnlockCost.ToString();  
            playerUpgrageCostTMP.text = currentPlayer.Config.UpgrageCost.ToString();

            //Update Bars
            healhBar.fillAmount = currentPlayer.Config.MaxHealth / currentPlayer.Config.HealthMaxUpgrage; 
            armorBar.fillAmount = currentPlayer.Config.MaxArmor / currentPlayer.Config.ArmorMaxUpgrage; 
            enegryBar.fillAmount = currentPlayer.Config.MaxEnergy / currentPlayer.Config.EnergyMaxUpgrage; 
            critialBar.fillAmount = currentPlayer.Config.CriticalChance / currentPlayer.Config.CritialMaxUpgrage; 
        }

    private void VerifyPlayer()
    {
        if (currentPlayer.Config.Unlocked == false)
        {
            upgrageButton.SetActive(false);
            selectButton.SetActive(false);
            unlockButton.SetActive(true);
        }
        else
        {
            upgrageButton.SetActive(true);
            selectButton.SetActive(true);
            unlockButton.SetActive(false);
        }
    }

public void ClosePlayerPanel()
        {
            playerPanal.SetActive(false);
        }
}

[Serializable]
    public class PlayerCreation
    {
    public PlayerMove Player;
    public Transform CreationPos;
    }
