using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PuyoController : MonoBehaviour
{
    public static void puyoCreate()
    {
        GameMaster.controlMainPuyo = GameMaster.puyoInventory.Dequeue();
        GameMaster.controlSubPuyo = GameMaster.puyoInventory.Dequeue();
        GameMaster.puyoInventory.ElementAt(1).getPuyoObj().transform.localPosition = new Vector3(100, 175, 0);
        GameMaster.puyoInventory.ElementAt(0).getPuyoObj().transform.localPosition = new Vector3(100, 143, 0);
        GameMaster.puyoInventory.Enqueue(PuyoCreater.PuyoCreate(100, 18));
        GameMaster.puyoInventory.Enqueue(PuyoCreater.PuyoCreate(100, 50));
        GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition = new Vector3(0, 208, 0);
        GameMaster.controlSubPuyo.getPuyoObj().transform.localPosition = new Vector3(0, 240, 0);
        GameMaster.controlMainPuyo.setPosition(new Vector2(3, 12));
        GameMaster.controlSubPuyo.setPosition(new Vector2(3, 13));
        GameMaster.subPuyoDirection = 0;
        GameMaster.comboNumber = 0;
        GameMaster.mainPuyoShinyObj.transform.localPosition = new Vector3(0, 208, 0);
        GameMaster.mainPuyoShinyObj.transform.SetAsLastSibling();
        ImageController.setShinyPuyo(GameMaster.controlMainPuyo.getColor());
    }

    public static void puyoDown(bool moveShinyPuyo)
    {
        GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition = new Vector3
                    (GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition.x, GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition.y - 32, GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition.z);
        GameMaster.controlSubPuyo.getPuyoObj().transform.localPosition = new Vector3
            (GameMaster.controlSubPuyo.getPuyoObj().transform.localPosition.x, GameMaster.controlSubPuyo.getPuyoObj().transform.localPosition.y - 32, GameMaster.controlSubPuyo.getPuyoObj().transform.localPosition.z);
        GameMaster.controlMainPuyo.setPosition(new Vector2(GameMaster.controlMainPuyo.getPosition().x, GameMaster.controlMainPuyo.getPosition().y - 1));
        GameMaster.controlSubPuyo.setPosition(new Vector2(GameMaster.controlSubPuyo.getPosition().x, GameMaster.controlSubPuyo.getPosition().y - 1));
        if (moveShinyPuyo)
        {
            GameMaster.mainPuyoShinyObj.transform.localPosition = GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition;
        }
    }

    public static void puyoLeft(bool moveShinyPuyo)
    {
        GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition = new Vector3
                    (GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition.x - 32, GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition.y, GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition.z);
        GameMaster.controlSubPuyo.getPuyoObj().transform.localPosition = new Vector3
            (GameMaster.controlSubPuyo.getPuyoObj().transform.localPosition.x - 32, GameMaster.controlSubPuyo.getPuyoObj().transform.localPosition.y, GameMaster.controlSubPuyo.getPuyoObj().transform.localPosition.z);
        GameMaster.controlMainPuyo.setPosition(new Vector2(GameMaster.controlMainPuyo.getPosition().x - 1, GameMaster.controlMainPuyo.getPosition().y));
        GameMaster.controlSubPuyo.setPosition(new Vector2(GameMaster.controlSubPuyo.getPosition().x - 1, GameMaster.controlSubPuyo.getPosition().y));
        if (moveShinyPuyo)
        {
            GameMaster.mainPuyoShinyObj.transform.localPosition = GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition;
        }
    }

    public static void puyoRight(bool moveShinyPuyo)
    {
        GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition = new Vector3
                    (GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition.x + 32, GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition.y, GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition.z);
        GameMaster.controlSubPuyo.getPuyoObj().transform.localPosition = new Vector3
            (GameMaster.controlSubPuyo.getPuyoObj().transform.localPosition.x + 32, GameMaster.controlSubPuyo.getPuyoObj().transform.localPosition.y, GameMaster.controlSubPuyo.getPuyoObj().transform.localPosition.z);
        GameMaster.controlMainPuyo.setPosition(new Vector2(GameMaster.controlMainPuyo.getPosition().x + 1, GameMaster.controlMainPuyo.getPosition().y));
        GameMaster.controlSubPuyo.setPosition(new Vector2(GameMaster.controlSubPuyo.getPosition().x + 1, GameMaster.controlSubPuyo.getPosition().y));
        if (moveShinyPuyo)
        {
            GameMaster.mainPuyoShinyObj.transform.localPosition = GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition;
        }
    }

    public static void puyoCounterclockwise()
    {
        int x = (int)GameMaster.controlMainPuyo.getPosition().x;
        int y = (int)GameMaster.controlMainPuyo.getPosition().y;
        if (GameMaster.subPuyoDirection == 0)
        {
            if ((x == 0 || GameMaster.puyoArr[x - 1, y] == null) && (x == 5 || GameMaster.puyoArr[x + 1, y] == null))
            {
                if (x == 0 || GameMaster.puyoArr[x - 1, y] != null)
                {
                    puyoRight(true);
                }
                GameMaster.subPuyoDirection = 3;
                subPuyoMoveToLeft();
            }
        }
        else if (GameMaster.subPuyoDirection == 1)
        {
            GameMaster.subPuyoDirection = 0;
            subPuyoMoveToTop();
        }
        else if (GameMaster.subPuyoDirection == 2)
        {
            if ((x == 5 || GameMaster.puyoArr[x + 1, y] == null) && (x == 0 || GameMaster.puyoArr[x - 1, y] == null))
            {
                if (x == 5 || GameMaster.puyoArr[x + 1, y] != null)
                {
                    puyoLeft(true);
                }
                GameMaster.subPuyoDirection = 1;
                subPuyoMoveToRight();
            }
        }
        else if (GameMaster.subPuyoDirection == 3)
        {
            if (y != 0)
            {
                GameMaster.subPuyoDirection = 2;
                subPuyoMoveToDown();
            }
        }

    }

    public static void puyoClockwise()
    {
        //soundManager.playSound("rotateSound");
        int x = (int)GameMaster.controlMainPuyo.getPosition().x;
        int y = (int)GameMaster.controlMainPuyo.getPosition().y;
        if (GameMaster.subPuyoDirection == 0)
        {
            if ((x == 5 || GameMaster.puyoArr[x + 1, y] == null) && (x == 0 || GameMaster.puyoArr[x - 1, y] == null))
            {
                if (x == 5 || GameMaster.puyoArr[x + 1, y] != null)
                {
                    puyoLeft(true);
                }
                GameMaster.subPuyoDirection = 1;
                subPuyoMoveToRight();
            }
        }
        else if (GameMaster.subPuyoDirection == 1)
        {
            if (y != 0)
            {
                GameMaster.subPuyoDirection = 2;
                subPuyoMoveToDown();
            }
        }
        else if (GameMaster.subPuyoDirection == 2)
        {
            if ((x == 0 || GameMaster.puyoArr[x - 1, y] == null) && (x == 5 || GameMaster.puyoArr[x + 1, y] == null))
            {
                if (x == 0 || GameMaster.puyoArr[x - 1, y] != null)
                {
                    puyoRight(true);
                }
                GameMaster.subPuyoDirection = 3;
                subPuyoMoveToLeft();
            }
        }
        else if (GameMaster.subPuyoDirection == 3)
        {
            GameMaster.subPuyoDirection = 0;
            subPuyoMoveToTop();
        }

    }

    public static void puyoArrange()
    {
        GameMaster.mainPuyoShinyObj.transform.localPosition = new Vector3(0, 208, 0);
        //If a puyo on the air, then make it fall to bottom.
        for (int y = 1; y < 13; y++)
        {
            for (int x = 0; x < 6; x++)
            {
                if (GameMaster.puyoArr[x, y] != null)
                {
                    if (GameMaster.puyoArr[x, y - 1] == null)
                    {
                        FindObjectOfType<AudioManager>().Play("placePuyo");
                        GameObject tempPuyo = GameMaster.puyoArr[x, y].getPuyoObj();
                        tempPuyo.transform.localPosition = new Vector3(tempPuyo.transform.localPosition.x, tempPuyo.transform.localPosition.y - 32, tempPuyo.transform.localPosition.z);
                        GameMaster.puyoArr[x, y - 1] = GameMaster.puyoArr[x, y];
                        GameMaster.puyoArr[x, y] = null;
                        y = 1;
                        x = -1;
                    }
                }
            }
        }
    }

    public static bool reachBottom(int x, int y)
    {
        if (y == 0)
        {
            return true;
        }
        if (GameMaster.puyoArr[x, y - 1] != null)
        {
            return true;
        }
        return false;
    }

    //0=left, 1=right
    public static bool havingObstacle(int type, int x, int y)
    {
        if (y >= 13)
            return false;

        if (x <= 0 && type == 0)
            return true;

        if (x >= 5 && type == 1)
            return true;

        if (type == 0)
        {
            if (GameMaster.puyoArr[x - 1, y] != null)
            {
                return true;
            }
        }
        else
        {
            if (GameMaster.puyoArr[x + 1, y] != null)
            {
                return true;
            }
        }
        return false;
    }

    public static void subPuyoMoveToTop()
    {
        GameMaster.controlSubPuyo.getPuyoObj().transform.localPosition = new Vector3
            (GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition.x, GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition.y + 32, GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition.z);
        GameMaster.controlSubPuyo.setPosition(new Vector2(GameMaster.controlMainPuyo.getPosition().x, GameMaster.controlMainPuyo.getPosition().y + 1));
    }

    public static void subPuyoMoveToDown()
    {
        GameMaster.controlSubPuyo.getPuyoObj().transform.localPosition = new Vector3
            (GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition.x, GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition.y - 32, GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition.z);
        GameMaster.controlSubPuyo.setPosition(new Vector2(GameMaster.controlMainPuyo.getPosition().x, GameMaster.controlMainPuyo.getPosition().y - 1));
    }

    public static void subPuyoMoveToLeft()
    {
        GameMaster.controlSubPuyo.getPuyoObj().transform.localPosition = new Vector3
            (GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition.x - 32, GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition.y, GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition.z);
        GameMaster.controlSubPuyo.setPosition(new Vector2(GameMaster.controlMainPuyo.getPosition().x - 1, GameMaster.controlMainPuyo.getPosition().y));
    }

    public static void subPuyoMoveToRight()
    {
        GameMaster.controlSubPuyo.getPuyoObj().transform.localPosition = new Vector3
            (GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition.x + 32, GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition.y, GameMaster.controlMainPuyo.getPuyoObj().transform.localPosition.z);
        GameMaster.controlSubPuyo.setPosition(new Vector2(GameMaster.controlMainPuyo.getPosition().x + 1, GameMaster.controlMainPuyo.getPosition().y));
    }

    public static void linkSamePuyo()
    {
        //Link horizontal obj
        for (int y = 0; y < 13; y++)
        {
            bool emptyRow = true;
            for (int x = 0; x < 5; x++)
            {
                if (GameMaster.puyoArr[x, y] != null)
                {
                    emptyRow = false;
                    if (GameMaster.puyoArr[x + 1, y] != null && GameMaster.puyoArr[x, y].getColor() == GameMaster.puyoArr[x + 1, y].getColor())
                    {
                        if (ImageController.LINK_LEFT == GameMaster.puyoArr[x, y].getLinkStatus())
                            GameMaster.puyoArr[x, y].setLinkStatus(ImageController.LINK_RIGHT_LEFT);
                        else
                            GameMaster.puyoArr[x, y].setLinkStatus(ImageController.LINK_RIGHT);
                        GameMaster.puyoArr[x + 1, y].setLinkStatus(ImageController.LINK_LEFT);

                        setPuyoALinkList(GameMaster.puyoArr[x, y], GameMaster.puyoArr[x + 1, y]);
                    }
                }
            }
            if (emptyRow)
                break;
        }
        //Link vertical obj
        for (int y = 0; y < 13; y++)
        {
            bool emptyRow = true;
            for (int x = 0; x < 6; x++)
            {
                if (GameMaster.puyoArr[x, y] != null)
                {
                    emptyRow = false;
                    if (GameMaster.puyoArr[x, y + 1] != null && GameMaster.puyoArr[x, y].getColor() == GameMaster.puyoArr[x, y + 1].getColor())
                    {
                        switch (GameMaster.puyoArr[x, y + 1].getLinkStatus())
                        {
                            case ImageController.NORMAL:
                                GameMaster.puyoArr[x, y + 1].setLinkStatus(ImageController.LINK_DOWN);
                                break;
                            case ImageController.LINK_TOP:
                                GameMaster.puyoArr[x, y + 1].setLinkStatus(ImageController.LINK_TOP_DOWN);
                                break;
                            case ImageController.LINK_LEFT:
                                GameMaster.puyoArr[x, y + 1].setLinkStatus(ImageController.LINK_LEFT_DOWN);
                                break;
                            case ImageController.LINK_RIGHT:
                                GameMaster.puyoArr[x, y + 1].setLinkStatus(ImageController.LINK_RIGHT_DOWN);
                                break;
                            case ImageController.LINK_RIGHT_LEFT:
                                GameMaster.puyoArr[x, y + 1].setLinkStatus(ImageController.LINK_RIGHT_LEFT_DOWN);
                                break;
                            case ImageController.LINK_TOP_LEFT:
                                GameMaster.puyoArr[x, y + 1].setLinkStatus(ImageController.LINK_TOP_LEFT_DOWN);
                                break;
                            case ImageController.LINK_TOP_RIGHT:
                                GameMaster.puyoArr[x, y + 1].setLinkStatus(ImageController.LINK_TOP_RIGHT_DOWN);
                                break;
                            case ImageController.LINK_TOP_RIGHT_LEFT:
                                GameMaster.puyoArr[x, y + 1].setLinkStatus(ImageController.LINK_TOP_RIGHT_LEFT_DOWN);
                                break;
                        }
                        switch (GameMaster.puyoArr[x, y].getLinkStatus())
                        {
                            case ImageController.NORMAL:
                                GameMaster.puyoArr[x, y].setLinkStatus(ImageController.LINK_TOP);
                                break;
                            case ImageController.LINK_LEFT:
                                GameMaster.puyoArr[x, y].setLinkStatus(ImageController.LINK_TOP_LEFT);
                                break;
                            case ImageController.LINK_RIGHT:
                                GameMaster.puyoArr[x, y].setLinkStatus(ImageController.LINK_TOP_RIGHT);
                                break;
                            case ImageController.LINK_RIGHT_LEFT:
                                GameMaster.puyoArr[x, y].setLinkStatus(ImageController.LINK_TOP_RIGHT_LEFT);
                                break;
                            case ImageController.LINK_DOWN:
                                GameMaster.puyoArr[x, y].setLinkStatus(ImageController.LINK_TOP_DOWN);
                                break;
                            case ImageController.LINK_LEFT_DOWN:
                                GameMaster.puyoArr[x, y].setLinkStatus(ImageController.LINK_TOP_LEFT_DOWN);
                                break;
                            case ImageController.LINK_RIGHT_DOWN:
                                GameMaster.puyoArr[x, y].setLinkStatus(ImageController.LINK_TOP_RIGHT_DOWN);
                                break;
                            case ImageController.LINK_RIGHT_LEFT_DOWN:
                                GameMaster.puyoArr[x, y].setLinkStatus(ImageController.LINK_TOP_RIGHT_LEFT_DOWN);
                                break;
                        }

                        setPuyoALinkList(GameMaster.puyoArr[x, y], GameMaster.puyoArr[x, y + 1]);
                    }
                }
            }
            if (emptyRow)
                break;
        }
        updatePuyoImage();
    }

    public static void updatePuyoImage()
    {
        //change img
        for (int y = 0; y < 13; y++)
        {
            bool emptyRow = true;
            for (int x = 0; x < 6; x++)
            {
                if (GameMaster.puyoArr[x, y] != null)
                {
                    //print("("+x+", "+y+")===>"+GameMaster.puyoArr[x, y].getLinkPuyoList().Count);
                    emptyRow = false;
                    ImageController.setPuyoImage(GameMaster.puyoArr[x, y], GameMaster.puyoArr[x, y].getLinkStatus());
                }
            }
            if (emptyRow)
                break;
        }
    }

    public static void setPuyoALinkList(Puyo puyoA, Puyo puyoB)
    {
        List<Puyo> puyoAList = puyoA.getLinkPuyoList();
        if (!puyoAList.Contains(puyoB))
        {
            puyoAList.Add(puyoB);
        }
        List<Puyo> puyoBList = puyoB.getLinkPuyoList();
        if (!puyoBList.Contains(puyoA))
        {
            puyoBList.Add(puyoA);
        }
        List<Puyo> puyoCList = puyoAList.Union(puyoBList).ToList<Puyo>();

        for (int i = 0; i < puyoAList.Count; i++)
        {
            puyoAList[i].setLinkPuyoList(puyoCList);
        }
        for (int i = 0; i < puyoBList.Count; i++)
        {
            puyoBList[i].setLinkPuyoList(puyoCList);
        }
    }

    public static void resetPuyoStatusAndLinkPuyoList()
    {
        for (int y = 0; y < 13; y++)
        {
            bool emptyRow = true;
            for (int x = 0; x < 6; x++)
            {
                if (GameMaster.puyoArr[x, y] != null)
                {
                    emptyRow = false;
                    GameMaster.puyoArr[x, y].setLinkStatus(ImageController.NORMAL);
                    List<Puyo> puyoList = new List<Puyo>();
                    puyoList.Add(GameMaster.puyoArr[x, y]);
                    GameMaster.puyoArr[x, y].setLinkPuyoList(puyoList);
                }
            }
            if (emptyRow)
                break;
        }
    }

    public static bool readyToEliminatePuyo()
    {
        bool haveLinkPuyo = false;
        for (int y = 0; y < 13; y++)
        {
            bool emptyRow = true;
            for (int x = 0; x < 6; x++)
            {
                if (GameMaster.puyoArr[x, y] != null)
                {
                    emptyRow = false;
                    //print(puyoArr[x, y].getColor()+" " +puyoArr[x, y].getLinkedPuyoList().Count);
                    if (GameMaster.puyoArr[x, y].getLinkPuyoList().Count >= 4)
                    {
                        haveLinkPuyo = true;
                        GameMaster.puyoArr[x, y].setLinkStatus(ImageController.ELIMINATE_FACE);
                    }
                }
            }
            if (emptyRow)
                break;
        }
        updatePuyoImage();
        return haveLinkPuyo;
    }

    public static void eliminatePuyo()
    {
        for (int y = 0; y < 13; y++)
        {
            bool emptyRow = true;
            for (int x = 0; x < 6; x++)
            {
                if (GameMaster.puyoArr[x, y] != null)
                {
                    if (ImageController.ELIMINATE_FACE == GameMaster.puyoArr[x, y].getLinkStatus())
                    {
                        FindObjectOfType<AudioManager>().Play("chain");
                        Destroy(GameMaster.puyoArr[x, y].getPuyoObj());
                        GameMaster.puyoArr[x, y] = null;
                    }
                    emptyRow = false;
                }
            }
            if (emptyRow)
                break;
        }
    }

    public static void eliminateRow()
    {
        int rowDeleteHeight = 0;
        if (isCameraLimit())
        {
            for (int y = 7; y < 12; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    if (GameMaster.puyoArr[x, y] != null)
                    {
                        rowDeleteHeight++;
                        x = 0;
                        break;
                    }
                }
            }
            for (int y = 0; y < rowDeleteHeight; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    if (GameMaster.puyoArr[x, y] != null)
                    {
                        FindObjectOfType<AudioManager>().Play("fall");
                        Destroy(GameMaster.puyoArr[x, y].getPuyoObj());
                        GameMaster.puyoArr[x, y] = null;
                    }
                }
            }
            if (isGameOver(rowDeleteHeight))
            {
                FindObjectOfType<AudioManager>().Play("dead");
                GameMaster.gameOverObj.SetActive(true);
                GameMaster.gameStatus = GameMaster.GameStatus.GamePause;
            }
        }
    }

    public static bool isCameraLimit() //camera threshold for deletion
    {
        if (GameMaster.controlMainPuyo.getPosition().y >= 7 || GameMaster.controlSubPuyo.getPosition().y >= 7)
            return true;

        return false;
    }

    public static bool isGameOver(int rowDeleteHeight)
    {
        if ((rowDeleteHeight >= GameMaster.controlMainPuyo.getPosition().y) || (rowDeleteHeight >= GameMaster.controlSubPuyo.getPosition().y))
            return true;

        return false;

    }

    public static void hold()
    {
        int tempMainColor = GameMaster.puyoInventory.ElementAt(1).getColor();
        int tempSubColor = GameMaster.puyoInventory.ElementAt(0).getColor();
        GameMaster.puyoInventory.ElementAt(1).setColor(GameMaster.controlMainPuyo.getColor());
        GameMaster.puyoInventory.ElementAt(0).setColor(GameMaster.controlSubPuyo.getColor());
        GameMaster.controlMainPuyo.setColor(tempMainColor);
        GameMaster.controlSubPuyo.setColor(tempSubColor);
        ImageController.setPuyoImage(GameMaster.puyoInventory.ElementAt(1), ImageController.NORMAL);
        ImageController.setPuyoImage(GameMaster.puyoInventory.ElementAt(0), ImageController.NORMAL);
        ImageController.setPuyoImage(GameMaster.controlMainPuyo, ImageController.NORMAL);
        ImageController.setPuyoImage(GameMaster.controlSubPuyo, ImageController.NORMAL);
    }
}
