using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //�A�j���[�V�������邽�߂̃R���|�[�l���g������
    Animator animator;

    //Unity�������ړ�������R���|�[�l���g������
    Rigidbody2D rigid2D;

    //�n�ʂ̈ʒu
    private float groundLevel = -3.0f;

    //�W�����v�̑��x�̌���
    private float dump = 0.8f;

    //�W�����v�̑��x
    float jumpVelocity = 20; //�����́uprivate�v�����ł��ǂ��H���Ȃ��ƁAprivate�����ɂȂ�B�Ȃ�ׂ������ق����ǂ��B20�̌��Ɂuf�v�����ł��ǂ��H�����̏ꍇ�͏ȗ��\

    //�Q�[���I�[�o�[�ɂȂ�ʒu
    private float deadLine = -9;

    // Start is called before the first frame update
    void Start()
    {
        //�A�j���[�^�̃R���|�[�l���g���擾����
        this.animator = GetComponent<Animator>();

        //Rigidbody 2D�̃R���|�[�l���g���擾����
        this.rigid2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //����A�j���[�V�������Đ����邽�߂ɁAAnimator�̃p�����[�^�𒲐߂���
        this.animator.SetFloat("Horizontal", 1);

        //���n���Ă��邩�ǂ����𒲂ׂ�
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        //�W�����v��Ԃ̂Ƃ��ɂ́A�{�����[�����O�ɂ���
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        //���n��ԂŃN���b�N���ꂽ�ꍇ
        if (Input.GetMouseButtonDown(0) && isGround) //GetMousebuttonDown�͂ǂ��Őݒ肳��Ă���H�@Input�N���X�ɑg�ݍ��܂�Ă���ݒ�B�O���N���b�N�A�P�E�N���b�N�A�Q�z�C�����N���b�N
        {
            //������̗͂�������
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);

        }

        //�N���b�N����߂��������ւ̑��x����������
        if (Input.GetMouseButton(0) == false) //Down�͉������u�Ԃ�True�ADown�������Ɖ����Ă���Ԃ͂�����True�ɂȂ�
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        //�f�b�h���C���𒴂����ꍇ�Q�[���I�[�o�[�ɂ���
        if (transform.position.x < this.deadLine)
        {
            //UIController��GameOver�֐����Ăяo���ĉ�ʏ�ɁuGame Over�v�ƕ\������
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            //���j�e�B������j������
            Destroy(gameObject);
        }

    }
}
