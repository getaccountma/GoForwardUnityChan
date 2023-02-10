using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    //�L���[�u��Prefab
    public GameObject cubePrefab;

    //���Ԍv���p�̕ϐ�
    private float delta = 0;

    //�L���[�u�̐����Ԋu
    private float span = 1.0f;//�ŏ��ɍ~���Ă���u���b�N�̕b�������B���Ƃ̓����_�����������u���b�N�ɂ���āA���l���ς��

    //�L���[�u�̐����ʒu�FX���W
    private float genPosX = 12;

    //�L���[�u�̐����ʒu�I�t�Z�b�g
    private float offsetY = 0.3f; //???�����ʒu�I�t�Z�b�g�iY�j�̈Ӗ��FCube��鎞�ǂ̍����ŏo�������邩�H
    //�L���[�u�̏c�����̊Ԋu
    private float spaceY = 6.9f;

    //�L���[�u�̐����ʒu�I�t�Z�b�g
    private float offsetX = 0.5f;//???X��offset�FSpan�ɑ���B
    //�L���[�u�̉������̊Ԋu
    private float spaceX = 0.4f;//???�������̊Ԋu

    //�L���[�u�̐������̏��
    private int maxBlockNum = 4;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;

        //span�b�ȏ�̎��Ԃ��o�߂������𒲂ׂ�
        if (this.delta > this.span)
        {
            this.delta = 0;
            //��������L���[�u���������_���Ɍ��߂�
            int n = Random.Range(1, maxBlockNum + 1);

            //�w�肵���������L���[�u�𐶐�����
            for (int i = 0; i < n; i++)
            {
                //�L���[�u�̐���
                GameObject go = Instantiate(cubePrefab);
                go.transform.position = new Vector2(this.genPosX, this.offsetY + i * this.spaceY);
            }
            //���̃L���[�u�܂ł̐������Ԃ����߂�i�u���b�N�����������ɂ���āA�������Ԃ��ς��j
            this.span = this.offsetX + this.spaceX * n;
        }
    }
   
}
