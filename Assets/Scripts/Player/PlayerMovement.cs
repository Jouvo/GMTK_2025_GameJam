using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 respawnPoint;

    public float speed = 5f;                // 移动速度
    public float jumpForce = 10f;           // 跳跃力
    public LayerMask groundLayer;           // 地面图层，用于检测玩家是否在地面上
    public Transform groundCheck;           // 地面检测点
    public float groundCheckRadius = 0.2f;  // 地面检测半径
    private bool isGrounded;                // 判断玩家是否在地面上
    private Rigidbody2D rb;                 // 玩家刚体组件
    private PhysicsMaterial2D noFriction;   // 无摩擦物理材质

    private void Awake()
    {
        // 设置默认复活点位置
        transform.position = respawnPoint;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // 创建一个无摩擦的物理材质
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

        // 控制角色的朝向
        if (moveX > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveX < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void HandleJump()
    {
        // 检测是否在地面上
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    public void Die()
    {
        // 处理玩家死亡逻辑
        Debug.Log("Player died!");

        // 停止摄像机、尖刺的移动
        ScreenScroll[] sc=GameObject.FindObjectsOfType<ScreenScroll>();
        for(int i = 0; i < sc.Length; i++)
        {
            sc[i].Switch(false);
        }
        // 播放特效、黑屏等过渡时间

        // 改变玩家位置
        transform.position = respawnPoint;
        
        // 重置位置并启动滚轴逻辑
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

    // 重置关卡
    void ResetLevel()
    {
        // 使用当前场景的名字重新加载当前场景
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 在编辑器中可视化地面检测范围(GroundCheck)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
