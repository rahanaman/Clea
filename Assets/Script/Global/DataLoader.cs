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


    public void Load() //csv 읽어오는 거 확인하기 위해 만든 더미
    {
        for (int i = 0; i < _cardData.Count; ++i)
        {
            CardID id = (CardID) int.Parse(_cardData[i]["ID"].ToString());
            switch (id)
            {
                case CardID.검무:
                    Database.CardDataDict.Add(id,new 검무(CardID.검무));
                    break;
                case CardID.불태우기:
                    Database.CardDataDict.Add(id, new 검무(CardID.검무));
                    break;
                case CardID.무모:
                    Database.CardDataDict.Add(id, new 검무(CardID.검무));
                    break;
                case CardID.타격:
                    Database.CardDataDict.Add(id, new 검무(CardID.검무));
                    break;
                case CardID.화염사슬:
                    Database.CardDataDict.Add(id, new 검무(CardID.검무));
                    break;
                case CardID.찌르기:
                    Database.CardDataDict.Add(id, new 검무(CardID.검무));
                    break;
            }
            Debug.Log(id);
            Database.CardDataDict[id].SetCard(_cardData[i]);
        }
    }


}

