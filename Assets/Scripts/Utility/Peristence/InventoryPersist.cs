using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPersist
{
    private static readonly string Money_KEY = "invMoney";
    private static readonly string FEED_LEVEL_KEY = "invFeedLevel";
    private static readonly string BATH_LEVEL_KEY = "invBathLevel";
    private static readonly string PETTING_LEVEL_KEY = "invBathLevel";
    private static readonly string TREADMILL_LEVEL_KEY = "invTreadmillLevel";

    public int getMoney() {
        if (PlayerPrefs.HasKey(Money_KEY)) {
            return PlayerPrefs.GetInt(Money_KEY);
        }
        return 0;
    }

    public void setMoney(int value) {

        if (value < 0) {
            value = 0;
        }
        PlayerPrefs.SetInt(Money_KEY, value);
    }

    public int getFeederLevel() {
        if (PlayerPrefs.HasKey(FEED_LEVEL_KEY)) {
            return PlayerPrefs.GetInt(FEED_LEVEL_KEY);  
        }
        return 0;
    }

    public void setFeederLevel(int value) {

        if (value < 0) {
            value = 0;
        }
        if (value > 2) {
            value = 2;
        }
        PlayerPrefs.SetInt(FEED_LEVEL_KEY, value);
    }
    
    public int getBathLevel() {
        if (PlayerPrefs.HasKey(BATH_LEVEL_KEY)) {
            return PlayerPrefs.GetInt(BATH_LEVEL_KEY);
        }
        return 0;
    }

    public void setBathLevel(int value) {

        if (value < 0) {
            value = 0;
        }
        if (value > 2) {
            value = 2;
        }
        PlayerPrefs.SetInt(BATH_LEVEL_KEY, value);
    }

    public int getPettingLevel() {
        if (PlayerPrefs.HasKey(PETTING_LEVEL_KEY)) {
            return PlayerPrefs.GetInt(PETTING_LEVEL_KEY);
        }
        return 0;
    }

    public void setPettingLevel(int value) {

        if (value < 0) {
            value = 0;
        }
        if (value > 1) {
            value = 1;
        }
        PlayerPrefs.SetInt(PETTING_LEVEL_KEY, value);
    }

    public int getTreadmillLevel() {
        if (PlayerPrefs.HasKey(TREADMILL_LEVEL_KEY)) {
            return PlayerPrefs.GetInt(TREADMILL_LEVEL_KEY);
        }
        return 0;
    }

    public void setTreadmillLevel(int value) {

        if (value < 0) {
            value = 0;
        }
        if (value > 1) {
            value = 1;
        }
        PlayerPrefs.SetInt(TREADMILL_LEVEL_KEY, value);
    }

    public void resetMoneyAndUpgrades() {
        PlayerPrefs.DeleteKey(Money_KEY);
        PlayerPrefs.DeleteKey(FEED_LEVEL_KEY);
        PlayerPrefs.DeleteKey(BATH_LEVEL_KEY);
        PlayerPrefs.DeleteKey(PETTING_LEVEL_KEY);
        PlayerPrefs.DeleteKey(TREADMILL_LEVEL_KEY);
    }
}
