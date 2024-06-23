namespace Practice._2024_05.RockPaperScissors.Initial;

public class MainApp
{
    public static void _Main(string[] args)
    {
        Random ran = new Random();
        User user = new User();
        TextManager textManager = new TextManager(user);
        
        while (true)
        {
            int aiSelect = 0;
            int select = 0;
            
            aiSelect = ran.Next(0, 3);
            textManager.Bating();
            string? userInput = Console.ReadLine();

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
                case "가위":
                case "1":
                    select = 0;
                    break;
                
                case "바위":
                case "2":
                    select = 1;
                    break;
                
                case "보":
                case "3":
                    select = 2;
                    break;
                
                case "파산":
                    select = 0;
                    user.Money = 0;
                    user.BatMoney = 0;
                    break;
                
                case "당첨":
                    select = 0;
                    user.Money = 1000000;
                    user.BatMoney = 0;
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
            
            var result = select - aiSelect;
            textManager.AiSelect();

            switch (result)
            {
                case 0:
                    textManager.Draw();
                    user.Money += user.BatMoney * 0.5;
                    break;
                
                case 1:
                case -2:
                    textManager.Victory();
                    user.Money += user.BatMoney * 2;
                    user.BatMoney = 0;
                    break;
                
                case -1:
                case 2:
                    textManager.Lose();
                    user.BatMoney = 0;
                    break;
            }
            
            if (user.Money <= 0)
            {
                textManager.Bankrupt();
                user.Money = 100000;
            }
            else if (user.Money >= 1000000)
            {
                textManager.Ending1();
                user.Money = 100000;
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
    
    public void Bating()
    {
        Console.Clear();
        Console.WriteLine("\n$ $ $ 배팅 가위바위보 $ $ $");
        Console.WriteLine("원하시는 배팅 금액을 입력해주세요.");
        Console.WriteLine("종료하시려면 '종료'를 입력해주세요.");
        Console.Write("현재 소지금: ");
        Console.WriteLine($"{_user.Money}");
    }

    public void Select()
    {
        Console.Clear();
        Console.WriteLine($"\n현재 소지금: {_user.Money}");
        Console.WriteLine($"현재 배팅금: {_user.BatMoney}");
        Console.WriteLine("1)가위, 2)바위, 3)보 중에서 하나를 선택해주세요.");
    }
    
    public void AiSelect()
    {
        Console.Clear();
        Console.Write("\n컴퓨터가 신중하게 선택하고 있습니다");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.WriteLine(".");
        Thread.Sleep(500);
        Console.Write("컴퓨터의 선택: ");
        Thread.Sleep(500);
        Console.WriteLine($"'{AiResult}'");
        Thread.Sleep(700);
    }

    public void Victory()
    {
        Console.Clear();
        Console.WriteLine("\n★ ★ ★ 승리 ★ ★ ★\n");
        Thread.Sleep(500);
        Console.WriteLine("축하드립니다!\n");
        Thread.Sleep(500);
        Console.WriteLine($"배팅하신 금액은 {_user.BatMoney}원 입니다.");
        Thread.Sleep(500);
        Console.Write("배팅금의 2배가 소지금에 추가됩니다.");
        Thread.Sleep(500);
        Console.WriteLine($" +{_user.BatMoney * 2}원\n");
        Thread.Sleep(500);
        Console.WriteLine("계속하려면 Enter를 누르세요.");
        Console.ReadLine();
    }

    public void Draw()
    {
        Console.Clear();
        Console.WriteLine("\n◆ ◆ ◆ 무승부 ◆ ◆ ◆\n");
        Thread.Sleep(500);
        Console.Write("저런");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.WriteLine(".");
        Thread.Sleep(500);
        Console.Write("안타깝게도 배팅하신 금액의 절반을 잃었습니다.");
        Thread.Sleep(500);
        Console.WriteLine($" -{_user.BatMoney * 0.5}원\n");
        Thread.Sleep(500);
        Console.WriteLine("계속하려면 Enter를 누르세요.");
        Console.ReadLine();
    }

    public void Lose()
    {
        Console.Clear();
        Console.WriteLine("\n 패배!!! You Lose!!!!!\n");
        Thread.Sleep(500);
        Console.WriteLine("'하하'");
        Thread.Sleep(500);
        Console.WriteLine("'다음 기회를 노려보세요!'");
        Thread.Sleep(500);
        Console.Write("\n배팅하신 금액을 전부 잃었습니다.");
        Thread.Sleep(500);
        Console.WriteLine($" -{_user.BatMoney}원\n");
        Thread.Sleep(500);
        Console.WriteLine("계속하려면 Enter를 누르세요.");
        Console.ReadLine();
    }

    public void Error()
    {
        Console.Clear();
        Console.WriteLine("\n올바른 값을 입력해주세요.\n");
        Thread.Sleep(500);
    }

    public void Bankrupt()
    {
        Console.Clear();
        Thread.Sleep(1000);
        Console.WriteLine($"현재 소지금: {_user.Money}");
        Thread.Sleep(1000);
        Console.Write("\n.");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.WriteLine(".");
        Thread.Sleep(500);
        Console.WriteLine("당신은 모든 소지금을 잃어 파산 했습니다.");
        Thread.Sleep(1000);
        Console.WriteLine("당신은 기억을 잃었습니다");
        Thread.Sleep(1000);
        Console.WriteLine("잃은 돈이 없던 기분이 듭니다");
        Thread.Sleep(1000);
        Console.WriteLine("모든 기억을 잃고 처음으로 돌아갑니다.");
        Thread.Sleep(1000);
    }

    public void Ending1()
    {
        Console.Clear();
        Thread.Sleep(1000);
        Console.Write(".");
        Thread.Sleep(1000);
        Console.Write(".");
        Thread.Sleep(1000);
        Console.WriteLine(".");
        Thread.Sleep(1000);
        Console.WriteLine("월세가 없어 항상 고개 숙여야했던 당신은");
        Thread.Sleep(3000);
        Console.WriteLine("미친 배팅 실력으로 많은 돈을 얻었습니다.");
        Thread.Sleep(3000);
        Console.WriteLine("당신은 당당히 월세를 지불했고, 집주인에게 신뢰를 회복했습니다.");
        Thread.Sleep(3000);
        Console.WriteLine("이제 당신의 삶을 즐기십시오.");
        Thread.Sleep(3000);
        Console.WriteLine("\n계속하려면 Enter를 누르세요.");
        Console.ReadLine();

        Console.Clear();
        Thread.Sleep(1000);
        Console.WriteLine("당신은 도박에 빠져 방탕한 나날을 보내다");
        Thread.Sleep(3000);
        Console.Write("달려오는 차를 미처 피하지 못하고 사고를 당했습니다");
        Thread.Sleep(3000);
        Console.Write(".");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);;
        Console.WriteLine(".");
        Thread.Sleep(2000);
        Console.WriteLine("당신은 기억을 잃었습니다");
        Thread.Sleep(3000);
        Console.WriteLine("사실은 이게 현실이었을지도 모릅니다");
        Thread.Sleep(3000);
        Console.WriteLine("모든 기억을 잃고 처음으로 돌아갑니다.");
        Thread.Sleep(3000);
        Console.WriteLine("\n계속하려면 Enter를 누르세요.");
        Console.ReadLine();

        Console.Clear();
        Thread.Sleep(1000);
        Console.WriteLine("당신의 삶으로 돌아가세요.");
        Thread.Sleep(1000);
    }
}