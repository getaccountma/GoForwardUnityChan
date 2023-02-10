using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    //キューブのPrefab
    public GameObject cubePrefab;

    //時間計測用の変数
    private float delta = 0;

    //キューブの生成間隔
    private float span = 1.0f;//最初に降ってくるブロックの秒数だけ。あとはランダム生成したブロックによって、数値が変わる

    //キューブの生成位置：X座標
    private float genPosX = 12;

    //キューブの生成位置オフセット
    private float offsetY = 0.3f; //???生成位置オフセット（Y）の意味：Cube作る時どの高さで出現させるか？
    //キューブの縦方向の間隔
    private float spaceY = 6.9f;

    //キューブの生成位置オフセット
    private float offsetX = 0.5f;//???Xのoffset：Spanに代入。
    //キューブの横方向の間隔
    private float spaceX = 0.4f;//???横方向の間隔

    //キューブの生成個数の上限
    private int maxBlockNum = 4;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;

        //span秒以上の時間が経過したかを調べる
        if (this.delta > this.span)
        {
            this.delta = 0;
            //生成するキューブ数をランダムに決める
            int n = Random.Range(1, maxBlockNum + 1);

            //指定した数だけキューブを生成する
            for (int i = 0; i < n; i++)
            {
                //キューブの生成
                GameObject go = Instantiate(cubePrefab);
                go.transform.position = new Vector2(this.genPosX, this.offsetY + i * this.spaceY);
            }
            //次のキューブまでの生成時間を決める（ブロック生成した数によって、生成時間が変わる）
            this.span = this.offsetX + this.spaceX * n;
        }
    }
   
}
