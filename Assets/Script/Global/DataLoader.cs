using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class DataLoader : MonoBehaviour
{
    public static DataLoader instance;
    [SerializeField] private TextAsset _cardCSVData;
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
    private List<Dictionary<string, object>> _cardData = new List<Dictionary<string, object>>();
    private void LoadData()
    {
        _cardData = CSVReader.Read(_cardCSVData);
        Load();


    }


    public void Load() //csv �о���� �� Ȯ���ϱ� ���� ���� ����
    {
        for (int i = 0; i < _cardData.Count; ++i)
        {
            CardID id = (CardID) int.Parse(_cardData[i]["ID"].ToString());
            switch (id)
            {
                case CardID.�˹�:
                    Database.CardDataDict.Add(id,new �˹�(CardID.�˹�));
                    break;
                case CardID.���¿��:
                    Database.CardDataDict.Add(id, new �˹�(CardID.�˹�));
                    break;
                case CardID.����:
                    Database.CardDataDict.Add(id, new �˹�(CardID.�˹�));
                    break;
                case CardID.Ÿ��:
                    Database.CardDataDict.Add(id, new �˹�(CardID.�˹�));
                    break;
                case CardID.ȭ���罽:
                    Database.CardDataDict.Add(id, new �˹�(CardID.�˹�));
                    break;
                case CardID.���:
                    Database.CardDataDict.Add(id, new �˹�(CardID.�˹�));
                    break;
            }
            Debug.Log(id);
            Database.CardDataDict[id].SetCard(_cardData[i]);
        }
    }


}

