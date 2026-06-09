using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [Header("UI Component")]
    private Image cardImage;          // 카드 자신의 Image 컴포넌트
    public TextMeshProUGUI text;      // 자식 오브젝트인 숫자 텍스트

    [Header("Card State")]
    public int cardNumber;
    public float rotationSpeed = 10f;
    public bool isFront = false;      // 시작은 뒷면
    public bool inMatched = false;

    [Header("Sprites")]
    public Sprite frontSprite;        // 앞면 이미지 (숫자/그림 배경)
    public Sprite backSprite;         // 뒷면 이미지 (고정)

    private Quaternion flipRotation = Quaternion.Euler(0, 180f, 0);
    private Quaternion originRotation = Quaternion.Euler(0, 0, 0);

    [HideInInspector]
    public CardGame cardGame;

    void Awake()
    {
        // 카드 자체에 붙어있는 Image 컴포넌트를 가져옵니다.
        cardImage = GetComponent<Image>();
    }

    void Update()
    {
        // 1. 부드러운 회전 처리
        if (isFront)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, flipRotation, rotationSpeed * Time.deltaTime);
        }

        // 2. 현재 각도에 따라 이미지 및 텍스트 표시/숨김
        float currentY = transform.rotation.eulerAngles.y;

        // 유니티 각도 오차를 고려하여 90~270도 사이일 때를 '뒷면'으로 판정
        if (currentY > 90f && currentY < 270f)
        {
            cardImage.sprite = backSprite; // 뒷면 이미지로 변경
            if (text != null) text.gameObject.SetActive(false); // 숫자 숨김
        }
        else
        {
            cardImage.sprite = frontSprite; // 앞면 이미지로 변경
            if (text != null) text.gameObject.SetActive(true); // 숫자 표시
        }
    }

    public void ClickCard()
    {
        // 이미 맞춰진 카드거나, 다른 카드를 체크 중이면 클릭 무시
        if (!inMatched)
        {
            cardGame.OnClickCard(this);
        }
    }

    public void Flip(bool isFront)
    {
        this.isFront = isFront;
    }

    // 카드 초기 설정 (CardGame에서 호출)
    public void SetCardInfo(int newNumber, Sprite sprite, Sprite back)
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        cardNumber = newNumber;
        frontSprite = sprite;
        backSprite = back;

        if (text != null) text.text = cardNumber.ToString();
    }

    public void ChangeColor(Color newColor)
    {
        cardImage.color = newColor;
    }
}