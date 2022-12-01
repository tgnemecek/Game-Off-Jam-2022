using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BoosterPack : MonoBehaviour
{
  [SerializeField]
  string[] cardPaths;
  [SerializeField]
  List<Card> _allCards;
  [SerializeField]
  Transform _mesh;
  [SerializeField]
  Vector3 _destinationForBooster;
  [SerializeField]
  Transform _destinationForCards;
  [SerializeField]
  int _numberOfCardsInBooster = 3;
  [SerializeField]
  float _boosterSpeed = 10f;
  [SerializeField]
  float _shakeStrength = 10f;
  [SerializeField]
  float _shakeSpeed = 10f;
  [SerializeField]
  float _shakeDuration = 1f;

  Quaternion _originalRotationForMesh;
  Vector3 _originalPosition;

  List<Card> _weightedList = new List<Card>();

  List<Card> _boosterCards = new List<Card>(); public List<Card> Cards => _boosterCards;


#if UNITY_EDITOR
  public void UpdateCardList()
  {
    string[] guids = AssetDatabase.FindAssets("Card_ t:GameObject", cardPaths);
    _allCards.Clear();

    foreach (var guid in guids)
    {
      var path = AssetDatabase.GUIDToAssetPath(guid);
      var go = AssetDatabase.LoadAssetAtPath<GameObject>(path);
      Card card;
      if (go.TryGetComponent<Card>(out card))
      {
        _allCards.Add(card);
      }
    }
  }
#endif

  void Awake()
  {
    _originalRotationForMesh = _mesh.rotation;
    _originalPosition = transform.position;
    PopulateWeightedList();
  }

  void OnEnable()
  {
    ResetCards();
    ResetTransform();
    StopAllCoroutines();
    ChooseCards();
    StartCoroutine(Animation());
  }

  public void ChooseCards()
  {
    Dictionary<int, bool> chosenIndexes = new Dictionary<int, bool>();

    for (int i = 0; i < _numberOfCardsInBooster; i++)
    {
      int randomIndex;
      do
      {
        randomIndex = UnityEngine.Random.Range(0, _weightedList.Count);
      } while (chosenIndexes.ContainsKey(randomIndex));

      chosenIndexes[randomIndex] = true;

      var position = new Vector3(
        _mesh.position.x,
        _mesh.position.y,
        _mesh.position.z - (.01f * i)
      );

      Card card = Instantiate(_weightedList[randomIndex], position, _mesh.rotation, transform);
      card.transform.SetParent(_mesh);
      card.Initialize(CardInitializer.BoosterPack);
      _boosterCards.Add(card);
    }
  }

  public void Disable()
  {
    StartCoroutine(GoAway());
  }

  void PopulateWeightedList()
  {
    _weightedList.Clear();

    int unitWeight = 2;

    foreach (var card in _allCards)
    {
      if (card.Type == CardTypes.Unit)
      {
        for (int i = 0; i < unitWeight; i++)
        {
          _weightedList.Add(card);
        }
      }
      else
      {
        _weightedList.Add(card);
      }
    }
  }

  void ResetTransform()
  {
    transform.position = _originalPosition;
    _mesh.transform.rotation = _originalRotationForMesh;
  }

  void ResetCards()
  {
    foreach (var card in _boosterCards)
    {
      if (card != null) Destroy(card.gameObject);
    }
    _boosterCards.Clear();
  }

  IEnumerator Animation()
  {
    yield return MoveBooster();
    yield return Shake();

    for (int i = 0; i < _boosterCards.Count; i++)
    {
      var card = _boosterCards[i];
      var tween = LeanTween
        .moveLocalY(card.gameObject, 1.2f, 2f)
        .setEaseOutCirc();

      if (i == _boosterCards.Count - 1)
      {
        tween.setOnComplete(CalculateHandPositions);
      }
    }
  }

  IEnumerator MoveBooster()
  {
    bool hasCompleted = false;
    LeanTween
        .move(gameObject, _destinationForBooster, 1f / _boosterSpeed)
        .setOnComplete(() => hasCompleted = true);

    yield return new WaitUntil(() => hasCompleted);
  }

  IEnumerator Shake()
  {
    bool isTurningToPositive = true;
    float startTime = Time.time;
    float timePassed = 0f;

    do
    {
      float rotationAmount = _shakeStrength * (isTurningToPositive ? 1 : -1);

      isTurningToPositive = !isTurningToPositive;

      bool hasCompleted = false;

      LeanTween
        .rotateZ(_mesh.gameObject, rotationAmount, 1f / _shakeSpeed)
        .setOnComplete(() => hasCompleted = true);

      timePassed += Time.time - startTime;

      yield return new WaitUntil(() => hasCompleted);
    } while (timePassed < _shakeDuration);

    bool hasReturnedToBaseRotation = false;

    LeanTween
        .rotateZ(_mesh.gameObject, 0f, 1f / _shakeSpeed)
        .setOnComplete(() => hasReturnedToBaseRotation = true);
    yield return new WaitUntil(() => hasReturnedToBaseRotation);
  }

  IEnumerator GoAway()
  {
    bool hasCompleted = false;
    LeanTween
        .move(gameObject, _originalPosition, 1f / _boosterSpeed)
        .setOnComplete(() => hasCompleted = true);

    yield return new WaitUntil(() => hasCompleted);
    gameObject.SetActive(false);
  }

  void CalculateHandPositions()
  {
    List<float> positionsX = new List<float>();
    float firstElementX = 0;
    float lastElementX = 0;

    for (int i = 0; i < _boosterCards.Count; i++)
    {
      Card card = _boosterCards[i];
      float x = i * 2f;

      if (i == 0) firstElementX = x;
      if (i == _boosterCards.Count - 1) lastElementX = x;

      if (i == 0) firstElementX = x;
      if (i == _boosterCards.Count - 1) lastElementX = x;
      positionsX.Add(x);
    }

    for (int i = 0; i < positionsX.Count; i++)
    {
      float x = positionsX[i];
      float delay = i * .2f;

      var worldPos = new Vector3(
        x + ((firstElementX - lastElementX) / 2),
        _destinationForCards.position.y,
        _destinationForCards.position.z
      );

      _boosterCards[i].SetPositionInHand(worldPos);
    }
  }
}
