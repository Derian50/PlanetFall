using UnityEngine;

using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;


[System.Serializable] 
public class SavedData
{
    public float damageStart;
    public float atackSpeedStart;
    public float critChanceStart;
    public float critDamageStart;
    public float rangeStart;
    public float damageDistanceStart;
    public float multishotChanceStart;
    public float multishotTargetsStart;
    public float HpStart;
    public float hpRegenStart;
    public float moneyCoefStart;
    public float moneyPerWaveStart;
    public float maxTimeScale;
}

public class SaveManager: MonoBehaviour
{

    //public SavedData SavedData;
    //public static SaveManager Instance;
    public static SaveManager saveManagerInstance;
    private void Awake()
    {
        LoadState(() => { });
        if (saveManagerInstance != null)
        {
            Destroy(this);
        }
        else
        {
            saveManagerInstance = this;
            DontDestroyOnLoad(this);
        }
        //Instance = this;
        Debug.Log("--------LOAD STATE DATA----------------");
        // Debug.Log(SaveManager.Instance.SavedData.CurrentLevelNumber);
        // Debug.Log(SaveManager.Instance.SavedData.Coins);
        // Debug.Log(SaveManager.Instance.SavedData.currentHeadIndex);
        // Debug.Log(SaveManager.Instance.SavedData.OpenHeadSkin[0]);
        // Debug.Log(SaveManager.Instance.SavedData.OpenHeadSkin[7]);
        Debug.Log("--------STATE DATA LOADED----------------");
    }

    private void Start()
    {
        //Analytics

    }

    public static SavedData CurrentState { get; private set; }
    private void LoadState(Action onLoadCompleted)
    {
        if(Application.isEditor)
        {
            return;
        }
        YaSDK.GetData<SavedData>(data =>
        {
            Debug.Log("Current State 1");
            Debug.Log(CurrentState);
            Debug.Log("Data");
            Debug.Log(data);
            Debug.Log("Data maxTimeScale");
            if (data.maxTimeScale == 0)
            {
                CurrentState = new SavedData();
                CurrentState.maxTimeScale = 1.5f;
                CurrentState.damageStart = 5;
                CurrentState.atackSpeedStart = 1;
                CurrentState.critChanceStart = 0.01f;
                CurrentState.critDamageStart = 1.2f;
                CurrentState.rangeStart = 9.5f;
                CurrentState.damageDistanceStart = 0;
                CurrentState.multishotChanceStart = 0;
                CurrentState.multishotTargetsStart = 2;
                CurrentState.HpStart = 5;
                CurrentState.hpRegenStart = 0;
                CurrentState.moneyCoefStart = 1;
                CurrentState.moneyPerWaveStart = 0;
            }
            else
            {
                CurrentState = data;
            }
            Debug.Log("Current State 2");
            Debug.Log(CurrentState);
            Debug.Log("Load Complete, maxTimeScale: " + CurrentState.maxTimeScale);
            GameStats.instance.setStatsFromSave();
            onLoadCompleted();
        });
        Debug.Log("Load Complete, maxTimeScale: " + CurrentState.maxTimeScale);

    }

    public static void SaveState()
    {
        if (Application.isEditor) return;
            Debug.Log("SaveManager: request to save state has been sent");


        // string jsonString = JsonUtility.ToJson(PlayerInfo);
        YaSDK.SetData(CurrentState);
        // YaSDK.SetToLeaderboard(PlayerInfo.score);
    }
}

