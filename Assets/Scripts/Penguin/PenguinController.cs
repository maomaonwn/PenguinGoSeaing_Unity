using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinController : MonoBehaviour
{
    #region 变量

    [SerializeField] private float speed = 2f;

    [Header("关系")]
    [SerializeField] private Animator animator = null;
    [SerializeField] private Rigidbody rigidBody = null;
    [SerializeField] SpriteRenderer spriteRenderer = null;

    private Vector3 _movement;

    #endregion

    #region 常量和静态

    private static readonly int WALK_PROPERTY = Animator.StringToHash("canWalk");

    #endregion


    #region 行为

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        // Vertical
        float inputY = 0;
        if (Input.GetKey(KeyCode.UpArrow))
            inputY = 1;
        else if (Input.GetKey(KeyCode.DownArrow))
            inputY = -1;

        // Horizontal
        float inputX = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            inputX = 1;
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            inputX = -1;
            spriteRenderer.flipX = true;
        }

        // Normalize
        _movement = new Vector3(inputX, 0, inputY).normalized;

        animator.SetBool(WALK_PROPERTY,
                         Mathf.Abs(_movement.sqrMagnitude) > Mathf.Epsilon);
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = _movement * speed;
    }
    #endregion
}
