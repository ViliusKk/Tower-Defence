using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player instance;
    public TextMeshProUGUI moneyText;
    public int startingMoney = 100;

    private void Awake()
    {
        if (instance == null) instance = this;
        else enabled = false;
    }
    public int Money
    {
        get { return money; }
        set
        {
            money = value;
            moneyText.text = money.ToString();
        }
    }
    private int money;
    void Start()
    {
        Money = startingMoney;
    }
}
