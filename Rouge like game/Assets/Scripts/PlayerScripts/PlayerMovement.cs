using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;

    public float moveSpeed = 5f; //публичная переменная для задания скорости перса

    public Rigidbody2D rb;  //Переменная для привязки физики персонажа
    public Animator animator;

    Vector2 movement;

    private void Start()
    {
        moveSpeed = playerData.moveSpeed;
    }
    void Update()
    {
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    public void UpdateData()
    {
        moveSpeed = playerData.moveSpeed;
    }
    void FixedUpdate()  //используется для физики, чаще обновляет кадры
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
