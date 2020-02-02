using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [Header("GameSettings")]
    [SerializeField] private GameSettings[] gameSettings;
    [Space]

    public float moveSpeed;
    public float jumpForce;
    public bool isJumping;
    public float speed;

    public BoxCollider2D col;
    const float ySize = 6.7f;
    const float newOffset = 0.7f;

    public int curRepair;
    public int maxRepair = 30;
    bool repair;
    bool damaged;
    public int repairValue = 1;
    public int damageValue = 1;

    [Header("Skin config")]
    [SerializeField] private GameObject[] skins;

    public Transform GateOut;

    public Rigidbody2D rb;
    private Animator anim;

    public ScoreScript scoreScript;

    private int currentSetting;
    #endregion
    #region Mono

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        currentSetting = 0;
        //ChangePlayer();

        //Invoke("Machetazo", 3); 

        curRepair = 0;

    }
    
    private void Machetazo()
    {
        if (curRepair >= 10)
        {
            ChangePlayer();
        }
    }
    
    private void Update()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        //Machetazo();
    }

    #endregion

    private void FixedUpdate()
    {
        Jump();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            isJumping = true;

            anim.SetTrigger("jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;

            rb.velocity = Vector2.zero;
        }
        /*
        if(other.gameObject.CompareTag("PortalIda"))
        {
            rb.position = GateOut.position;
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            /*
            col.size = new Vector2(col.size.x, ySize);
            col.offset = new Vector2(col.offset.x, newOffset);
            */
            Repair(repairValue);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Damage(damageValue);
        }
    }

    public void Repair(int rpr)
    {
        curRepair += rpr;
        repair = true;

        if(gameSettings[currentSetting].pickUpsAmount == curRepair)
        {
            ChangePlayer();
        }
    }

    public void Damage(int dmg)
    {
        curRepair -= dmg;
        damaged = true;
    }

    public void ChangePlayer()
    {
        /* 
        if (skins.Length < currentSetting)
            return;
        */
        for (int i = 0; i < skins.Length; i++)
        {
            skins[i].SetActive(false);
        }

        skins[gameSettings[currentSetting].skinId].SetActive(true);
        anim = skins[gameSettings[currentSetting].skinId].GetComponent<Animator>();

        currentSetting++;
    }

}

[System.Serializable]
public class GameSettings
{
    [Tooltip("Cantidad de monedas para reparar")]
    public int pickUpsAmount;


    [Tooltip("Numero identificador del skin")]
    [Range(0,2)]
    public int skinId;
}

