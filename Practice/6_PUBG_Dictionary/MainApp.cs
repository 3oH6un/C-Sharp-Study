namespace Practice._6_PUBG_Dictionary;

public class MainApp
{
    public static void _Main()
    {
        Weapon[] arWeapons =
        [
            new Weapon("7.62mm", "그로자"),
            new Weapon("7.62mm", "AKM"),
            new Weapon("7.62mm", "Mk47 뮤턴트"),
            new Weapon("7.62mm", "베릴 M762"),
            new Weapon("7.62mm", "ACE32"),
            new Weapon("5.56mm", "AUG"),
            new Weapon("5.56mm", "M416"),
            new Weapon("5.56mm", "SCAR-L"),
            new Weapon("5.56mm", "QBZ"),
            new Weapon("5.56mm", "G36C"),
            new Weapon("5.56mm", "M16A4"),
            new Weapon("5.56mm", "K2"),
            new Weapon("5.56mm", "FAMAS")
        ];
        
        Weapon[] dmrWeapons =
        [
            new Weapon("5.56mm", "미니-14"),
            new Weapon("5.56mm", "QBU"),
            new Weapon("5.56mm", "Mk12"),
            new Weapon("7.62mm", "SKS"),
            new Weapon("7.62mm", "SLR"),
            new Weapon("7.62mm", "Mk.14"),
            new Weapon("7.62mm", "드라구노프"),
            new Weapon("9mm", "VSS")
        ];

        Weapon[] srWeapons =
        [
            new Weapon("7.62mm", "Kar98k"),
            new Weapon("7.62mm", "모신 나강"),
            new Weapon("7.62mm", "M24"),
            new Weapon("300매그넘", "AWM"),
            new Weapon(".45 ACP", "Win94"),
            new Weapon("50구경", "링스 AMR")
        ];

        Weapon[] smgWeapons =
        [
            new Weapon("45.ACP", "UMP45"),
            new Weapon("45.ACP", "토미 건"),
            new Weapon("9mm", "마이크로 UZI"),
            new Weapon("9mm", "벡터"),
            new Weapon("9mm", "PP-19 비존"),
            new Weapon("9mm", "MP5K"),
            new Weapon("9mm", "MP9"),
            new Weapon("9mm", "JS9"),
            new Weapon("5.7mm", "P90")
        ];

        Weapon[] sgWeapons =
        [
            new Weapon("12게이지", "S1897"),
            new Weapon("12게이지", "S686"),
            new Weapon("12게이지", "S12K"),
            new Weapon("12게이지", "DBS"),
            new Weapon("슬러그탄", "O12"),
        ];
        
        Weapon[] lmgWeapons =
        [
            new Weapon("5.56mm", "M249"),
            new Weapon("5.56mm", "DP-28"),
            new Weapon("5.56mm", "MG3"),
        ];
        
        Weapon[] miscWeapons =
        [
            new Weapon("석궁용 화살", "석궁"),
            new Weapon("판처파우스트 탄두", "판처파우스트"),
            new Weapon("60mm 박격포탄", "박격포"),
        ];
        
        Weapon[] pistolWeapons =
        [
            new Weapon("9mm", "P92"),
            new Weapon("9mm", "P18C"),
            new Weapon("9mm", "스콜피온"),
            new Weapon(".45 ACP", "P1911"),
            new Weapon(".45 ACP", "R45"),
            new Weapon(".45 ACP", "Deagle"),
            new Weapon("7.62mm", "R1895"),
            new Weapon("12게이지", "소드오프"),
            new Weapon("신호탄", "플레어건"),
            new Weapon("40mm 유탄", "M79")
        ];

        Weapon[] meleeWeapons =
        [
            new Weapon("낫"),
            new Weapon("마체테"),
            new Weapon("쇠지렛대"),
            new Weapon("프라이팬"),
        ];

        Weapon[] throwableWeapons = 
        [
            new Weapon("세열수류탄"),
            new Weapon("연막탄"),
            new Weapon("섬광탄"),
            new Weapon("화염병"),
            new Weapon("점착폭탄"),
            new Weapon("블루존 수류탄"),
            new Weapon("C4"),
            new Weapon("스파이크 트랩")
        ];

        string userInput = "";
        
        while (userInput != "종료")
        {
            Text.MainSelect();
            userInput = Console.ReadLine().ToUpper();
            
            switch (userInput)
            {
                case "주무기":
                case "AR":
                case "1":
                    Console.WriteLine("\n< 주무기 목록 >");
                    Console.WriteLine("[AR]돌격소총\n[DMR]지정사수소총\n[SR]저격소총\n[SMG]기관단총\n[SG]산탄총\n[LMG]경기관총");
                    string userInputMain = Console.ReadLine().ToUpper();

                    switch (userInputMain)
                    {
                        case "AR":
                        case "돌격소총":
                        case "1":
                            Console.WriteLine("\n\t--AR 돌격소총 목록--");
                            
                            foreach (Weapon weapon in arWeapons)
                            {
                                weapon.OutputMainInfo();
                            }
                            Text.Return();
                            break;
                        
                        case "DMR":
                        case "지정사수소총":
                        case "2":
                            Console.WriteLine("\n\t--DMR 지정사수소총 목록--");
                            foreach (Weapon weapon in dmrWeapons)
                            {
                                weapon.OutputMainInfo();
                            }
                            Text.Return();
                            break;
                        
                        case "SR":
                        case "저격소총":
                        case "3":
                            Console.WriteLine("\n\t--SR 저격소총 목록--");
                            foreach (Weapon weapon in srWeapons)
                            {
                                weapon.OutputMainInfo();
                            }
                            Text.Return();
                            break;
                        
                        case "SMG":
                        case "기관단총":
                        case "4":
                            Console.WriteLine("\n\t--SMG 기관단총 목록--");
                            foreach (Weapon weapon in smgWeapons)
                            {
                                weapon.OutputMainInfo();
                            }
                            Text.Return();
                            break;
                        
                        case "SG":
                        case "산탄총":
                        case "5":
                            Console.WriteLine("\n\t--SG 산탄총 목록--");
                            foreach (Weapon weapon in sgWeapons)
                            {
                                weapon.OutputMainInfo();
                            }
                            Text.Return();
                            break;
                        
                        case "LMG":
                        case "경기관총":
                        case "6":
                            Console.WriteLine("\n\t--LMG 경기관총 목록--");
                            foreach (Weapon weapon in lmgWeapons)
                            {
                                weapon.OutputMainInfo();
                            }
                            Text.Return();
                            break;
                        
                    } 
                    break;
            
                case "SUB":
                case "보조무기":
                case "2":
                    Console.WriteLine("\n\t--보조무기(권총) 목록--");
                    foreach (Weapon weapon in pistolWeapons)
                    {
                        weapon.OutputMainInfo();
                    }
                    Text.Return();
                    break;
            
                case "MELEE":
                case "근접무기": 
                case "3":
                    Console.WriteLine("\n\t--근접무기 목록--");
                    foreach (Weapon weapon in meleeWeapons)
                    {
                        weapon.OutputSubInfo();
                    }
                    Text.Return();
                    break;
            
                case "투척무기": 
                case "4":
                    Console.WriteLine("\n\t--투척무기 목록--");
                    foreach (Weapon weapon in throwableWeapons)
                    {
                        weapon.OutputSubInfo();
                    }
                    Text.Return();
                    break;
            
                case "기타": 
                case "5":
                    Console.WriteLine("\n\t--기타 무기 목록--");
                    foreach (Weapon weapon in miscWeapons)
                    {
                        weapon.OutputMainInfo();
                    }
                    Text.Return();
                    break;
                
            }
        }
    }
}

class Weapon
{
    private string _name;
    private string _ammo;

    public Weapon(string ammo, string name)
    {
        this._name = name;
        this._ammo = ammo;
    }

    public Weapon(string name)
    {
        this._name = name;
    }

    public void OutputMainInfo()
    {
        Console.WriteLine($"탄약:{_ammo}\t이름:{_name}");
    }

    public void OutputSubInfo()
    {
        Console.WriteLine($"이름:{_name}");
    }
}

class Text // 출력 메시지 관리 
{
    public static void MainSelect()
    {
        Console.WriteLine("\n\t■□■□■□■ 배틀그라운드 무기 목록 ■□■□■□■");
        Console.WriteLine("[주무기] [보조무기] [근접무기] [투척무기] [기타]");
        Console.WriteLine("열람을 원하시는 무기의 종류를 입력하세요.");
        Console.WriteLine("실행을 중단하고 싶으시면 '종료'를 입력하세요.");
    }
    public static void Return()
    {
        Console.WriteLine("\n처음으로 돌아가려면 Enter 키를 누르세요.");
        Console.ReadLine();
        Console.Write("돌아가는 중");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.WriteLine(".");
        Thread.Sleep(500);
    }

    public static void Error1()
    {
        Console.WriteLine("올바른 값을 입력해주세요.");
    }
}
