using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text playerHpText;

    void LateUpdate()
    {
        playerHpText.text = "HP : " + player.hp;
    }

    public void ClickButton1()
    {
        Debug.Log("��ư�� ����");
    }

    public void Finish()
    {
        Debug.Log("��");
    }


}
