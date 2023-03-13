using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
   public static CoinManager instance;
	void Awake () {
        if (instance == null)
            instance = this;
	}

    public Text AllCoinsUI;
    public Text CoinsUI;
    public int coin;
    public int Allcoins;
    public int multiplayer;

    void Start()
    {
      Allcoins = PlayerPrefs.GetInt("Coins");
      AllCoinsUI.text = Allcoins.ToString();
    }

    public void SetCoin(int count)
    {
      coin = count;
    }

    public void Multiplayer(int setmultiplayer)
    {
      if(setmultiplayer > multiplayer)
      {
        multiplayer = setmultiplayer;
        coin = coin * multiplayer;
        Allcoins += coin;
        PlayerPrefs.SetInt("Coins", Allcoins);
        CoinsUI.text = "+ " + coin.ToString();
      }
    }
}
