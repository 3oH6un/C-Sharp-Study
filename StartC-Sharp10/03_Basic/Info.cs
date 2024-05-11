namespace StartC_Sharp10._03_Basic;

class Info
{
    static void _Main(string[] args)
    {
        //----------------------------------------------------//

        // 식별자의 시작 문자에는 유일하게 _(밑줄, underscore)만 사용가능
        int _n = 5;
        
        // 값 = 리터럴. "Hello World", 5, 'n', true 모두 리터럴에 해당
        string text = "Hello World";
        int n = 5;
        char ch = 'n';
        bool result = true;

        Console.WriteLine(_n);
        Console.WriteLine(text, n, ch, result);

        //----------------------------------------------------//
    }
}