using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPoolManager : MonoBehaviour
{
    public static CoinPoolManager Instance;

    public ObjectPool coinPool;
    public List<Transform> coinSpawnPoints;
    private List<GameObject> activeCoins = new List<GameObject>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SpawnAllCoins();
    }

    void SpawnAllCoins()
    { 
       foreach (Transform spawn in coinSpawnPoints)
       {
           GameObject coin = coinPool.GetObject();
           coin.transform.position = spawn.position;
           activeCoins.Add(coin);
       }
    }

    public void CollectCoin(GameObject coin)
    {
        coinPool.ReturnObject(coin);
    }

    public void ResetCoins()
    {
        foreach (GameObject coin in activeCoins)
        {
            coin.SetActive(true);
        }
    }
}
