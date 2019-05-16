using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puyo : MonoBehaviour {
    private GameObject puyoObj;
    private List<Puyo> linkPuyoList;
    //0 = Blue, 1 = Green, 2 = Purple, 3 = Red, 4 = Yellow
    private int color;
    private Vector2 position;
    private string linkStatus;

    public void setPuyoObj(GameObject puyoObj)
    {
        this.puyoObj = puyoObj;
    }
    public GameObject getPuyoObj()
    {
        return puyoObj;
    }

    public void setColor(int color)
    {
        this.color = color;
    }
    public int getColor()
    {
        return color;
    }

    public void setLinkPuyoList(List<Puyo> linkPuyoList)
    {
        this.linkPuyoList = linkPuyoList;
    }
    public List<Puyo> getLinkPuyoList()
    {
        return linkPuyoList;
    }

    public void setPosition(Vector2 position)
    {
        this.position = position;
    }
    public Vector2 getPosition()
    {
        return position;
    }

    public void setLinkStatus(string linkStatus)
    {
        this.linkStatus = linkStatus;
    }
    public string getLinkStatus()
    {
        return linkStatus;
    }
}
