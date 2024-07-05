using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gm;

    public List<Dialogue> dialogues = new();

    public float movementSpeed = 5f;
    public float sprintMultiplier = 1.2f;

    public float speedBoosters = 0f;
    public float timeBoosters = 0f;

    public int currentDialogue = 0;

    public bool isMovable = true;
    public bool isResquing = false;

    private Rigidbody2D rb;

    public DialogueTrigger trigger;

    public Cat catTarget;

    public float resquingTimer = 0f;
    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        trigger = GetComponent<DialogueTrigger>();

        trigger.dialogue = dialogues[currentDialogue];
        currentDialogue += 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        float alpha = 0f;
        if (movement.x != 0 || movement.y != 0)
        {
            if (movement.y >= 0f)
            {
                alpha = Mathf.Acos(movement.x / Mathf.Sqrt(Mathf.Pow(movement.x, 2) + Mathf.Pow(movement.y, 2)));
            }
            else if (movement.y <= 0f)
            {
                alpha = 2*Mathf.PI - Mathf.Acos(movement.x / Mathf.Sqrt(Mathf.Pow(movement.x, 2) + Mathf.Pow(movement.y, 2)));
            }
        }
        if (isMovable && (movement.x != 0 || movement.y != 0))
        {
            rb.velocity = new Vector2(Mathf.Cos(alpha), Mathf.Sin(alpha)) * movementSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero; 
        }
        if (catTarget != null && isResquing)
        {
            if (catTarget.InputCombinationMatched() && !catTarget.isResqued)
            {
                resquingTimer += Time.deltaTime;
            } else
            {
                resquingTimer = 0;
            }
            if (resquingTimer >= 2f && !catTarget.isResqued)
            {
                catTarget.isResqued = true;
            }
        }
        if (!isMovable) {
            if (GetComponent<DialogueTrigger>().isStarted)
            {
                isMovable = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cat_resque"))
        {
            catTarget = collision.gameObject.GetComponent<Cat>();
            if (!catTarget.isResqued)
            {
                catTarget.com.gameObject.SetActive(true);
                isResquing = !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!true;
                if (!GetComponent<DialogueTrigger>().isStarted)
                {
                    GetComponent<DialogueTrigger>().TriggerDialogue();
                    isMovable = !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!false;
                }
            }
        }
        if (collision.gameObject.CompareTag("powerup"))
        {
            Powerup pu = collision.GetComponent<Powerup>();
            if (pu.type == "speed+") { movementSpeed += pu.value; pu.isPickable = false; }
            if (pu.type == "time+")
            {
                pu.isPickable = false;
                gm.gameTimer += pu.value;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cat_resque"))
        {
            isResquing = false;
            catTarget.com.gameObject.SetActive(false);
            catTarget = null;
        }
    }
}