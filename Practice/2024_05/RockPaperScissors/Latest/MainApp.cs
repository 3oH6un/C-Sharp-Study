using System.Xml.Serialization;

namespace Practice._2024_05.RockPaperScissors.Latest;

public class MainApp
{
    static void Main()
    {
        TextManager textManager = new TextManager();
        textManager.StartProgram();

        while (true)
        {
            textManager.PrintMain();

            var userInput = textManager.GetUserInput();
            textManager.SelectBatMoney(userInput);
            textManager.PlayerSelect();
            textManager.BranchResult();
        }
    }
}

public class TextManager
{
    private Processing _processing = new Processing();
    
    public string GetUserInput()
    {
        var userInput = Console.ReadLine();
        userInput = userInput ?? "";
        return userInput.Trim();
    }
    
    public void StartProgram()
    {
        _processing.ResetMoney();
    }
    
    public void PrintMain()
    {
        Console.Clear();
        Console.WriteLine("$$$ 배팅 가위바위보 $$$");
        Console.WriteLine("원하시는 배팅 금액을 입력해주세요.");
        Console.WriteLine("종료하시려면 '종료'를 입력해주세요.");
        Console.Write($"현재 소지금: {_processing.GetPlayerMoney()}\n");
    }

    public void SelectBatMoney(string userInput)
    {
        while (_processing.CheckForEmpty(userInput) == -1)
        {
            Error();
            userInput = GetUserInput();
        }

        int batMoney = Convert.ToInt32(userInput);
        
        while (batMoney > _processing.GetPlayerMoney())
        {
            Error();
            batMoney = Convert.ToInt32(GetUserInput());
        }
        
        _processing.SaveBatMoney(batMoney);
    }
    
    public int PlayerSelect()
    {
        Console.Clear();
        Console.WriteLine($"현재 소지금: {_processing.GetPlayerMoney()}");
        Console.WriteLine($"현재 배팅금: {_processing.GetPlayerBatMoney()}");
        Console.WriteLine("1)가위, 2)바위, 3)보 중에서 하나를 선택해주세요.");
        int userInput = _processing.SelectCase(GetUserInput());
        
        while (userInput == -1)
        {
            Error();
            userInput = _processing.SelectCase(GetUserInput());
        }

        if (userInput == 3)
        {
            Bankrupt();
        }
        
        else if (userInput == 4)
        {
            Ending1();
            _processing.ResetMoney();
            _processing.ResetBatMoney();
        }

        return userInput;
    }

    private void PrintAiSelect()
    {
        _processing.ResetAiSelect();
        Console.Clear();
        Console.Write("컴퓨터가 신중하게 선택하고 있습니다");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.WriteLine(".");
        Thread.Sleep(500);
        Console.Write("컴퓨터의 선택: ");
        Thread.Sleep(500);
        Console.WriteLine($"'{_processing.AiSelectToString()}'");
        Thread.Sleep(700);
    }

    public void BranchResult()
    {
        PrintAiSelect();
        var result = _processing.ResultCase(_processing.GetPlayerSelect(), _processing.GetAiSelect());
        
        switch (result)
        {
            case 0:
                Draw();
                break;

            case 1:
            case -2:
                Victory();
                break;

            case -1:
            case 2:
                Lose();
                break;
        }

        if (_processing.GetPlayerMoney() <= 0)
        {
            Bankrupt();
            _processing.ResetMoney();
            _processing.ResetBatMoney(); 
        }

        if (_processing.GetPlayerMoney() >= 1000000)
        {
            Ending1();
            _processing.ResetMoney();
            _processing.ResetBatMoney(); 
        }

        _processing.ResetBatMoney();
    }

    private void Victory()
    {
        Console.Clear();
        Console.WriteLine("★ ★ ★ 승리 ★ ★ ★\n");
        Thread.Sleep(500);
        Console.WriteLine("축하드립니다!\n");
        Thread.Sleep(500);
        Console.WriteLine($"배팅하신 금액은 {_processing.GetPlayerBatMoney()}원 입니다.");
        Thread.Sleep(500);
        Console.Write("배팅금의 2배가 소지금에 추가됩니다.");
        Thread.Sleep(500);
        Console.WriteLine($" +{_processing.GetPlayerBatMoney() * 2}원\n");
        Thread.Sleep(500);
        Console.WriteLine("계속하려면 Enter를 누르세요.");
        Console.ReadLine();
    }

    private void Draw()
    {
        Console.Clear();
        Console.WriteLine("◆ ◆ ◆ 무승부 ◆ ◆ ◆\n");
        Thread.Sleep(500);
        Console.Write("저런");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.WriteLine(".");
        Thread.Sleep(500);
        Console.Write("안타깝게도 배팅하신 금액의 절반을 잃었습니다.");
        Thread.Sleep(500);
        Console.WriteLine($" -{_processing.GetPlayerBatMoney() * 0.5}원\n");
        Thread.Sleep(500);
        Console.WriteLine("계속하려면 Enter를 누르세요.");
        Console.ReadLine();
    }

    private void Lose()
    {
        Console.Clear();
        Console.WriteLine("패배!!! You Lose!!!!!\n");
        Thread.Sleep(500);
        Console.WriteLine("'하하'");
        Thread.Sleep(500);
        Console.WriteLine("'다음 기회를 노려보세요!'");
        Thread.Sleep(500);
        Console.Write("\n배팅하신 금액을 전부 잃었습니다.");
        Thread.Sleep(500);
        Console.WriteLine($" -{_processing.GetPlayerBatMoney()}원\n");
        Thread.Sleep(500);
        Console.WriteLine("계속하려면 Enter를 누르세요.");
        Console.ReadLine();
    }

    private void Bankrupt()
    {
        Console.Clear();
        Thread.Sleep(1000);
        Console.WriteLine($"현재 소지금: {_processing.GetPlayerMoney()}");
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

    private void Ending1()
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

    private void Error()
    {
        Console.WriteLine("올바른 값을 입력해주세요.");
    }
}

public class Processing
{
    private DataBase _playerData = new DataBase();

    public void SaveBatMoney(int batMoney)
    {
        Player player = new Player();
        player.SetBatMoney(batMoney);
        _playerData.SavePlayerData(player);
    }
    
    public void ResetMoney()
    {
        Player player = _playerData.GetPlayerData();
        player.SetMoney(100000);
        _playerData.SavePlayerData(player);
    }
    
    public void ResetBatMoney()
    {
        Player player = _playerData.GetPlayerData();
        player.SetBatMoney(0);
        _playerData.SavePlayerData(player);
    }

    public void ResetAiSelect()
    {
        Random ran = new Random();
        _playerData.SaveAiSelect(ran.Next(3));
    }
    
    public int GetPlayerMoney()
    {
        return _playerData.GetPlayerData().GetMoney();
    }
    
    public int GetPlayerBatMoney()
    {
        return _playerData.GetPlayerData().GetBatMoney();
    }

    public int GetPlayerSelect()
    {
        return _playerData.GetPlayerData().GetSelect();
    }

    public int GetAiSelect()
    {
        return _playerData.GetAiSelect();
    }

    public string AiSelectToString()
    {
        string aiSelect = "";
        
        switch (_playerData.GetAiSelect())
        { 
            case 0:
                aiSelect = "가위";
                break;
            
            case 1:
                aiSelect = "바위";
                break;
            
            case 2:
                aiSelect = "보";
                break;
        }
        return aiSelect;
    }
    
    public int ResultCase(int playerSelect, int aiSelect)
    {
        Player player = _playerData.GetPlayerData();
        var batMoney = player.GetBatMoney();
        var result = playerSelect - aiSelect;
        
        switch (result)
        {
            case 0:
                player.SetMoney(Convert.ToInt32(batMoney * 0.5));
                break;
                
            case 1:
            case -2:
                player.SetMoney(batMoney * 2);
                break;
                
            case -1:
            case 2:
                player.SetMoney(batMoney * 0);
                break;
        }
        
        _playerData.SavePlayerData(player);
        return result;
    }

    public int SelectCase(string userInput)
    {
        Player player = _playerData.GetPlayerData();
        int select;
        
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
                select = 3;
                player.SetMoney(0);
                player.SetBatMoney(0);
                break;
            
            case "당첨":
                select = 4;
                player.SetMoney(1000000);
                player.SetBatMoney(0);
                break;
            
            default:
                select = -1;
                break;
        }
        
        _playerData.SavePlayerData(player);
        return select;
    }
    
    public int CheckForEmpty(string text)
    {
        return string.IsNullOrEmpty(text) ? -1 : 0;
    }
}

public class DataBase
{
    private Player _playerData = new Player();
    private int _aiSelect;

    public Player GetPlayerData()
    {
        return _playerData;
    }
    
    public void SavePlayerData(Player player)
    {
        _playerData = player;
    }
    
    public int GetAiSelect()
    {
        return this._aiSelect;
    }
    
    public void SaveAiSelect(int num)
    {
        this._aiSelect = num;
    }
}

public class Player
{
    private int _money;
    private int _batMoney;
    private int _select;

    public int GetMoney()
    {
        return this._money;
    }
    
    public void SetMoney(int num)
    {
        this._money = num;
    }
    
    public int GetBatMoney()
    {
        return this._batMoney;
    }

    public void SetBatMoney(int num)
    {
        this._batMoney = num;
    }
    
    public int GetSelect()
    {
        return this._select;
    }
    
    public void SetSelect(int num)
    {
        this._select = num;
    }
}