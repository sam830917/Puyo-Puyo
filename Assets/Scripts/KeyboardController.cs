using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    [SerializeField]
    private LeftKey;

    void Update () {
        if (GameMaster.gameStatus==GameMaster.GameStatus.PuyoFalling)
        {

            if (Input.GetKeyUp(KeyCode.LeftArrow) && (!PuyoController.havingObstacle(0, (int)GameMaster.controlMainPuyo.getPosition().x, (int)GameMaster.controlMainPuyo.getPosition().y) &&
                                                       !PuyoController.havingObstacle(0, (int)GameMaster.controlSubPuyo.getPosition().x, (int)GameMaster.controlSubPuyo.getPosition().y)))
            {
                PuyoController.puyoLeft(true);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) && (!PuyoController.havingObstacle(1, (int)GameMaster.controlMainPuyo.getPosition().x, (int)GameMaster.controlMainPuyo.getPosition().y) &&
                                                       !PuyoController.havingObstacle(1, (int)GameMaster.controlSubPuyo.getPosition().x, (int)GameMaster.controlSubPuyo.getPosition().y)))
            {
                PuyoController.puyoRight(true);
            }
            if (Input.GetKeyUp(KeyCode.DownArrow) && (!PuyoController.reachBottom((int)GameMaster.controlMainPuyo.getPosition().x, (int)GameMaster.controlMainPuyo.getPosition().y) &&
                                                       !PuyoController.reachBottom((int)GameMaster.controlSubPuyo.getPosition().x, (int)GameMaster.controlSubPuyo.getPosition().y)))
            {
                PuyoController.puyoDown(true);
            }
            //counterclockwise
            if (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.UpArrow))
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
