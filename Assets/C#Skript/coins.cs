using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public Text coinText;

    private int coins = 0;

    void Awake()
    {
        instance = this;
    }

    public void AddCoin()
    {
        coins++;
        coinText.text = "Coins: " + coins.ToString();
    }

    
    public bool HasCoins(int amount)
    {
        return coins >= amount;
    }

    public void SpendCoins(int amount)
    {
        coins -= amount;
        coinText.text = "Coins: " + coins.ToString();
    }
}
