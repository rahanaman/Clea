using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugaaaaa : MonoBehaviour
{
    int[] data = new int[] {2,3,5,32,1001,111};
    private List<Dictionary<string, object>> _cardData = new List<Dictionary<string, object>>();
    string str = "피해를{1} 입습니다. 피해를 {2} 입 {0}힙니{3}다.";
    [SerializeField] GameObject Card;
    [SerializeField] Transform can;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void a()
    {
        for (int i = 0; i < _cardData.Count; ++i)
        {
            Debug.Log(_cardData[i]["ID"].ToString());
            Debug.Log(_cardData[i]["Name"].ToString());
            Debug.Log(_cardData[i]["Cost"].ToString());
            Debug.Log(_cardData[i]["등급"].ToString());
            Debug.Log(_cardData[i]["분류"].ToString());
            Debug.Log(_cardData[i]["대상"].ToString());
            Debug.Log(_cardData[i]["Description"].ToString());
            Debug.Log(_cardData[i]["Data"].ToString());
        }

    }
}
