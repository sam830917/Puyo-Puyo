using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2KeyboardController : MonoBehaviour
{
    void Update()
    {
        if (GameMaster.gameStatus == GameMaster.GameStatus.PuyoFalling)
        {

            if (Input.GetKeyUp(KeyCode.A) && (!PuyoController.havingObstacle(0, (int)GameMaster.controlMainPuyo.getPosition().x, (int)GameMaster.controlMainPuyo.getPosition().y) &&
                                                       !PuyoController.havingObstacle(0, (int)GameMaster.controlSubPuyo.getPosition().x, (int)GameMaster.controlSubPuyo.getPosition().y)))
            {
                PuyoController.puyoLeft(true);
            }
            if (Input.GetKeyUp(KeyCode.D) && (!PuyoController.havingObstacle(1, (int)GameMaster.controlMainPuyo.getPosition().x, (int)GameMaster.controlMainPuyo.getPosition().y) &&
                                                       !PuyoController.havingObstacle(1, (int)GameMaster.controlSubPuyo.getPosition().x, (int)GameMaster.controlSubPuyo.getPosition().y)))
            {
                PuyoController.puyoRight(true);
            }
            if (Input.GetKeyUp(KeyCode.S) && (!PuyoController.reachBottom((int)GameMaster.controlMainPuyo.getPosition().x, (int)GameMaster.controlMainPuyo.getPosition().y) &&
                                                       !PuyoController.reachBottom((int)GameMaster.controlSubPuyo.getPosition().x, (int)GameMaster.controlSubPuyo.getPosition().y)))
            {
                PuyoController.puyoDown(true);
            }
            //counterclockwise
            if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.W))
            {
                PuyoController.puyoCounterclockwise();
            }
            //clockwise
            if (Input.GetKeyUp(KeyCode.X))
            {
                PuyoController.puyoClockwise();
            }
            //Hold
            /*if (Input.GetKeyUp(KeyCode.Space))
            {
                PuyoController.hold();
            }*/
        }
    }
}
