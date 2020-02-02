using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    // Create -> Fall -> Arrange -> Link -> Calculate combo
    public enum GameStatus
    {
        GameInitializing, PuyoCreating, PuyoFalling, PuyoArranging, PuyoLinking, ComboCalculating, GamePause, GameOver
    }

    public GameObject puyoGroup;
    public float fallingSpeed;
    public GameObject mainPuyoShiny;
    public GameObject gameOver;

    public static GameStatus gameStatus;
    public static GameObject puyoGroupObj;
    public static GameObject mainPuyoShinyObj;
    public static GameObject gameOverObj;
    public static Puyo[,] puyoArr = new Puyo[6, 13];
    public static Puyo controlMainPuyo;
    public static Puyo controlSubPuyo;
    public static Queue<Puyo> puyoInventory;
    //0=top, 1=right, 2=down, 3=left
    public static int subPuyoDirection = 2;
    public static int comboNumber = 0;

    public static int bottomPosition = -176;
    public static int leftPosition = -96;
    public static int rightPosition = 64;

    private bool falling = true;

    void Start() {
        puyoGroupObj = puyoGroup;
        gameOverObj = gameOver;
        puyoInventory = new Queue<Puyo>();
        gameStatus = GameStatus.GameInitializing;
        mainPuyoShinyObj = mainPuyoShiny;
    }

    void FixedUpdate()
    {
        if (gameStatus == GameStatus.GameInitializing)
        {
            puyoInventory.Enqueue(PuyoCreater.PuyoCreate(100, 175));
            puyoInventory.Enqueue(PuyoCreater.PuyoCreate(100, 143));
            puyoInventory.Enqueue(PuyoCreater.PuyoCreate(100, 50));
            puyoInventory.Enqueue(PuyoCreater.PuyoCreate(100, 18));

            gameStatus = GameStatus.PuyoCreating;
        }

        if (gameStatus == GameStatus.PuyoCreating)
        {
            PuyoController.puyoCreate();
            gameStatus = GameStatus.PuyoFalling;
        }

        if (gameStatus == GameStatus.PuyoFalling)
        {
            if (falling)
            {
                StartCoroutine("fallingGap");
                falling = false;
            }
        }

        if (gameStatus == GameStatus.PuyoArranging)
        {
            FindObjectOfType<AudioManager>().Play("placePuyo");
            PuyoController.puyoArrange();
            gameStatus = GameStatus.PuyoLinking;
        }

        if (gameStatus == GameStatus.PuyoLinking)
        {
            PuyoController.resetPuyoStatusAndLinkPuyoList();
            PuyoController.linkSamePuyo();
            gameStatus = GameStatus.ComboCalculating;
        }

        if (gameStatus == GameStatus.ComboCalculating)
        {
            if (PuyoController.readyToEliminatePuyo())
            {
                StartCoroutine("statusChangingGap");
                gameStatus = GameStatus.GamePause;
            }
            else
            {
                gameStatus = GameStatus.PuyoCreating;
            }
        }
    }

    IEnumerator fallingGap() {
        yield return new WaitForSeconds(fallingSpeed);
        //If reach the bottom, create new puyo
        if (PuyoController.reachBottom((int)controlMainPuyo.getPosition().x, (int)controlMainPuyo.getPosition().y) || 
            PuyoController.reachBottom((int)controlSubPuyo.getPosition().x, (int)controlSubPuyo.getPosition().y))
        {
            /*if (PuyoController.isGameOver())
            {
                gameOverObj.SetActive(true);
                gameStatus = GameStatus.GamePause;
            }*/
            
                int mainX = (int)controlMainPuyo.getPosition().x;
                int mainY = (int)controlMainPuyo.getPosition().y;
                int subX = (int)controlSubPuyo.getPosition().x;
                int subY = (int)controlSubPuyo.getPosition().y;
                puyoArr[mainX, mainY] = controlMainPuyo;
                puyoArr[subX, subY] = controlSubPuyo;

                gameStatus = GameStatus.PuyoArranging;
                PuyoController.eliminateRow();
        }
        else
        {
            PuyoController.puyoDown(true);
        }
        falling = true;
    }

    //Before eliminated puyo, wait a while.
    IEnumerator statusChangingGap()
    {
        yield return new WaitForSeconds(0.8f);
        StartCoroutine("showComboImg");
        ImageController.setComboNumber(++comboNumber);
        PuyoController.eliminatePuyo();
        gameStatus = GameStatus.PuyoArranging;
    }

    IEnumerator showComboImg()
    {
        ImageController.comboGameObject.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        ImageController.comboGameObject.SetActive(false);
    }
}
