using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int age = 0;
        float height = 177.5f;
        string name = "헨리";
        bool isMale = false;

        age = 22;
        height = 175.5f;
        name = "신구";
        isMale = true;

        age = age + 1;
        age = age - 1;
        age = age * 2;
        age = age / 2;

        age += 1;
        age -= 1;
        age *= 1;
        age /= 1;

        int number = 100;
        number = (number + 10) / 30;

        int hp = 100;

        if (hp < 0)
        {
            //몬스터 죽음
        }
        else
        {
            //살아있음
        }

        Debug.Log(Test(10, 10, true));


    }

    void Function(int left, int right)
    {
        
    }

    int GetBigger(int left, int right)
    {
        if (left > right)
        {
            return left;
        }
        else
        {
            return right;
        }
            
    }

    int Function1(int left, int right)
    {
        return 0;
    }

    int Plus(int left, int right)
    {
        return left + right;
    }

    int Minus(int left, int right)
    {
        return left - right;
    }
    float Divide(float left, float right)
    {
        return left / right;
    }
    float Multiply(float left, float right)
    {
        return left * right;
    }

    int Test(int left, int right, bool c)
    {
        if (c = true)
        {
            return left + right;
        }
        else
        {
            return left - right;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
