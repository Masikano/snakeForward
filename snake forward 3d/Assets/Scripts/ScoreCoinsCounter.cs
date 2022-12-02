using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCoinsCounter : MonoBehaviour
{
    private float _score;
    private int _coins;
    public float deltaScore;
    private float _hardPlusSpeed;
    private float _plusSpeed;
    public Text scoreValueText;
    public Text coinCounterValueText;

    public static ScoreCoinsCounter instance;
    private void Awake()
    {
        instance = this;
        //textScore = UIManager.instance.scoreValue;
    }
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        deltaScore = 0;
        _hardPlusSpeed = RoadGenerator.instance.hardPlusSpeed;
        _plusSpeed = RoadGenerator.instance.plusSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(deltaScore != 0)
        {
            _score += Time.deltaTime * deltaScore * 10000;
            scoreValueText.text = Mathf.Round(_score).ToString();
        }
    }
    public void SetDeltaScore()
    {

        if (UIManager.instance.hardModeToggle.isOn)
        {
            deltaScore = _hardPlusSpeed;
        }
        else
        {
            deltaScore = _plusSpeed;
        }
        
    }
    public void ResetScore()
    {
        _score = 0;
    }

    public void AddCoin()
    {
        _coins++;
        coinCounterValueText.text = _coins.ToString();
    }

    public void ResetCoins()
    {
        _coins = 0;
        coinCounterValueText.text = "0";
    }
}
