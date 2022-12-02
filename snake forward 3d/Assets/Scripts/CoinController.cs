using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    float rotationSpeed = 100;
    //private int _coinsCounterValue;
    //public Text coinsCounterValueText;

    public static CoinController instance;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //_coinsCounterValue = 0;
        //coinsCounterValueText = UIManager.instance.coinsCounterValueText;
        Debug.Log("coinControllerStart");
        //ротатион не влияет на лаги
        rotationSpeed += Random.Range(0, rotationSpeed / 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //ротатион не влияет на лаги

        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.gameObject.SetActive(false);
            //_coinsCounterValue++;
            //ScoreCoinsCounter.instance.coinCounterValueText.text = _coinsCounterValue.ToString();
            //coinsCounterValueText.text = _coinsCounterValue.ToString();
            ScoreCoinsCounter.instance.AddCoin();
            //Debug.Log("coinCollision");
        }
    }

    public void ResetCoinCounter()
    {
        //_coinsCounterValue = 0;
    }
}
