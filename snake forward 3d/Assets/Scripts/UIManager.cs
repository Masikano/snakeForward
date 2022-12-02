using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject _startBtn;
    public GameObject _stopBtn;
    public GameObject _hardMode;
    public Toggle hardModeToggle;
    public Text coinsCounterValueText;
    //public Text scoreValue;


    private void Awake()
    {
        instance = this;
        //_startBtn = transform.Find("StartBtn").gameObject;
        //_stopBtn = transform.Find("StopBtn").gameObject;
        //_hardMode = transform.Find("HardMode").gameObject;
        hardModeToggle = _hardMode.GetComponent<Toggle>();
    }

    public void StartGame()
    {
        StartBtnDisable();
        StopBtnEnable();
        EasyModToggleDisable();
        //scoreValue.text = "0";
        ScoreCoinsCounter.instance.ResetScore();
        ScoreCoinsCounter.instance.ResetCoins();
    }
    public void EndGame()
    {
        StopBtnDisable();
        EasyModToggleEnable();
        StartBtnEnable();
        ScoreCoinsCounter.instance.deltaScore = 0f;
    }
    public void StartBtnEnable()
    {
        if(_startBtn != null) { _startBtn.SetActive(true); }
        
    }
    public void StartBtnDisable()
    {
        if (_startBtn != null) { _startBtn.SetActive(false); }

    }
    public void StopBtnEnable()
    {
        if (_stopBtn != null) { _stopBtn.SetActive(true); }

    }
    public void StopBtnDisable()
    {
        if (_stopBtn != null) { _stopBtn.SetActive(false); }

    }

    public void EasyModToggleEnable()
    {
        _hardMode.SetActive(true);
    }
    public void EasyModToggleDisable()
    {
        _hardMode.SetActive(false);
    }
}
