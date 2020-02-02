using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1KeyboardController : MonoBehaviour
{
    void Update () {
        if (GameMaster.gameStatus==GameMaster.GameStatus.PuyoFalling)
        {

            if (Input.GetKeyDown(KeyCode.LeftArrow) && (!PuyoController.havingObstacle(0, (int)GameMaster.controlMainPuyo.getPosition().x, (int)GameMaster.controlMainPuyo.getPosition().y) &&
                                                       !PuyoController.havingObstacle(0, (int)GameMaster.controlSubPuyo.getPosition().x, (int)GameMaster.controlSubPuyo.getPosition().y)))
            {
                FindObjectOfType<AudioManager>().Play("move");
                PuyoController.puyoLeft(true);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && (!PuyoController.havingObstacle(1, (int)GameMaster.controlMainPuyo.getPosition().x, (int)GameMaster.controlMainPuyo.getPosition().y) &&
                                                       !PuyoController.havingObstacle(1, (int)GameMaster.controlSubPuyo.getPosition().x, (int)GameMaster.controlSubPuyo.getPosition().y)))
            {
                FindObjectOfType<AudioManager>().Play("move");
                PuyoController.puyoRight(true);
            }
            if (Input.GetKey(KeyCode.DownArrow) && (!PuyoController.reachBottom((int)GameMaster.controlMainPuyo.getPosition().x, (int)GameMaster.controlMainPuyo.getPosition().y) &&
                                                       !PuyoController.reachBottom((int)GameMaster.controlSubPuyo.getPosition().x, (int)GameMaster.controlSubPuyo.getPosition().y)))
            {
                FindObjectOfType<AudioManager>().Play("move");
                PuyoController.puyoDown(true);
            }
            //counterclockwise
            if (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                PuyoController.puyoCounterclockwise();
                FindObjectOfType<AudioManager>().Play("rotate");
            }
            //clockwise
            if (Input.GetKeyUp(KeyCode.X))
            {
                PuyoController.puyoClockwise();
                FindObjectOfType<AudioManager>().Play("rotate");
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                //test key
                FindObjectOfType<AudioManager>().Play("placePuyo");
            }
        }
    }
}
