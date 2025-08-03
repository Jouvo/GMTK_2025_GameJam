using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameMgr;

public class PlayerBubble : MonoBehaviour
{

    public Sprite needKey;
    public Sprite needCrystal;
    public GameObject player;
    public SpriteRenderer spriteRenderer;
    private Vector3 Pos;

    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindObjectOfType<PlayerMovement>().gameObject;
        spriteRenderer=GetComponent<SpriteRenderer>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Pos = player.transform.position+new Vector3(2.25f,1.8f,0);
        transform.position = Pos;
    }

    public void ChangeSprite(BubbleType type)
    {
        switch (type)
        {
            case BubbleType.Key:
                spriteRenderer.sprite = needKey;
                break;
            case BubbleType.Crystal:
                spriteRenderer.sprite = needCrystal;
                break;
        }
    }
}
