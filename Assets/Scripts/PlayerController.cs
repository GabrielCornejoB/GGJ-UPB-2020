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

    public GameObject repairAnim;

    [Header("Skin config")]
    [SerializeField] private GameObject[] skins;

    public Transform GateOut;

    public Rigidbody2D rb;
    private Animator anim;

    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioSource audioSource3;

    public AudioSource audioSalto;
    public AudioSource audio1a2;
    public AudioSource audio2a3;

    public Transform posicionPlayer;

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
        if (curRepair >= 0)
        {
            Run();
        }
        else
        {
            return;
        }
        //Machetazo();
    }

    #endregion


    void Run()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

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
            audioSalto.Play(0);

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
            Destroy(collision.gameObject);
        }
    }
    /*
    public void AnimacionExplosion() 
    {
        repairAnim.SetActive(true);
    }
    */
    public void Repair(int rpr)
    {
        curRepair += rpr;
        repair = true;

        if(gameSettings[currentSetting].pickUpsAmount == curRepair)
        {
            ChangePlayer();
            GameObject particleSmoke = Instantiate(repairAnim, transform);
            particleSmoke.transform.localPosition = Vector3.zero;
        }
    }

    public void Damage(int dmg)
    {
        curRepair -= dmg;
        damaged = true;
    }

    public void Death()
    {
        if(curRepair <= 0)
        {

        }
    }

    public void ChangePlayer()
    {
        // if (skins.Length < currentSetting)
        //     return;
        int skinId = gameSettings[currentSetting].skinId;

        for (int i = 0; i < skins.Length; i++)
        {
            skins[i].SetActive(false);
        }

        skins[skinId].SetActive(true);
        anim = skins[skinId].GetComponent<Animator>();
        //audioSource = skins[skinId].GetComponent<AudioSource>();

        ConfigigureMusic(skinId);



        currentSetting++;
    }

    private void ConfigigureMusic(int skinId)
    {
        switch (skinId)
        {
            case 0:
                //musica 1
                //audioSource.mute = false;
            break;
            case 1:
                //musica 2
                audioSource2.mute = false;
                audioSource.mute = true;
                audio1a2.Play(0);                

                break;
            case 2:
                audioSource2.mute = true;
                audioSource3.mute = false;
                audio2a3.Play(0);
            break;
        }
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

