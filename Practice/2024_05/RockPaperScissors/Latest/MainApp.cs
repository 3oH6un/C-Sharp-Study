using Practice._2024_05.PUBG_Dictionary.Initial;

namespace Practice._2024_05.RockPaperScissors.Latest;

public class MainApp
{
    static void _Main()
    {
        TextManager textManager = new TextManager();
        while (true)
        {
            textManager.PrintMain();
            var userInput = textManager.GetUserInput();

            if (userInput == "종료")
            {
                break;
            }
            
            if (userInput == "재시작")
            {
                textManager.ReStart();
                textManager = new TextManager();
                continue;
            }
            
            textManager.PlayerBating(userInput); 
            textManager.PlayerSelect(); 

            if (textManager.GameReset() == 1)
            {
                textManager = new TextManager();
                continue;
            }
            
            textManager.AiBating();
            textManager.AiSelect();
            textManager.Result();
        }
    }
}

// @@@@@@@@@@@@@@@@@@@
// @@@@@입출력 관리@@@@@
// @@@@@@@@@@@@@@@@@@@
public class TextManager
{
    private Processing _processing;
    private int _count;
    
    public TextManager()
    {
        _processing = new Processing();
        _count = 0;
    }

    public int GameReset()
    {
        return _count;
    }
    
    public string GetUserInput()
    {
        var userInput = Console.ReadLine();
        userInput = userInput ?? "";
        return userInput.Trim();
    }
    
    public void PrintMain()
    {
        Console.Clear();
        Console.WriteLine("$$$ 배팅 가위바위보 $$$");
        Console.WriteLine("원하시는 배팅 금액을 입력해주세요.");
        Console.WriteLine("종료하시려면 '종료'를 입력해주세요.");
        Console.Write($"현재 소지금: {_processing.GetPlayerMoney()}\t상대방 소지금: {_processing.GetAiMoney()}\n");
    }

    public void ReStart()
    {
        Console.Clear();
        Console.WriteLine("게임을 재시작합니다.");
        Thread.Sleep(500);
        Console.Clear();
        Thread.Sleep(500);
    }

    public void PlayerBating(string userInput)
    {
        while (_processing.CheckForInput(userInput))
        {
            Error();
            userInput = GetUserInput();
        }
        
        _processing.SavePlayerBatMoney(Convert.ToInt32(userInput));
    }
    
    public int PlayerSelect()
    {
        Console.Clear();
        Console.WriteLine($"현재 소지금: {_processing.GetPlayerMoney()}");
        Console.WriteLine($"현재 배팅금: {_processing.GetPlayerBatMoney()}");
        Console.WriteLine("1)가위, 2)바위, 3)보 중에서 하나를 선택해주세요.");
        _processing.SelectCase(GetUserInput());
        
        while (_processing.GetPlayerSelect() == -1)
        {
            Error();
            _processing.SelectCase(GetUserInput());
        }
        
        if (_processing.GetPlayerSelect() == 3)
        {
            PlayerBankrupt();
            _count = 1;
        }
        
        else if (_processing.GetPlayerSelect() == 4)
        {
            PlayerEnding();
            _count = 1;
        }
        
        else if (_processing.GetPlayerSelect() == 5)
        {
            AiBankrupt();
            _count = 1;
        }
        
        else if (_processing.GetPlayerSelect() == 6)
        {
            AiEnding();
            _count = 1;
        }

        return _processing.GetPlayerSelect();
    }

    public void AiBating()
    {
        Debug(); //
        _processing.AiBating();
        Console.Clear();
        Console.Write("상대방이 배팅하고 있습니다");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.WriteLine(".");
        Thread.Sleep(500);
        Console.Write("상대방의 배팅금: ");
        Thread.Sleep(500);
        Console.WriteLine($"{_processing.GetAiBatMoney()}");
        Thread.Sleep(750);
        if (_processing.GetAiMoney() == _processing.GetAiBatMoney())
        {
            Console.Write(">>>>>>>> 올 인 <<<<<<<<");
        }
    }

    public void AiSelect()
    {
        _processing.AiSelect();
        Console.Write("상대방이 신중하게 선택하고 있습니다");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.WriteLine(".");
        Thread.Sleep(500);
        Console.Write("상대방의 선택: ");
        Thread.Sleep(500);
        Console.WriteLine($"'{_processing.AiSelectToString()}'");
        Thread.Sleep(750);
    }

    public void Result()
    {
        int playerSelect = _processing.GetPlayerSelect();
        int aiSelect = _processing.GetAiSelect();
        var result = _processing.GetResult(playerSelect: playerSelect, aiSelect: aiSelect);
        
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
            
            case 3:
                Error();
                break;
        }

        if (_processing.GetPlayerMoney() <= 0)
        {
            PlayerBankrupt();
            _count = 1;
        }

        if (_processing.GetPlayerMoney() >= 1000000)
        {
            PlayerEnding();
            _count = 1;
        }

        if (_processing.GetAiMoney() <= 0)
        {
            AiBankrupt();
            _count = 1;
        }
        
        if (_processing.GetAiMoney() >= 1000000)
        {
            AiEnding();
            _count = 1;
        }
    }

    private void Debug()
    {
        Console.WriteLine($"AiMoney: {_processing.GetAiMoney()}");
        Console.WriteLine($"AiBatMoney: {_processing.GetAiBatMoney()}");
    }
    
    private void Victory()
    {
        Console.Clear();
        Console.WriteLine("★★★ 승리 ★★★\n");
        Thread.Sleep(500);
        Console.WriteLine("축하드립니다!\n");
        Thread.Sleep(500);
        Console.WriteLine($"배팅하신 금액은 {_processing.GetPlayerBatMoney()}원 입니다.");
        Thread.Sleep(750);
        Console.Write("배팅금의 2배가 소지금에 추가됩니다.");
        Thread.Sleep(500);
        Console.WriteLine($" +{_processing.GetPlayerBatMoney() * 2}원\n");
        Thread.Sleep(500);
        AfterPrint();
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
        AfterPrint();
    }

    private void Lose()
    {
        Console.Clear();
        Console.WriteLine("패배!!! You Lose!!!!!\n");
        Thread.Sleep(500);
        Console.WriteLine("'하하'");
        Thread.Sleep(500);
        Console.WriteLine("'다음 기회를 노려보세요!'");
        Thread.Sleep(750);
        Console.Write("\n배팅하신 금액을 전부 잃었습니다.");
        Thread.Sleep(500);
        Console.WriteLine($" -{_processing.GetPlayerBatMoney()}원");
        Thread.Sleep(500);
        AfterPrint();
    }

    private void PlayerBankrupt()
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
        AfterPrint();
    }

    private void PlayerEnding()
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
        Thread.Sleep(2500);
        Console.WriteLine("미친 배팅 실력으로 많은 돈을 얻었습니다.");
        Thread.Sleep(2500);
        Console.WriteLine("당신은 당당히 월세를 지불했고, 집주인에게 신뢰를 회복했습니다.");
        Thread.Sleep(2500);
        Console.WriteLine("이제 당신의 삶을 즐기십시오.");
        Thread.Sleep(2500);
        AfterPrint();

        Console.Clear();
        Thread.Sleep(1000);
        Console.WriteLine("당신은 도박에 빠져 방탕한 나날을 보내다");
        Thread.Sleep(2500);
        Console.Write("달려오는 차를 미처 피하지 못하고 사고를 당했습니다");
        Thread.Sleep(2500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.WriteLine(".");
        Thread.Sleep(2000);
        Console.WriteLine("당신은 기억을 잃었습니다");
        Thread.Sleep(2500);
        Console.WriteLine("사실은 이게 현실이었을지도 모릅니다");
        Thread.Sleep(2500);
        Console.WriteLine("모든 기억을 잃고 처음으로 돌아갑니다.");
        Thread.Sleep(2500);
        AfterPrint();

        Console.Clear();
        Thread.Sleep(1000);
        Console.WriteLine("당신의 삶으로 돌아가세요.");
        Thread.Sleep(1000);
    }

    public void AiBankrupt()
    {
        Console.Clear();
        Thread.Sleep(1000);
        Console.WriteLine($"상대 소지금: {_processing.GetAiMoney()}");
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
        Console.Write("'그럴리가 없어");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(1500);
        Console.WriteLine("이거놔!!!'");
        Thread.Sleep(2500);
        Console.WriteLine("상대는 모든 돈을 잃어 끌려나갔습니다");
        Thread.Sleep(2500);
        Console.WriteLine("잘가요.");
        AfterPrint();
    }

    public void AiEnding()
    {
        Console.Clear();
        Thread.Sleep(1000);
        Console.Write(".");
        Thread.Sleep(1000);
        Console.Write(".");
        Thread.Sleep(1000);
        Console.WriteLine(".");
        Thread.Sleep(1000);
        Console.WriteLine("아까 마셨던 보드카가 문제였을까요?");
        Thread.Sleep(2500);
        Console.WriteLine("당신은 판단력이 흐려져 큰 실수를 저지르고 말았습니다");
        Thread.Sleep(2500);
        Console.WriteLine("상대방은 은은한 미소를 띄우며 당신을 쳐다보았고,");
        Thread.Sleep(2500);
        Console.WriteLine("시시해졌다고 느꼈는지 경호원을 불러 당신을 내쫓았습니다.");
        Thread.Sleep(2500);
        AfterPrint();

        Console.Clear();
        Thread.Sleep(1000);
        Console.WriteLine("시간이 꽤 지나 당신은 길거리를 걷고있습니다");
        Thread.Sleep(2500);
        Console.WriteLine("우연히 처음보는 게임장이 눈에 들어오는군요");
        Thread.Sleep(2500);
        Console.WriteLine("당신은 이끌리듯 게임장 안으로 입장하게 됩니다.");
        Thread.Sleep(2500);
        Console.WriteLine("(매장 안 티비소리)");
        Thread.Sleep(2500);
        Console.WriteLine("(앵커:지난달 초, 도박 중독에 시달리다 사망한..)");
        Thread.Sleep(2500);
        Console.WriteLine("(...)");
        Thread.Sleep(2500);
        Console.WriteLine("당신은 꽤 맘에 드는 테이블에 앉아 게임을 시작합니다.");
        Thread.Sleep(2500);
        AfterPrint();
    }

    private void AfterPrint()
    {
        Console.WriteLine("계속하려면 Enter를 누르세요.");
        Console.ReadLine();
    }

    private void Error()
    {
        Console.WriteLine("올바른 값을 입력해주세요.");
    }
}

// @@@@@@@@@@@@@@@@@@@
// @@@@@데이터 처리@@@@@
// @@@@@@@@@@@@@@@@@@@
public class Processing
{
    private DataBase _database;
    
    public Processing()
    {
        Player player = new Player(100000);
        Player ai = new Player(100000);
        _database = new DataBase(player: player, ai: ai);
    }

    public void SelectCase(string userInput)
    {
        Player player = _database.GetPlayerData();
        Player ai = _database.GetAiData();
        
        switch (userInput)
        {
            case "가위":
            case "1":
                player.SetSelect(0);
                break;
            
            case "바위":
            case "2":
                player.SetSelect(1);
                break;
            
            case "보":
            case "3":
                player.SetSelect(2);
                break;
            
            case "파산":
                player.SetSelect(3);
                player.SetMoney(0);
                player.SetBatMoney(0);
                break;
            
            case "당첨":
                player.SetSelect(4);
                player.SetMoney(1000000);
                player.SetBatMoney(0);
                break;
            
            case "돚거":
                player.SetSelect(5);
                ai.SetMoney(0);
                ai.SetBatMoney(0);
                break;
            
            case "기부":
                player.SetSelect(6);
                ai.SetMoney(1000000);
                ai.SetBatMoney(0);
                break;
            
            default:
                player.SetSelect(-1);
                break;
        }
        
        _database.SaveAiData(ai);
        _database.SavePlayerData(player);
    }
    
    public int GetResult(int playerSelect, int aiSelect)
    {
        Player player = _database.GetPlayerData();
        Player ai = _database.GetAiData();
        var playerMoney = player.GetMoney();
        var playerBatMoney = player.GetBatMoney();
        var aiMoney = ai.GetMoney();
        var aiBatMoney = ai.GetBatMoney();
        var result = playerSelect - aiSelect;
        
        switch (result)
        {
            case 0:
                player.SetMoney(playerMoney + Convert.ToInt32(playerBatMoney * 0.5));
                ai.SetMoney(Convert.ToInt32(aiMoney + aiBatMoney));
                break;
                
            case 1:
            case -2:
                player.SetMoney(playerMoney + (playerBatMoney * 2));
                break;
                
            case -1:
            case 2:
                ai.SetMoney(aiMoney + (aiBatMoney * 2));
                break;
            
            default:
                return 3;
        }
        
        _database.SavePlayerData(player);
        _database.SaveAiData(ai);
        return result;
    }
    
    public void SavePlayerBatMoney(int userInput)
    {
        Player player = _database.GetPlayerData();
        player.SetMoney(GetPlayerMoney() - userInput);
        player.SetBatMoney(userInput);
        _database.SavePlayerData(player);
    }
    
    public int GetPlayerMoney()
    {
        return _database.GetPlayerData().GetMoney();
    }
    
    public int GetPlayerBatMoney()
    {
        return _database.GetPlayerData().GetBatMoney();
    }

    public int GetPlayerSelect()
    {
        return _database.GetPlayerData().GetSelect();
    }
    
    public int GetAiMoney()
    {
        return _database.GetAiData().GetMoney();
    }
    
    public int GetAiBatMoney()
    {
        return _database.GetAiData().GetBatMoney();
    }

    public int GetAiSelect()
    {
        return _database.GetAiData().GetSelect();
    }

    public void AiSelect()
    {
        Random ran = new Random();
        Player ai = _database.GetAiData();
        ai.SetSelect(ran.Next(3));
        _database.SaveAiData(ai);
    }

    public void AiBating()
    {
        Random ran = new Random();
        Player ai = _database.GetAiData();
        
        if (ai.GetMoney() <= 10000)
        {
            ai.SetBatMoney(ai.GetMoney());
        }
        
        else
        {
            ai.SetBatMoney(ran.Next(1000, ai.GetMoney()));
        }
        
        ai.SetMoney(ai.GetMoney() - ai.GetBatMoney());
        _database.SaveAiData(ai);
    }

    public string AiSelectToString()
    {
        string aiSelect = "";
        
        switch (_database.GetAiData().GetSelect())
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
    
    public bool CheckForInput(string text)
    {
        if (!int.TryParse(text, out _))
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}

// @@@@@@@@@@@@@@@@@@@
// @@@@데이터 저장소@@@@
// @@@@@@@@@@@@@@@@@@@
public class DataBase
{
    private Player _playerData;
    private Player _aiData;

    public DataBase(Player player, Player ai)
    {
        _playerData = player;
        _aiData = ai;
    }

    public Player GetPlayerData()
    {
        return _playerData;
    }
    
    public Player GetAiData()
    {
        return _aiData;
    }

    public void SavePlayerData(Player player)
    {
        this._playerData = player;
    }
    
    public void SaveAiData(Player ai)
    {
        this._aiData = ai;
    }
}

// @@@@@@@@@@@@@@@@@@@
// @@@객체 기본 데이터@@@
// @@@@@@@@@@@@@@@@@@@
public class Player
{
    private int _money;
    private int _batMoney;
    private int _select;

    public Player(int money)
    {
        this._money = money;
    }

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