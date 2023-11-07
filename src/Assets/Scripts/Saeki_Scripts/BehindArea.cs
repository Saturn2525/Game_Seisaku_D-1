using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BehindArea : MonoBehaviour
{
    public GameObject textObject;
    public Image image;
    private bool playerInsideArea = false;

    public bool behindEnter;
    // Start is called before the first frame update
    void Start()
    {
        textObject.SetActive(false);
        behindEnter = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Z�L�[�������ꂽ�Ƃ�
        if (Input.GetKeyDown(KeyCode.Z) && playerInsideArea)
        {
            behindEnter = true;
            // ImageUI��\������
            image.gameObject.SetActive(true);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           // behindEnter = true; Debug.Log(behindEnter);
            playerInsideArea = true;
            textObject.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("1");
            image.gameObject.SetActive(false);
            playerInsideArea = false;
            textObject.SetActive(false);
            behindEnter = false;
        }
    }
}