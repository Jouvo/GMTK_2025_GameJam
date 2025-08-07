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
    public AudioClip clip;

    private void OnEnable()
    {
        // ≤•∑≈“Ù–ß
        SoundPlayer.Instance.PlaySounds(clip);
    }

    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindObjectOfType<PlayerMovement>().gameObject;
        spriteRenderer=GetComponent<SpriteRenderer>();
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

    public void RemoveBubble()
    {
        Destroy(this.gameObject);
    }
}
