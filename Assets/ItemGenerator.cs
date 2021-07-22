using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
        //carPrefabを入れる
        public GameObject carPrefab;
        //coinPrefabを入れる
        public GameObject coinPrefab;
        //cornPrefabを入れる
        public GameObject conePrefab;
        //スタート地点
        private int startPos = 80;
        //ゴール地点
        private int goalPos = 360;
        //アイテムを出すx方向の範囲
        private float posRange = 3.4f;
        //UnityChanController
        private GameObject unitychan;
        private int item_z= 45;//アイテム生成相対位置

        //Item list
        public List<GameObject> coneList = new List<GameObject>();
        public List<GameObject> coinList = new List<GameObject>();
        public List<GameObject> carList = new List<GameObject>();
        int counter=0;


        // Use this for initialization
        void Start ()
        {
            //unitychan object
            unitychan = GameObject.Find("unitychan");
        }
        //-------
        // Update is called once per frame
        void Update ()
        {
          Vector3 pos;

          pos = unitychan.transform.position;
          Debug.Log(pos.z);
          // object生成
          Generator();

          // delete object オブジェクトが削除されていることが分かり易いように、オブジェクトがunitychanの背後に回ったら即削除
          for (int i = 0; i < coneList.Count; i++)
          {
              if( coneList[i] != null)
              {
                  if( pos.z > coneList[i].transform.position.z )
                  {
                      Destroy(coneList[i]);
                  }
              }
          }
          for (int i = 0; i < coinList.Count; i++)
          {
              if( coinList[i] != null)
              {
                  if( pos.z > coinList[i].transform.position.z )
                  {
                      Destroy(coinList[i]);
                  }
              }
          }
          for (int i = 0; i < carList.Count; i++)
          {
              if( carList[i] != null)
              {
                  if( pos.z > carList[i].transform.position.z )
                  {
                      Destroy(carList[i]);
                  }
              }
          }
      }

      //---------------
      void Generator()
      {
          Vector3 pos;
          pos = unitychan.transform.position;
          //Debug.Log(pos.z);
          //Debug.Log(counter+"=counter");
          // object生成

          if( counter == 17 && pos.z < 290){　//　17frame毎にアイテム生成。ゴール手前では生成しない。
              int num = Random.Range (1, 11);
              //Debug.Log(num);
              if (num <= 2) // coan
              {
                  for (float j = -1; j <= 1; j += 0.4f)
                  {
                          GameObject cone = Instantiate (conePrefab);
                          coneList.Add(cone);
                          cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, pos.z+item_z);
                  }
              }
              else
              {
                  for (int j = -1; j <= 1; j++)
                  {
                  //アイテムの種類を決める
                  int item = Random.Range (1, 11);
                  //
                  if (1 <= item && item <= 4)
                  {
                          //コインを生成
                          GameObject coin = Instantiate (coinPrefab);
                          coinList.Add(coin);
                          coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, pos.z+item_z);


                  }
                  else if (5 <= item && item <= 6)
                  {
                          //車を生成
                          GameObject car = Instantiate (carPrefab);
                          carList.Add(car);
                          car.transform.position = new Vector3 (posRange * j, car.transform.position.y, pos.z+item_z);

                  }
              }
          }
              counter = 0;
          } else {
              counter++;
          }
      }
}
