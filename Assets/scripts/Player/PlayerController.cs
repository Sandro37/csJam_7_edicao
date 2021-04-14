using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float velo;

    [Header("Variáveis de controle")]
    [SerializeField] public static float velocidade;


    [HideInInspector]
    public static float guardarVelocidade;
    public static float movementX;


    [Header("Componentes da unity")]
    [SerializeField] private Animator anim;

    private Rigidbody2D rig;
    public static LimiteTela playerLimiteTela;
    public static bool podeMexer = true;
    public static bool estaParado = true;




    private void Awake()
    {
        velocidade = velo;
        guardarVelocidade = velocidade;
        podeMexer = true;
        controleAnimacao(0);

    }
    // Start is called before the first frame update
    void Start()
    {
        playerLimiteTela = GetComponent<LimiteTela>();
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        verificarLimite();
    }

    private void FixedUpdate()
    {
        move();
    }


    private void controleAnimacao(int x) {
        anim.SetInteger("transition", x);
    }
    private void move()
    {

        if (velocidade == 0)
        {
            movementX = 0f;
        }

        if (podeMexer)
        {
            movementX = Input.GetAxis("Horizontal");
        }

        if (velocidade == 0 || movementX == 0)
        {
            rig.velocity = new Vector2(0, rig.velocity.y);

        }

        if (movementX == 0 || velocidade == 0)
        {
            controleAnimacao(0);
            rig.velocity = new Vector2(0, rig.velocity.y);
            estaParado = true;
        }
        else if (movementX > 0)
        {
            rig.velocity = new Vector2(movementX * velocidade, rig.velocity.y);
            estaParado = false;
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            controleAnimacao(1);
        }
        else if (movementX < 0)
        {
            rig.velocity = new Vector2(movementX * velocidade, rig.velocity.y);
            estaParado = false;
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            controleAnimacao(1);
        }
    }


    public void verificarLimite()
    {
        rig.position = new Vector2(Mathf.Clamp(rig.position.x, playerLimiteTela.xMin, playerLimiteTela.XMax),
            Mathf.Clamp(rig.position.y, playerLimiteTela.yMin, playerLimiteTela.yMax));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "FIM")
        {
            podeMexer = false;
            controleAnimacao(0);
        }
    }
}
