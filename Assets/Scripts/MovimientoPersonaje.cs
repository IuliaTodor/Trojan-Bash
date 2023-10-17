using UnityEngine;

public class MovimientoPerosnaje : MonoBehaviour
{
    public float fuerzaSalto = 5.0f;
    private Animator _animator;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    private bool enElAire = false;
    public KeyCode teclaSalto = KeyCode.UpArrow;
    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _rb.velocity = new Vector2(7, _rb.velocity.y);
            _animator.SetBool("Mover", true);
            _sr.flipX = false;

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))

        {
            _rb.velocity = new Vector2(-7, _rb.velocity.y);
            _animator.SetBool("Mover", true);
            _sr.flipX = true;
        }
        if (Input.GetKeyDown(teclaSalto))
        {
           
            _rb.velocity = new Vector2(_rb.velocity.x, fuerzaSalto);
            _animator.SetBool("Saltar", true);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _rb.velocity = Vector2.zero;
            _animator.SetBool("Mover", false);
        }

    }
}
