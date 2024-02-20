using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using System;

public class select : MonoBehaviour
{
    public GameObject creat;
    public TextMeshProUGUI[] slotText;
    public TextMeshProUGUI newPlayerName;
    bool[] savefile = new bool[3]; //배열이기 때문에 갯수를 정확히 적어줌.




    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            if (File.Exists(DataManager.instance.path + $"{i}"))  //파일이 존재하는지 불함수로 나올것임
            {
                savefile[i] = true; //그 슬롯에 불값을 넣어놓음
                DataManager.instance.nowSlot = i;
                DataManager.instance.LoadData();
                slotText[i].text = DataManager.instance.nowPlayer.name  ; //불러오기만 하고 데이터 클리어를 안만들어놈
                DataManager.instance.DataClear();
            
            }
            else
            {
                slotText[i].text = "clear";//확인해봤을 때 아무것도 없으면 비어있음으로 표기되게끔
            }

        }
        DataManager.instance.DataClear(); // 여러번 초기화할 필요없이 (어차피 위의 for문은 슬롯확인을 위한 반복용이기 때문이다.) for문 밖으로 빼놈
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //슬롯이 3개인데 어떻게 알맞게 불러올까? => 파일네임을 슬롯마다 다 다르게
    public void Slot(int number)
    {
        DataManager.instance.nowSlot = number;
        //1. 저장데이터가 없을때
        //2. 저장데이터가 있을떄 =>불러오기해서 게임씬으로 넘어가야댐.
        if (savefile[number])
        {
            DataManager.instance.LoadData(); //세이브파일이 있으면 로드파일
            GoGame(); //공용공간에 놓으면 else에서 크리트하자마자 고게임해버림
        }
        else
        {
            Creat(); //플레이어 이름을 받아와야된다.
        }
        
/*
        DataManager.instance.LoadData();

        DataManager.instance.nowPlayer.name = newPlayerName.text; =>이것들을 위의 슬랏과 고게임에 어떻게 배분했는지 이해하기
*/
        
    }





    public void Creat()
    {
        creat.gameObject.SetActive(true); //creat가 활성화되며 이미지가 떠오르게하는 장치
    }

    public void GoGame()
    { //여기에다가 이름 덮어쓰기를 넣으면 이름을 계속 덮어씀 => 제대로 분리를 해줘야댐
        if (!savefile[DataManager.instance.nowSlot])
            {
                DataManager.instance.nowPlayer.name = newPlayerName.text + "\n" +DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"); //현재 슬롯에 이름이 없다면 덧씌워라
                DataManager.instance.SaveData();
            }
        SceneManager.LoadScene(1);
    }






}
