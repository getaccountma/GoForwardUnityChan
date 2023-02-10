using UnityEngine;

public class CubeController : MonoBehaviour
{
    //キューブの移動速度
    private float speed = -12;

    //消滅位置
    private float deadLine = -10;


 

    // Start is called before the first frame update
    void Start()
    { 

    }        

    // Update is called once per frame
    void Update()
    {
 
        //キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //画面外に出たら破棄する
        if (transform.position.x < this.deadLine) 
        {
            Destroy(gameObject);
        }
    }

    //衝突判定+音を鳴らす
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CubeTag"|| collision.gameObject.tag == "GroundTag") 
        {
            GetComponent<AudioSource>().Play();

        }
        /*
        if (collision.gameObject.name == "CubePrefab(Clone)" || collision.gameObject.name == "ground")//Tagを使用したほうがよい。オブジェクト名を変更された時にエラーになるため。
        {
            GetComponent<AudioSource>().Play();

        }
        */

    }


}
