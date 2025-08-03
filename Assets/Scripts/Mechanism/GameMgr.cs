using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class GameMgr : MonoBehaviour
{
    public GameObject playerBubble;
    public PlayerBubble Bubble;
    public enum BubbleType { Key, Crystal };

    public static GameMgr Instance;
    public Image[] crystalSlots; // UI槽位的Image数组
    public Image coinIcon; // Coin的UI槽位
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

    private void Start()
    {
        Bubble=playerBubble.GetComponent<PlayerBubble>();
    }

    // 金币计数，更新UI显示
    public void AddCoin(int num)
    {
        CoinNum += num;
        CoinText.text = CoinNum.ToString();
    }

    // 添加钥匙图标
    public void AddKeyIcon()
    {
        GameObject newIcon=Instantiate(KeyPrefab,KeyPanel);
        keyIcons.Add(newIcon);
    }

    // 移除钥匙图标
    public bool UseKey()
    {
        if(keyIcons.Count > 0)  // 有钥匙，自动使用
        {
            GameObject UsedKey = keyIcons[keyIcons.Count - 1];
            keyIcons.Remove(UsedKey);
            return true;
        }
        else  // 无钥匙，出现气泡提示
        {
            playerBubble.SetActive(true);
            Bubble.ChangeSprite(BubbleType.Key);
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

}