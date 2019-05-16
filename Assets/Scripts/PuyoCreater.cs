using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuyoCreater : MonoBehaviour
{
    public GameObject bluePuyo;
    public GameObject greenPuyo;
    public GameObject purplePuyo;
    public GameObject redPuyo;
    public GameObject yellowPuyo;

    public static GameObject bluePuyoGameObject;
    public static GameObject greenPuyoGameObject;
    public static GameObject purplePuyoGameObject;
    public static GameObject redPuyoGameObject;
    public static GameObject yellowPuyoGameObject;

    void Start()
    {
        bluePuyoGameObject = bluePuyo;
        greenPuyoGameObject = greenPuyo;
        purplePuyoGameObject = purplePuyo;
        redPuyoGameObject = redPuyo;
        yellowPuyoGameObject = yellowPuyo;
    }

    public static Puyo PuyoCreate(int x, int y) {
        //print("puyo is creating...");
        Puyo puyo = GameMaster.puyoGroupObj.AddComponent<Puyo>();
        puyo.setColor(Random.Range(0, 5));
        puyo.setLinkStatus(ImageController.NORMAL);
        GameObject newPuyoObj;
        switch (puyo.getColor()) {
            case 0:
                newPuyoObj = Instantiate(bluePuyoGameObject);
                break;
            case 1:
                newPuyoObj = Instantiate(greenPuyoGameObject);
                break;
            case 2:
                newPuyoObj = Instantiate(purplePuyoGameObject);
                break;
            case 3:
                newPuyoObj = Instantiate(redPuyoGameObject);
                break;
            case 4:
                newPuyoObj = Instantiate(yellowPuyoGameObject);
                break;
            default:
                newPuyoObj = Instantiate(bluePuyoGameObject);
                break;
        }
        newPuyoObj.transform.SetParent(GameMaster.puyoGroupObj.transform);
        newPuyoObj.transform.localPosition = new Vector3(x, y, 0);
        newPuyoObj.transform.localScale = new Vector3(1, 1, 1);
        puyo.setPuyoObj(newPuyoObj);

        List<Puyo> puyoList = new List<Puyo>();
        puyoList.Add(puyo);
        puyo.setLinkPuyoList(puyoList);

        return puyo;
    }
}
