using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobscriptEasy : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public SpriteRenderer mySpriteRenderer;
    public Sprite dedSprite;
    public float flapStrenght;
    public LogicScript logic;
    public bool blobIsAlive = true;
    public AudioSource meowded;
    public int count = 0;
    public GameObject hintText;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        animator = GetComponent<Animator>();
        logic.highscoreText.text = PlayerPrefs.GetInt("highscore").ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) == true && blobIsAlive == true)
        {
            myRigidbody.velocity = Vector2.up * flapStrenght;
            animator.SetTrigger("Fly");
            count++;
        }
        if (count == 1)
        {
            myRigidbody.gravityScale = 1;
            hintText.SetActive(false);
        }

        if (transform.position.y > 9 | transform.position.y < -9 && blobIsAlive == true)
        {
            ded();

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (blobIsAlive == true)
        {
            ded();
        }
    }

    public void ded()
    {
        logic.gameOver();
        blobIsAlive = false;
        mySpriteRenderer.sprite = dedSprite;
        meowded.Play();

        logic.highscore();

    }

}