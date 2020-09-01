using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiText : MonoBehaviour
{
    private int Score;
    public Text scoreText;
    public Text waveText;
    public Text healthText;
    public Text gameOverText;
    public Text ammoText;
    public Text moneyText;
    public Text moneyIncreaseText;
    public Text pickUpWeaponText;
    public GameObject playAgainButton;
    public GameObject menuButton;

    void Start()
    {
        playAgainButton.SetActive(false);
        menuButton.SetActive(false);
        Score = 0;
        SetScoreText();
        SetWaveText();
        SetHealthText();
        SetGameOverText(0);
        SetMoneyText();
        SetPickUpWeaponText(0);
        moneyIncreaseText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        moneyIncreaseText.text = "+$" + GetEnemyKillCount.moneyIncrease;
        SetScoreText();
        SetWaveText();
        SetHealthText();
        SetGameOverText(0);
        SetAmmoText();
        SetMoneyText();
        if (EnemyController.enemyKilled)
        {
            moneyIncreaseText.enabled = true;
            Invoke("CancelText", .75f);
        }
        EnemyController.enemyKilled = false;

    }

    void SetScoreText()
    {
            Score = GetEnemyKillCount.totalKills;
            scoreText.text = "Kills: " + Score.ToString();
    }

    void SetWaveText()
    {
        waveText.text = "Wave #" + GetEnemyKillCount.waveNumber;
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + GetEnemyKillCount.health;
    }

    public void SetGameOverText(int gameState)
    {
        if(GetEnemyKillCount.health != 0 && gameState == 0)
        {
            gameOverText.text = "";
            playAgainButton.SetActive(false);
            menuButton.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if(GetEnemyKillCount.health <= 0 && gameState != 1)
        {
            gameOverText.text = "Game over!";
            playAgainButton.SetActive(true);
            menuButton.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if(gameState == 1)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            FindObjectOfType<SpawnPlayer>().isHit();
            FindObjectOfType<SpawnPlayer>().isHit();
            FindObjectOfType<SpawnPlayer>().isHit();
            FindObjectOfType<SpawnPlayer>().isHit();
            FindObjectOfType<SpawnPlayer>().isHit();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void SetAmmoText()
    {

        if (GetEnemyKillCount.health > 0)
        {
            ammoText.text = "Ammo: " + GetEnemyKillCount.ammo;
        }
    }

    public void SetMoneyText()
    {
        moneyText.text = "Money: $" + GetEnemyKillCount.money;
    }

    public void CancelText()
    {
        moneyIncreaseText.enabled = false;
    }

    public void SetPickUpWeaponText(int weaponId)
    {
        if(weaponId == 0)
        {
            pickUpWeaponText.text = "";
        }
        else if(weaponId == 1)
        {
            pickUpWeaponText.text = "Cost $375: Press E to purchase";
        }
        else if(weaponId == 2)
        {
            pickUpWeaponText.text = "Cost $3000: Press E to purchase"; 
        }
        else if (weaponId == 3)
        {
            pickUpWeaponText.text = "Cost $500: Press E to purchase";
        }
        else if(weaponId == 4)
        {
            pickUpWeaponText.text = "Cost $1500: Press E to purchase";
        }
        else if(weaponId == 5)
        {
            pickUpWeaponText.text = "Cost $100: Press E to purchase";
        }
        else if(weaponId == 6)
        {
            if (GetEnemyKillCount.isJoeKilled)
            {
                pickUpWeaponText.text = "Press E to pick up the record";
            }
            else
            {
                pickUpWeaponText.text = "";
            }
        }
        else if (weaponId == 7)
        {
            pickUpWeaponText.text = "Cost $30000: Press E to purchase";
        }
        else
        {
            pickUpWeaponText.text = "";
        }
    }
}
