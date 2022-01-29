using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text playerHpText;
    public Text currentStageText;

    public GameObject[] stages;
    private int currentStage;
    private int currentStage_Text;

    public Transform playerStartTransform;

    public GameObject StageAllClearGroup;

    void LateUpdate()
    {
        currentStage_Text = currentStage + 1;

        playerHpText.text = "HP : " + player.hp;
        currentStageText.text = "STAGE : " + currentStage_Text;
    }

    public void ClickButton1()
    {
        Debug.Log("버튼이 눌림");
    }

    public void Finish()
    {
        player.transform.position = playerStartTransform.position;

        stages[currentStage].SetActive(false);

        currentStage++;

        if (currentStage >= stages.Length)
        {
            StageAllClear();

            return;
        }

        stages[currentStage].SetActive(true);
    }

    private void StageAllClear()
    {
        player.isStageAllClear = true;
        StageAllClearGroup.SetActive(true);
    }

    public void Retry()
    {
        player.isStageAllClear = false;
        player.transform.position = playerStartTransform.position;
        StageAllClearGroup.SetActive(false);
        stages[0].SetActive(true);
        currentStage = 0;
    }
}
