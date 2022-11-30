using System.Collections;
using UnityEngine;

public class Card_Building : Card_Base, ICardEndOfTurn
{
  public Card_Building()
  {
    this.Type = CardTypes.Building;
  }
  public override bool Drag(Camera camera)
  {
    return base.SnapToBoard(camera);
  }
  public override CardState OnConsume() => _stateFactory.InBoard();

  public virtual IEnumerator EndOfTurn()
  {
    bool isTurningToPositive = true;
    const int timesToComplete = 10;
    int timesCompleted = 0;
    float timeToRotate = .1f;

    float initRotation = transform.rotation.eulerAngles.y;

    base.CardLayerController.ToggleHoverOutline(true);
    base.CardAudio.PlayEndOfTurn();

    while (timesCompleted < timesToComplete)
    {
      float rotationAmount = 10f * (isTurningToPositive ? 1 : -1);

      isTurningToPositive = !isTurningToPositive;

      bool hasCompletedLoop = false;

      LeanTween
        .rotateY(gameObject, rotationAmount, timeToRotate)
        .setOnComplete(() => hasCompletedLoop = true);

      yield return new WaitUntil(() => hasCompletedLoop);
      timesCompleted += 1;
    }

    bool hasReturnedToOriginalRotation = false;
    LeanTween
      .rotateY(gameObject, initRotation, timeToRotate)
      .setOnComplete(() => hasReturnedToOriginalRotation = true);

    base.CardLayerController.ToggleHoverOutline(false);
    yield return new WaitUntil(() => hasReturnedToOriginalRotation);
  }
}
