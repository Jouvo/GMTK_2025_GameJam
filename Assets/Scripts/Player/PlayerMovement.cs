using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 respawnPoint;

    public float speed = 5f;                // �ƶ��ٶ�
    public float jumpForce = 10f;           // ��Ծ��
    public LayerMask groundLayer;           // ����ͼ�㣬���ڼ������Ƿ��ڵ�����
    public Transform groundCheck;           // �������
    public float groundCheckRadius = 0.2f;  // ������뾶
    private bool isGrounded;                // �ж�����Ƿ��ڵ�����
    private Rigidbody2D rb;                 // ��Ҹ������
    private PhysicsMaterial2D noFriction;   // ��Ħ���������

    private void Awake()
    {
        // ����Ĭ�ϸ����λ��
        transform.position = respawnPoint;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // ����һ����Ħ�����������
        noFriction = new PhysicsMaterial2D { friction = 0f, bounciness = 0f };
        rb.sharedMaterial = noFriction;
    }

    void Update()
    {
        HandleJump();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }


    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveX * speed, rb.velocity.y);
        rb.velocity = movement;

        // ���ƽ�ɫ�ĳ���
        if (moveX > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveX < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void HandleJump()
    {
        // ����Ƿ��ڵ�����
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    public void Die()
    {
        // ������������߼�
        Debug.Log("Player died!");

        // ֹͣ���������̵��ƶ�
        ScreenScroll[] sc=GameObject.FindObjectsOfType<ScreenScroll>();
        for(int i = 0; i < sc.Length; i++)
        {
            sc[i].Switch(false);
        }
        // ������Ч�������ȹ���ʱ��

        // �ı����λ��
        transform.position = respawnPoint;
        
        // ����λ�ò����������߼�
        VCam VCam =GameObject.FindObjectOfType<VCam>();
        Vector3 CamPos = new Vector3(transform.position.x,0,-10);
        ChasingSpike cs = GameObject.FindObjectOfType<ChasingSpike>();
        cs.transform.SetParent(VCam.gameObject.transform);
        VCam.MoveToPos(CamPos);

        for (int i = 0; i < sc.Length; i++)
        {
            sc[i].Switch(true);
        }
    }

    // ���ùؿ�
    void ResetLevel()
    {
        // ʹ�õ�ǰ�������������¼��ص�ǰ����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // �ڱ༭���п��ӻ������ⷶΧ(GroundCheck)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
