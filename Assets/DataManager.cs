using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Playerdata
{
    public string name;
    public int level = 1;
    public int coin = 100;
    public int item = -1;
}


public class DataManager : MonoBehaviour
{

    //싱글톤
    public static DataManager instance;

    public string path;
    public int nowSlot;

    public Playerdata nowPlayer = new Playerdata();

    private void Awake()
    {
        #region 싱글톤
        if (null == instance)
        {
            //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
            instance = this;

            //씬 전환이 되더라도 파괴되지 않게 한다.
            //gameObject만으로도 이 스크립트가 컴포넌트로서 붙어있는 Hierarchy상의 게임오브젝트라는 뜻이지만, 
            //나는 헷갈림 방지를 위해 this를 붙여주기도 한다.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //만약 씬 이동이 되었는데 그 씬에도 Hierarchy에 GameMgr이 존재할 수도 있다.
            //그럴 경우엔 이전 씬에서 사용하던 인스턴스를 계속 사용해주는 경우가 많은 것 같다.
            //그래서 이미 전역변수인 instance에 인스턴스가 존재한다면 자신(새로운 씬의 GameMgr)을 삭제해준다.
            Destroy(this.gameObject);
        }
        #endregion
    
        path = Application.persistentDataPath + "/save";
    }






    // Start is called before the first frame update
    void Start()
    {
        

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path + nowSlot.ToString(), data);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + nowSlot.ToString());
        nowPlayer = JsonUtility.FromJson<Playerdata>(data);
    }

    public void DataClear()
    {
        nowSlot = -1; //슬롯 번호가 점점 늘어날텐데 -로는 안가니까 초기화를 -1로 해준다.
        nowPlayer = new Playerdata();
    }
}
