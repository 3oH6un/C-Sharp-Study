using System.Data.SqlTypes;
using System.Diagnostics;
using System.Dynamic;
using Practice._240522;

namespace Practice._240526;

public class MainApp
{
    public static void Main(string[] args)
    {
        string userInput = "";
        
        Random ran = new Random();
        User user = new User();
        TextManager textManager = new TextManager(user);
        
        while (userInput != "종료")
        {
            int aiSelect = 0;
            int select = 0;
            
            aiSelect = ran.Next(0, 3);
            textManager.Bating();
            userInput = Console.ReadLine();

            if (user.Money < Convert.ToDouble(userInput))
            {
                textManager.Error();
                continue;
            }
            
            user.BatMoney = Convert.ToDouble(userInput);
            user.Money -= user.BatMoney;
            textManager.Select();
            userInput = Console.ReadLine();
            
            switch (userInput)
            {
                case "종료":
                    return;
                
                case "가위":
                    select = 0;
                    break;
                
                case "바위":
                    select = 1;
                    break;
                
                case "보":
                    select = 2;
                    break;
            }
            
            switch (aiSelect)
            {
                case 0:
                    textManager.AiResult = "가위";
                    break;
                
                case 1:
                    textManager.AiResult = "바위";
                    break;
                
                case 2:
                    textManager.AiResult = "보";
                    break;
            }
            
            textManager.AiSelect();
            var result = select - aiSelect;
            
            if (result == 0)
            {
                textManager.Draw();
                user.Money += user.BatMoney * 0.5;
            }
            else if (result == 1 || result == -2)
            {
                textManager.Victory();
                user.Money += user.BatMoney * 2;
                user.BatMoney = 0;
            }
            else
            {
                textManager.Lose();
                user.BatMoney = 0;
            }
        }
    }
}

public class User
{
    public double Money { get; set; } = 100000;
    public double BatMoney { get; set; } = 0;
}

public class TextManager
{
    public string AiResult { get; set; }
    private User _user;

    public TextManager(User user)
    {
        _user = user;
    }
    
    public void AiSelect()
    {
        Console.Write("\n컴퓨터가 신중하게 선택하고 있습니다");
        Thread.Sleep(1000);
        Console.Write(".");
        Thread.Sleep(1000);
        Console.Write(".");
        Thread.Sleep(1000);
        Console.WriteLine(".");
        Thread.Sleep(1000);
        Console.Write("컴퓨터의 선택: ");
        Thread.Sleep(800);
        Console.WriteLine($"'{AiResult}'");
        Thread.Sleep(1000);
    }
    
    public void Bating()
    {
        Console.WriteLine("\n$ $ $ 배팅 가위바위보 $ $ $");
        Console.WriteLine("원하시는 배팅 금액을 입력해주세요.");
        Console.WriteLine("종료하시려면 '종료'를 입력해주세요.");
        Console.Write("현재 소지금: ");
        Console.WriteLine($"{_user.Money}");
    }

    public void Select()
    {
        Console.WriteLine($"\n현재 배팅금: {_user.BatMoney}");
        Console.WriteLine("가위, 바위, 보 중에서 하나를 선택해주세요.");
    }

    public void Victory()
    {
        Console.WriteLine("\n★★★ 승 리 ★★★\n");
        Thread.Sleep(1500);
        Console.WriteLine("축하드립니다!\n");
        Thread.Sleep(1000);
        Console.WriteLine($"배팅하신 금액은 {_user.BatMoney}원 입니다.");
        Thread.Sleep(1000);
        Console.Write("배팅금의 2배가 소지금에 추가됩니다.");
        Thread.Sleep(1000);
        Console.WriteLine($" +{_user.BatMoney * 1.5}원\n");
        Thread.Sleep(1500);
    }

    public void Draw()
    {
        Console.WriteLine("\n◆◆◆ 무 승 부 ◆◆◆\n");
        Thread.Sleep(1500);
        Console.Write("저런");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.WriteLine(".");
        Thread.Sleep(1000);
        Console.Write("안타깝게도 배팅하신 금액의 절반을 잃었습니다.");
        Thread.Sleep(1000);
        Console.WriteLine($" -{_user.BatMoney * 0.5}원\n");
        Thread.Sleep(1500);
    }

    public void Lose()
    {
        Console.WriteLine("\n 패 배   You Lose!!!!!\n");
        Thread.Sleep(1500);
        Console.WriteLine("'하하'");
        Thread.Sleep(500);
        Console.WriteLine("'다음 기회를 노려보세요!'");
        Thread.Sleep(1500);
        Console.Write("\n배팅하신 금액을 전부 잃었습니다.");
        Thread.Sleep(1000);
        Console.WriteLine($" -{_user.BatMoney}원\n");
        Thread.Sleep(1500);
    }

    public void Error()
    {
        Console.WriteLine("\n올바른 값을 입력해주세요.\n");
        Thread.Sleep(500);
    }
}