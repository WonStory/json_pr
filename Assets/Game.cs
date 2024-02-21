using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



// 포지션도 받아와서 저장하면 똑같다. 데이터는 서버에 저장하는게 낫다(로컬보다)

public class Game : MonoBehaviour
{
    public TextMeshProUGUI name2;
    public TextMeshProUGUI level;
    public TextMeshProUGUI coin;

    public GameObject[] item; 

    // Start is called before the first frame update
    void Start()
    {
        name2.text += DataManager.instance.nowPlayer.name;
        level.text += DataManager.instance.nowPlayer.level.ToString();
        coin.text += DataManager.instance.nowPlayer.coin.ToString();
        ItemSetting(DataManager.instance.nowPlayer.item);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CoinUp()
    {
        DataManager.instance.nowPlayer.coin +=100;
        coin.text = "coin :" + DataManager.instance.nowPlayer.coin.ToString();
    }

    public void LevelUp()
    {
        DataManager.instance.nowPlayer.level++;
        level.text = "level :" + DataManager.instance.nowPlayer.level.ToString();
    }

    public void Save()
    {
        DataManager.instance.SaveData();
    }


    public void ItemSetting(int number)
    {
        for (int i = 0; i < item.Length; i++)
        {
            if (number == i)
            {
                item[i].SetActive(true);
                DataManager.instance.nowPlayer.item = number;
            }
            else
            {
                item[i].SetActive(false);
            }
        }
    }

}