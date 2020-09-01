using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWinButton : MonoBehaviour
{
    public void YouWin()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GetEnemyKillCount.money = 100;
        GetEnemyKillCount.health = 5;
        GetEnemyKillCount.killCount = 0;
        GetEnemyKillCount.totalKills = 0;
        GetEnemyKillCount.waveNumber = 1;
        GetEnemyKillCount.ammo = 50;
        GetEnemyKillCount.moneyIncrease = 0;
        GetEnemyKillCount.lastObjectHit = "";
        GetEnemyKillCount.isJoeKilled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
