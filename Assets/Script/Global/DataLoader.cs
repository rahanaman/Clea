using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    public static DataLoader instance;
    [SerializeField]private TextAsset _cardCSVData;
    [SerializeField] private CardView _cardCon;
    [SerializeField] private GameObject _enemy;
    private void Awake()
    {
        Singletone();
        LoadData();
    }
    private void Singletone()
    {        
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void LoadData()
    {
        LoadCardData();
    }

    private List<Dictionary<string, object>> _cardData = new List<Dictionary<string, object>>();
    private void LoadCardData()
    {
        _cardData = CSVReader.Read(_cardCSVData);
    }
    public void Load()
    {
        for (int i = 0; i < _cardData.Count; ++i)
        {
            CardID id = (CardID) int.Parse(_cardData[i]["ID"].ToString());
            switch (id)
            {
                case CardID.검무:
                    Database.CardDataDict[id] = new 검무(CardID.검무);
                    break;
            }
            Database.CardDataDict[id].SetCard(_cardData[i]);
        }
    }
}

