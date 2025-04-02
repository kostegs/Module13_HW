using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _countOfCoins;

    public int CountOfCoins => _countOfCoins;

    public void AddCoin(int count)
    {
        if (count > 0)
            _countOfCoins += count;
    }
}
