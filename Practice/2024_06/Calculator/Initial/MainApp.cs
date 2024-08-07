﻿namespace Practice._2024_06.Calculator.Initial;

public class MainApp
{
    public static void _Main(string[] args)
    {
        TextManager textManager = new TextManager();

        while (true)
        {
            textManager.StartProgram();
            string userInput = textManager.GetUserInput();

            if (userInput == "종료")
            {
                textManager.ExitProgramForSecond(1);
                break;
            }

            else
            {
                textManager.PrintResult(userInput);
            }
        }
    }
}

public class TextManager
{
    private Processing _proceesing = new Processing();

    public string GetUserInput()
    {
        string? userInput = Console.ReadLine();
        userInput = userInput ?? "";
        return userInput.Trim();
    }

    public void StartProgram()
    {
        Console.Clear();
        Console.WriteLine("### 계산기 기능 테스트 ###");
        Console.WriteLine("기능: +, -, *, /   ex)1+2, 3*4");
        Console.WriteLine("계산하실 수식을 아래에 입력해주세요.");
    }

    public void PrintResult(string text)
    {
        while (_proceesing.CheckForEmpty(text) == 1)
        {
            text = EmptyInput();
        }

        int result = _proceesing.SplitInput(text);
        Console.WriteLine($"\n결과: {result}");
        AfterPrint();
    }

    private void AfterPrint()
    {
        Console.WriteLine("처음으로 돌아가시려면 Enter 키를 눌러주세요.");
        GetUserInput();
        Console.Clear();
    }

    private string EmptyInput()
    {
        StartProgram();
        Console.WriteLine("입력된 값이 없습니다.");
        var text = GetUserInput();
        return text;
    }

    private string EmptySymbol()
    {
        StartProgram();
        Console.WriteLine("입력된 기호가 없습니다.");
        var text = GetUserInput();
        return text;
    }

    public void ExitProgramForSecond(int time)
    {
        Console.WriteLine($"\n{time}초 뒤 테스트를 중단합니다.");
        var timescale = time * 1000;
        Thread.Sleep(timescale);
    }
}

public class Processing
{
    private int GetResult(int a, int b, string symbol)
    {
        int result = 0;

        switch (symbol)
        {
            case "+":
                result = Calculator.Plus(a, b);
                break;
            case "-":
                result = Calculator.Minus(a, b);
                break;
            case "*":
                result = Calculator.Mul(a, b);
                break;
            case "/":
                result = Calculator.Div(a, b);
                break;
        }

        return result;
    }

    public int SplitInput(string text)
    {
        string[] symbols = ["+", "-", "*", "/"];
        string symbol = "";
        int a = 0;
        int b = 0;
        
        foreach (string sym in symbols)
        {
            if (text.Contains(sym))
            {
                symbol = sym;
                string[] num = text.Split($"{sym}");
                a = int.Parse(num[0].Trim());
                b = int.Parse(num[1].Trim());
            }
        }

        return GetResult(a, b, symbol);
    }

    public int CheckForEmpty(string text) //빈 입력값 확인 메서드
    {
        return string.IsNullOrEmpty(text) ? 1 : 0;
    }
}

public static class Calculator
{
    public static int Plus(int a, int b)
    {
        return a + b;
    }

    public static int Minus(int a, int b)
    {
        return a - b;
    }

    public static int Mul(int a, int b)
    {
        return a * b;
    }

    public static int Div(int a, int b)
    {
        return a / b;
    }
}