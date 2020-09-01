using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class GetEnemyKillCount : MonoBehaviour
{
    public static int killCount = 0;
    public static int totalKills = 0;
    public static int waveNumber = 1;
    public static int health = 5;
    public static int ammo = 50;
    public static int money = 100;
    public static int moneyIncrease = 0;
    public static string lastObjectHit = "";
    public static bool isJoeKilled = false;
}
