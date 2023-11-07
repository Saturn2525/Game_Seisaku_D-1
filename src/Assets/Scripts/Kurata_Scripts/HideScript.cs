using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HideScript : MonoBehaviour
{
    public GameObject HidetextObject;
    private bool isPlayerInside = false;
    private Transform InSidePoint;
    private Transform OutSidePoint;
    private Transform nowPoint;
    bool HideMode = false;

    [SerializeField] float moveSpeed = 5.0f;

    private Playercontroller playerController;
    private BoxCollider boxCollider;

    private TextMeshProUGUI hidetextComponent;
    // Start is called before the first frame update
    void Start()
    {
        HidetextObject.SetActive(false);
        hidetextComponent = HidetextObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInside)
        {
            // �v���C���[���G���A���ɂ���ꍇ�̏���
            if (Input.GetKeyDown(KeyCode.Z))
            {
                HideMode = !HideMode;


                ChangeHide();
            }

        }
    }

    void ChangeHide()
    {
        if (HideMode)
        {
            if (playerController != null)
            {
                playerController.enabled = false;
            }
            if (boxCollider != null)
            {
                boxCollider.isTrigger = true;
            }
            hidetextComponent.text = "Exit!!!!";
            MoveToTarget(nowPoint.position, InSidePoint.position);

        }
        else
        {
            if (playerController != null)
            {
                playerController.enabled = true;
            }
            if (boxCollider != null)
            {
                boxCollider.isTrigger = false;
            }
            nowPoint.LookAt(OutSidePoint);
            hidetextComponent.text = "Hide!!!!";
            MoveToTarget(nowPoint.position, OutSidePoint.position);

        }
    }

    void MoveToTarget(Vector3 nowPosition, Vector3 targetPosition)//(���ݒn�A�ړI�n)
    {
        // �w��̈ʒu�Ɍ������Ĉړ�
        transform.position = Vector3.Lerp(nowPosition, targetPosition, moveSpeed);
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Hide")
        {
            Transform parentTransform = col.transform.parent;
            boxCollider = parentTransform.GetComponent<BoxCollider>();
            playerController = GetComponent<Playercontroller>();
            isPlayerInside = true;
            HidetextObject.SetActive(true);
            OutSidePoint = col.transform.GetChild(0);
            InSidePoint = col.transform.GetChild(1);
            nowPoint = this.transform;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        isPlayerInside = false;
        HidetextObject.SetActive(false);
    }
}