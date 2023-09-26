using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    private Vector3 Player_pos; //�v���C���[�̃|�W�V����
    private float x; //x������Imput�̒l
    private float z; //z������Input�̒l
    private Rigidbody rigd;


    void Start()
    {
        Player_pos = GetComponent<Transform>().position; //�ŏ��̎��_�ł̃v���C���[�̃|�W�V�������擾
        rigd = GetComponent<Rigidbody>(); //�v���C���[��Rigidbody���擾
    }
    private void Update()
    {

        x = Input.GetAxis("Horizontal"); //x������Input�̒l���擾
        z = Input.GetAxis("Vertical"); //z������Input�̒l���擾

        rigd.velocity = new Vector3(x * _speed, 0, z * _speed); //�v���C���[��Rigidbody�ɑ΂���Input��speed���|�����l�ōX�V���ړ�

        Vector3 diff = transform.position - Player_pos; //�v���C���[���ǂ̕����ɐi��ł��邩���킩��悤�ɁA�����ʒu�ƌ��ݒn�̍��W�������擾

        if (diff.magnitude > 0.01f) //�x�N�g���̒�����0.01f���傫���ꍇ�Ƀv���C���[�̌�����ς��鏈��������(0�ł͓���Ȃ��̂Łj
        {
            transform.rotation = Quaternion.LookRotation(diff);  //�x�N�g���̏���Quaternion.LookRotation�Ɉ����n����]�ʂ��擾���v���C���[����]������
        }

        Player_pos = transform.position; //�v���C���[�̈ʒu���X�V
        /*  if (Input.anyKey)
          {
              var velocity = Vector3.zero;
              if (Input.GetKey(KeyCode.W))
              {
                  velocity.z = _speed;
              }
              if (Input.GetKey(KeyCode.A))
              {
                  velocity.x = -_speed;
              }
              if (Input.GetKey(KeyCode.S))
              {
                  velocity.z = -_speed;
              }
              if (Input.GetKey(KeyCode.D))
              {
                  velocity.x = _speed;
              }
              if (velocity.x != 0 || velocity.z != 0)
              {
                  transform.position += transform.rotation * velocity;
              }
          }

          if (diff.magnitude > 0.01f)
          {
              transform.rotation = Quaternion.LookRotation(diff);
          }*/
    }
}