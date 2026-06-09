using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // GridLayoutGroup 제어를 위해 추가

public class CardGame : MonoBehaviour
{
    [Header("Game Settings")]
    public int pairCount = 8;           // 인스펙터에서 수정할 페어 개수
    public GameObject cardPrefab;       // 카드 프리팹
    public Transform cardParent;        // 카드가 생성될 부모 (Grid Panel)

    [Header("Resources")]
    public List<Sprite> sprites;        // 카드 앞면 이미지 리스트
    public Sprite cardBackSprite;       // 카드 뒷면 이미지

    private List<Card> cards = new List<Card>(); // 동적 생성된 카드들을 담을 리스트
    private Card firstCard = null;
    private Card secondCard = null;
    private bool isChecking = false;

    void Start()
    {
        SpawnCards();
        StartGame();
    }

    // 1. 설정된 pairCount에 따라 카드를 생성하는 메서드
    private void SpawnCards()
    {
        // [추가된 안전장치] 이미지 리스트의 개수보다 페어 설정값이 크면 조절합니다.
        if (pairCount > sprites.Count)
        {
            Debug.LogWarning($"보유한 이미지({sprites.Count}개)가 설정된 페어 수({pairCount}개)보다 적습니다. 페어 수를 {sprites.Count}개로 자동 조정합니다.");
            pairCount = sprites.Count;
        }

        // 기존에 생성된 카드가 있다면 삭제 (재시작 대비)
        foreach (Transform child in cardParent)
        {
            Destroy(child.gameObject);
        }
        cards.Clear();

        int totalCards = pairCount * 2;

        for (int i = 0; i < totalCards; i++)
        {
            // 카드 생성 및 부모 설정
            GameObject go = Instantiate(cardPrefab, cardParent);
            Card cardScript = go.GetComponent<Card>();

            if (cardScript != null)
            {
                cards.Add(cardScript);
            }
        }
    }

    private void StartGame()
    {

        Soundmanager.instance.PlayBGMSound();

        // 2. 생성된 카드 개수에 맞는 랜덤 숫자 쌍 생성
        List<int> randomPairNumbers = GeneratePairNumbers(cards.Count);

        for (int i = 0; i < cards.Count; ++i)
        {
            cards[i].cardGame = this;

            // 각 카드에 정보 전달
            int numberIndex = randomPairNumbers[i];

            // 만약 이미지 리스트보다 숫자 인덱스가 크면 방어코드 작성
            Sprite front = (numberIndex < sprites.Count) ? sprites[numberIndex] : null;
            cards[i].SetCardInfo(numberIndex, front, cardBackSprite);

            cards[i].isFront = false;
        }
    }

    List<int> GeneratePairNumbers(int cardCount)
    {
        int pCount = cardCount / 2;
        List<int> newCardNumbers = new List<int>();

        for (int i = 0; i < pCount; ++i)
        {
            newCardNumbers.Add(i);
            newCardNumbers.Add(i);
        }

        // 피셔-예이츠 셔플
        for (int i = newCardNumbers.Count - 1; i > 0; i--)
        {
            int rnd = Random.Range(0, i + 1);
            int temp = newCardNumbers[i];
            newCardNumbers[i] = newCardNumbers[rnd];
            newCardNumbers[rnd] = temp;
        }

        return newCardNumbers;
    }

    // --- 이하 OnClickCard, CheckCard, HideCard 로직은 기존과 동일 ---
    public void OnClickCard(Card card)
    {
        if (isChecking || card.isFront || card.inMatched) return;

        if (firstCard == null)
        {
            firstCard = card;
            firstCard.Flip(true);
            Soundmanager.instance.PlaySound();
        }
        else
        {
            secondCard = card;
            secondCard.Flip(true);
            Soundmanager.instance.PlaySound();
            CheckCard();
        }
    }

    private void CheckCard()
    {
        isChecking = true;
        if (firstCard.cardNumber == secondCard.cardNumber)
        {
            firstCard.inMatched = true;
            secondCard.inMatched = true;
            firstCard.ChangeColor(Color.magenta);
            secondCard.ChangeColor(Color.magenta);
            firstCard = null;
            secondCard = null;
            isChecking = false;
        }
        else
        {
            Invoke("HideCard", 1.0f);
        }
    }

    private void HideCard()
    {
        if (firstCard != null) firstCard.Flip(false);
        if (secondCard != null) secondCard.Flip(false);
        firstCard = null;
        secondCard = null;
        isChecking = false;
    }
}