using UnityEngine;

public class CubeController : MonoBehaviour
{
    //�L���[�u�̈ړ����x
    private float speed = -12;

    //���ňʒu
    private float deadLine = -10;


 

    // Start is called before the first frame update
    void Start()
    { 

    }        

    // Update is called once per frame
    void Update()
    {
 
        //�L���[�u���ړ�������
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //��ʊO�ɏo����j������
        if (transform.position.x < this.deadLine) 
        {
            Destroy(gameObject);
        }
    }

    //�Փ˔���+����炷
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CubeTag"|| collision.gameObject.tag == "GroundTag") 
        {
            GetComponent<AudioSource>().Play();

        }
        /*
        if (collision.gameObject.name == "CubePrefab(Clone)" || collision.gameObject.name == "ground")//Tag���g�p�����ق����悢�B�I�u�W�F�N�g����ύX���ꂽ���ɃG���[�ɂȂ邽�߁B
        {
            GetComponent<AudioSource>().Play();

        }
        */

    }


}
