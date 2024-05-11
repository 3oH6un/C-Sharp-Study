namespace StartC_Sharp10._03_Basic;

class Test1
{
    static void Main_(string[] args)
    {
        //-----------------------------------------------// 선언 및 할당(초기화) ▼

        int a1 = 225; // 선언과 동시에 할당
        int a2; // 선언 먼저하고
        a2 = 775; // 그 후에 할당

        long printtext = a1 + a2; // a1, a2를 더한 값을 'printtext'에 저장

        Console.WriteLine(printtext); // 출력 결과: 1000

        //-----------------------------------------------// 실수형 기본 타입 ▼

        float f = 5.2f; // 4바이트 단정도? 실수로도 가능할 때 float, f붙이기
        double d = 10.5; // 소수점이 있는 연산식에는 일반적으로 double
        decimal money = 200.099m; // 반올림 오차가 허용되지않을 때는 decimal, m붙이기

        Console.WriteLine(f); // 출력 결과: 5.2
        Console.WriteLine(d); // 출력 결과: 10.5
        Console.WriteLine(money); // 출력 결과: 200.099

        //-----------------------------------------------// 익스케이프 시퀸스 ▼

        char ch1 = '\t'; // TAB 들여쓰기
        char ch2 = 'A';
        char ch3 = '\n'; // 개행(New line, 다음줄)
        char ch4 = 'B';

        Console.WriteLine(ch1); // 출력 결과: 들여쓰기(공백)
        Console.WriteLine(ch2); // 출력 결과:       A
        Console.WriteLine(ch3); // 출력 결과: 다음줄로 넘어가기
        Console.WriteLine(ch4); // 출력 결과: B

        //-----------------------------------------------// 명시적 변환 ▼

        ushort u = 65;
        char c = (char)u; // ushort 에서 char 로 형변환 불가. 명시적 변환으로 강제 변환
        Console.WriteLine(c); // 출력 결과: A

        int t = 40000;
        short s = (short)t; // 마찬가지로 명시적 변환. 큰 타입에서 작은 타입으로 강제 변환
        Console.WriteLine(s); // 출력 결과: -25536

        //-----------------------------------------------// 연산자, 문장 부호, 대입 연산자 ▼

        string text = "Hello, ";
        text = text + "World!"; // 대입 연산 text + "World!" > "hello, " + "World!"

        Console.WriteLine(text); // 출력 결과: Hello, World!

        //-----------------------------------------------// 나머지 연산자 ▼

        int n = 5; // n에 5할당
        int player = 3; // player에 3할당
        int result = n % player; // result = n 나머지 연산 player. %는 나누고 난 후 나머지값을 구한다

        Console.WriteLine(result); // 출력 결과: 2

        //-----------------------------------------------// 자료형(string) 더하기 연산 ▼

        int aa = 500;
        
        Console.WriteLine("aa = " + aa); // 출력 결과: aa = 500. string 자료형에 + 연산 가능

        //-----------------------------------------------//
    }
}
