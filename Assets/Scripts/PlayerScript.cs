using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public InputAction moveAction;
    private bool FacingRight = true;

    [Header("Player Movement Settings")]
    public Animator animator;

    void Start()
    {
        moveAction.Enable();
        animator = GetComponent<Animator>();
    }
     
    void Update()
    {
        // ћен€ем положение игрока в соответствии с нажатой клавишой
        Vector2 move = moveAction.ReadValue<Vector2>();
        Vector2 position = (Vector2)transform.position + move * 0.05f;
        transform.position = position;

        // –еверсируем модельку персонажа в зависимости от направлени€
        if(move.x < 0 && FacingRight)
        {
            Flip();
        }
        else if (move.x > 0 && !FacingRight)
        {
            Flip();
        }

        // ѕолучаем значени€ ввода дл€ горизонтального и вертикального движени€
        float moveInputX = Input.GetAxis("Horizontal");
        float moveInputY = Input.GetAxis("Vertical");

        // ѕровер€ем, движетс€ ли персонаж
        bool isRunning = Mathf.Abs(moveInputX) > 0.1f || Mathf.Abs(moveInputY) > 0.1f;

        // ”станавливаем параметр isRunning в Animator
        animator.SetBool("isRunning", isRunning);

    }

    private void Flip()
    {
        FacingRight = !FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
