using UnityEngine;

public class ObjectOriented : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Human man = new Human();
        man.name = "신구";
        man.age = 20;
        man.height = 180.5f;
        man.kg = 70.2f;
        man.HP = 100;

        Human man2 = new Human();
        man2.name = "대학생";
        man2.age = 23;
        man2.height = 170.5f;
        man2.kg = 68.2f;
        man2.HP = 100;

        man.Introduce();
        man2.Introduce();

        man.Attack(man2);

        Debug.Log(man2.HP);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Human
{
    public string name;
    public float height;
    public float kg;
    public int age;
    public int HP;

    public void Walk()
    {
        Debug.Log("걷기");
    }

    public void Eat()
    {
        Debug.Log("먹기");
    }

    public void Introduce()
    {
        Debug.Log("안녕하세요. 제 이름은 :" + name + " 입니다.");
    }
    public void Attack(Human target)
    {
        target.HP = target.HP -5;
    }


}
