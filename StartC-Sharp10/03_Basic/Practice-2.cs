namespace StartC_Sharp10._03_Basic;

class Test2
{
    static void Main_(string[] args)
    {
        //-----------------------------------------------// 배열 선언 및 할당(초기화) ▼

        int [] dodudo = new int[5]; // 변수 선언 시 대괄호를 사용하면 해당 변수는 배열임을 의미
        string [] ff = new string[1000];

        dodudo[0] = 100; // 배열의 시작 번호는 1이 아닌 0
        dodudo[1] = 200; // 대괄호 안의 숫자는 색인=index 라고 불림

        int A = dodudo[0]; // A = 100
        int B = dodudo[0] + dodudo[1]; // B = 300

        int [] dd = new int[5] {1, 2, 3, 4, 5}; // 배열의 요소와 개수(index)를 지정
        int [] cc = new int[] {1, 2, 3, 4, 5}; // 배열의 요소만 지정, 개수(index) 미지정(요소를 추가할수록 개수 추가)

        //-----------------------------------------------// char 형 배열 = string ▼

        string text = "Hello, World!";
        char ch1 = text[0]; // text "" 안에 들어가는 문자열중 0번 = H
        char ch2 = text[1]; // text "" 안에 들어가는 문자열중 1번 = e

        Console.WriteLine(ch1); // 출력 결과: H
        Console.WriteLine(ch2); // 출력 결과: e

        //-----------------------------------------------// 다차원 배열 ▼

        int [,] arr2 = new int[10, 5]; // 2차원 배열, 10 X 5 배열
        short [,,] arr3 = new short[8, 3, 10]; // 3차원 배열, 8 X 3 X 10 배열

        int [,] arr2_ = new int[2, 3] // 2차원 배열
        {
            {1, 2, 3}, // 1, 2, 3 = 3개짜리 배열
            {4, 5, 6}  // 3개짜리 배열이 2개 = [2, 3]
        };

        short [,,] arr3_ = new short[2, 3, 4]
        {
            {
                {1, 2, 3, 4},    // 1, 2, 3, 4 = 4개짜리 배열
                {5, 6, 7, 8},    // 4개짜리 배열이 3개 = [3, 4]
                {9, 10, 11, 12}, // 위 배열이 2개 = [2, 3, 4]
            },
            {
                {13, 14, 15, 16},
                {17, 18, 19, 20},
                {21, 22, 23, 24},
            },
        };

        //-----------------------------------------------// 가변 배열 ▼

        int [][] arr = new int[5][]; // 2차원 가변 배열, 67p 가변 배열의 할당 구조 그림
        arr[0] = new int[5]; //arr[0][0], arr[0][1], arr[0][2], arr[0][3], arr[0][4]
        arr[1] = new int[3]; //arr[1][0], arr[1][1], arr[1][2]
        arr[2] = new int[6]; //arr[2][0], arr[2][1], arr[2][2], arr[2][3], arr[2][4], arr[2][5]
        arr[3] = new int[3]; //arr[3][0], arr[3][1], arr[3][2]
        arr[4] = new int[2]; //arr[4][0], arr[4][1]
        // 위 방식대로 배열 크기를 임의로 결정 가능, 사실 가변 배열은 잘 쓰지 않음
    }
}