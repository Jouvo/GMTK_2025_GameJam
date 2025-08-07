using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class GameMgr : MonoBehaviour
{

    [Header("�ؿ���Ϣ")]
    public float BlockWidth=50;
    public int BlockNum = 4;
    public bool isIce = true;

    [Header("UI")]
    public GameObject BubblePrefab;
    public PlayerBubble Bubble;
    public enum BubbleType { Key, Crystal };

    public static GameMgr Instance;
    public Image[] crystalSlots; // UI��λ��Image����
    public Image coinIcon; // Coin��UI��λ
    public List<int> crystalID = new List<int>();

    public GameObject KeyPrefab;
    public RectTransform KeyPanel;
    private List<GameObject> keyIcons=new List<GameObject>();

    public int CoinNum = 0;
    public TextMeshProUGUI CoinText;

    public GameObject winPanel;

    void Awake()
    {
        Instance = this;
    }


    // ��Ҽ���������UI��ʾ
    public void AddCoin(int num)
    {
        CoinNum += num;
        CoinText.text = CoinNum.ToString();
    }

    // ���Կ��ͼ��
    public void AddKeyIcon()
    {
        GameObject newIcon=Instantiate(KeyPrefab,KeyPanel);
        keyIcons.Add(newIcon);
    }

    // �Ƴ�Կ��ͼ��
    public bool UseKey()
    {
        if(keyIcons.Count > 0)  // ��Կ�ף��Զ�ʹ��
        {
            GameObject UsedKey = keyIcons[keyIcons.Count - 1];
            keyIcons.Remove(UsedKey);
            return true;
        }
        else  // ��Կ�ף�����������ʾ
        {
            spawnBubble(BubbleType.Key);
            return false;
        }
    }

    public void Win()
    {
        GameObject.FindObjectOfType<PlayerMovement>().enabled = false;
        ScreenScroll[] sc = GameObject.FindObjectsOfType<ScreenScroll>();
        foreach(ScreenScroll s in sc)
        {
            s.Switch(false);
        }
    }

    public void OpenWinPanel()
    {
        winPanel.SetActive(true);
    }

    public void spawnBubble(BubbleType type)
    {
        GameObject playerBubble=GameObject.Instantiate(BubblePrefab,this.transform);
        Bubble=playerBubble.GetComponent<PlayerBubble>();
        Bubble.ChangeSprite(type);
    }
}