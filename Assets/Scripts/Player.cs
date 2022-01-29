using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpPower;

    public int hp;

    private bool isJump;
    private bool isOver;
    public bool isStageAllClear;

    private Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Debug.Log("Hello, Unity!");

        int hp = 100;
        float DPS = 4.6f;
        string name = "¿Ã∏ß";
        bool isMove = false;

        Debug.Log("HP : " + hp);
        Debug.Log("DPS : " + DPS);
        Debug.Log("NAME : " + name);
        Debug.Log("ISMOVE : " + isMove);

        for (int i = 0; i < 10; i++)
        {
            hp--;
            Debug.Log("HP : " + hp);
        }

        if(DPS >= 3f)
        {
            name = "ABC";
            Debug.Log("NAME : " + name);
        }
        else if(!isMove)
        {
            isMove = true;
            Debug.Log("ISMOVE : " + isMove);
        }
    }

    void Update()
    {
        if (!isOver)
        {
            if(isStageAllClear)
            {
                transform.position = Vector3.zero;

                return;
            }
            Move();
            Jump();
        }
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 moveVec;

        moveVec = new Vector3(h, 0f, v).normalized * moveSpeed * Time.deltaTime;

        transform.position += moveVec;
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            isJump = true;

            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    private void GameOver()
    {
        isOver = true;
        hp = 0;

        SceneManager.LoadScene(1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Floor"))
        {
            isJump = false;
        }
        else if(collision.collider.CompareTag("Wall"))
        {
            RemoveHealth();
        }
    }

    public void RemoveHealth()
    {
        if (hp - 1 <= 0)
        {
            GameOver();
        }
        else
        {
            hp--;
        }
    }
}
