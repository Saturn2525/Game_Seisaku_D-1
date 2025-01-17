using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class TitleSceneScript : MonoBehaviour
{
    //===== 定義領域 =====
    private Animator anim;  //Animatorをanimという変数で定義する

    private bool Put = false;
    private float Interval;
    public float ChangeTime = 1.2f;

    GameObject Image;
    private InputAction _pressAnyKeyAction = new InputAction(type: InputActionType.PassThrough, binding: "*/<Button>", interactions: "Press");
   
    private void OnEnable() => _pressAnyKeyAction.Enable();
    private void OnDisable() => _pressAnyKeyAction.Disable();
    //===== 初期処理 =====
    void Start()
    {
        //変数animに、Animatorコンポーネントを設定する
        anim = gameObject.GetComponent<Animator>();
        Put = false;
        Interval = 0.0f;
        Image = GameObject.Find("TitleImage");

         }

    //===== 主処理 =====
    void Update()
    {
        if (_pressAnyKeyAction.triggered && !Put)
        {
            anim.SetBool("GetAnyKey", true);
            Put = true;
            Destroy(Image);
        }

        else if(Put)
        {
            Interval += Time.deltaTime;
        }

        if(Interval > ChangeTime)
        {
            SceneManager.LoadSceneAsync("SelectScene");
        }
    }
}
