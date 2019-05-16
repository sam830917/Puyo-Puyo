using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public Sprite[] bluePuyoLinkedImgArr;
    public Sprite[] greenPuyoLinkedImgArr;
    public Sprite[] purplePuyoLinkedImgArr;
    public Sprite[] redPuyoLinkedImgArr;
    public Sprite[] yellowPuyoLinkedImgArr;
    public Sprite[] numberImgArr;
    public Sprite[] shinyPuyoArr;
    public GameObject comboDisplay;

    public static Dictionary<string, Sprite> bluePuyoImgDic = new Dictionary<string, Sprite>();
    public static Dictionary<string, Sprite> greenPuyoImgDic = new Dictionary<string, Sprite>();
    public static Dictionary<string, Sprite> purplePuyoImgDic = new Dictionary<string, Sprite>();
    public static Dictionary<string, Sprite> redPuyoImgDic = new Dictionary<string, Sprite>();
    public static Dictionary<string, Sprite> yellowPuyoImgDic = new Dictionary<string, Sprite>();
    public static Dictionary<int, Sprite> numberImgDic = new Dictionary<int, Sprite>();
    public static Dictionary<int, Sprite> shinyPuyoDic = new Dictionary<int, Sprite>();
    public static GameObject comboGameObject;
    public static Image digitsImage;
    public static Image tenDigitsImage;

    public const string NORMAL = "normal";
    public const string LINK_TOP = "top";
    public const string LINK_RIGHT = "right";
    public const string LINK_TOP_RIGHT = "top_right";
    public const string LINK_DOWN = "down";
    public const string LINK_TOP_DOWN = "top_down";
    public const string LINK_RIGHT_DOWN = "right_down";
    public const string LINK_TOP_RIGHT_DOWN = "top_right_down";
    public const string LINK_LEFT = "left";
    public const string LINK_TOP_LEFT = "top_left";
    public const string LINK_RIGHT_LEFT = "right_left";
    public const string LINK_TOP_RIGHT_LEFT = "top_right_left";
    public const string LINK_LEFT_DOWN = "left_down";
    public const string LINK_TOP_LEFT_DOWN = "top_left_down";
    public const string LINK_RIGHT_LEFT_DOWN = "right_left_down";
    public const string LINK_TOP_RIGHT_LEFT_DOWN = "top_right_left_down";
    public const string ELIMINATE_FACE = "eliminate";

    void Start()
    {
        distributingPuyoImgToDictionary(bluePuyoLinkedImgArr, bluePuyoImgDic);
        distributingPuyoImgToDictionary(greenPuyoLinkedImgArr, greenPuyoImgDic);
        distributingPuyoImgToDictionary(purplePuyoLinkedImgArr, purplePuyoImgDic);
        distributingPuyoImgToDictionary(redPuyoLinkedImgArr, redPuyoImgDic);
        distributingPuyoImgToDictionary(yellowPuyoLinkedImgArr, yellowPuyoImgDic);
        comboGameObject = comboDisplay;
        digitsImage = comboDisplay.transform.GetChild(0).gameObject.GetComponent<Image>();
        tenDigitsImage = comboDisplay.transform.GetChild(1).gameObject.GetComponent<Image>();
        distributingNumberImgToDictionary(numberImgArr, numberImgDic);
        distributingShinyPuyoToDictionary(shinyPuyoArr, shinyPuyoDic);
    }

    public static void setShinyPuyo(int num)
    {
        GameMaster.mainPuyoShinyObj.GetComponent<Image>().sprite = shinyPuyoDic[num];
    }

    public static void setComboNumber(int num)
    {
        int digits = num % 10;
        int tenDigits = num / 10;
        if (tenDigits == 0)
        {
            tenDigitsImage.gameObject.SetActive(false);
        }
        else
        {
            tenDigitsImage.gameObject.SetActive(true);
        }
        digitsImage.sprite = numberImgDic[digits];
        tenDigitsImage.sprite = numberImgDic[tenDigits];
    }

    public static void setPuyoImage(Puyo puyo, string imgKey)
    {
        Image puyoImage = puyo.getPuyoObj().GetComponent<Image>();
        switch (puyo.getColor()) {
            case 0:
                puyoImage.sprite = bluePuyoImgDic[imgKey];
                break;
            case 1:
                puyoImage.sprite = greenPuyoImgDic[imgKey];
                break;
            case 2:
                puyoImage.sprite = purplePuyoImgDic[imgKey];
                break;
            case 3:
                puyoImage.sprite = redPuyoImgDic[imgKey];
                break;
            case 4:
                puyoImage.sprite = yellowPuyoImgDic[imgKey];
                break;
        }
    }

    private void distributingPuyoImgToDictionary(Sprite[] spriteArr, Dictionary<string, Sprite> dic) {
        dic.Add(NORMAL, spriteArr[0]);
        dic.Add(LINK_TOP , spriteArr[1]);
        dic.Add(LINK_RIGHT, spriteArr[2]);
        dic.Add(LINK_TOP_RIGHT, spriteArr[3]);
        dic.Add(LINK_DOWN, spriteArr[4]);
        dic.Add(LINK_TOP_DOWN, spriteArr[5]);
        dic.Add(LINK_RIGHT_DOWN, spriteArr[6]);
        dic.Add(LINK_TOP_RIGHT_DOWN, spriteArr[7]);
        dic.Add(LINK_LEFT, spriteArr[8]);
        dic.Add(LINK_TOP_LEFT, spriteArr[9]);
        dic.Add(LINK_RIGHT_LEFT, spriteArr[10]);
        dic.Add(LINK_TOP_RIGHT_LEFT, spriteArr[11]);
        dic.Add(LINK_LEFT_DOWN, spriteArr[12]);
        dic.Add(LINK_TOP_LEFT_DOWN, spriteArr[13]);
        dic.Add(LINK_RIGHT_LEFT_DOWN, spriteArr[14]);
        dic.Add(LINK_TOP_RIGHT_LEFT_DOWN, spriteArr[15]);
        dic.Add(ELIMINATE_FACE, spriteArr[16]);
    }

    private void distributingNumberImgToDictionary(Sprite[] spriteArr, Dictionary<int, Sprite> dic)
    {
        dic.Add(0, spriteArr[0]);
        dic.Add(1, spriteArr[1]);
        dic.Add(2, spriteArr[2]);
        dic.Add(3, spriteArr[3]);
        dic.Add(4, spriteArr[4]);
        dic.Add(5, spriteArr[5]);
        dic.Add(6, spriteArr[6]);
        dic.Add(7, spriteArr[7]);
        dic.Add(8, spriteArr[8]);
        dic.Add(9, spriteArr[9]);
    }

    private void distributingShinyPuyoToDictionary(Sprite[] spriteArr, Dictionary<int, Sprite> dic)
    {
        dic.Add(0, spriteArr[0]);
        dic.Add(1, spriteArr[1]);
        dic.Add(2, spriteArr[2]);
        dic.Add(3, spriteArr[3]);
        dic.Add(4, spriteArr[4]);
    }
}
