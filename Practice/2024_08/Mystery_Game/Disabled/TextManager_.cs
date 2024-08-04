// using static System.Console;
//
// namespace Practice._2024_08.Mystery_Game;
//
// /// <summary>
// /// 입출력 관리 (인물 대사 등)
// /// </summary>
// public class TextManager
// {
//     private readonly GameManager _gameManager;
//     private const int TypingDelay = 100; // ms
//
//     public TextManager(GameManager gameManager)
//     {
//         this._gameManager = gameManager ?? throw new ArgumentNullException(nameof(gameManager));
//     }
//     
//     // 사용자 입력
//     public string GetUserInput()
//     {
//         var userInput = ReadLine();
//         userInput = userInput?.Trim() ?? string.Empty;
//         return userInput.Trim();
//     }
//
//     public void StartGameText()
//     {
//         Clear();
//         TextDelay("범 죄 는  흔 적 을  남 긴 다");
//         Thread.Sleep(1000);
//         WriteLine("\nEnter키를 눌러 이야기를 시작하세요.");
//         GetUserInput();
//     }
//
//     public void AddPlayerName()
//     {
//         while (true)
//         {
//             // 플레이어 이름 입력 대기
//             Clear();
//             WriteLine("이름을 정해주세요.");
//             string input = GetUserInput();
//             
//             // 확인 메시지 출력
//             WriteLine($"{input} 으로 결정하시겠습니까? ( 네 / 아니오 )");
//             string select = GetUserInput().Trim().ToLower();
//
//             // 올바르지 않은 입력일 경우 반복
//             while (select != "네" && select != "아니오")
//             {
//                 Clear();
//                 WriteLine("입력된 이름 : {0}", input);
//                 WriteLine("잘못된 입력입니다. '네' 또는 '아니오'로만 입력해주세요.");
//                 select = GetUserInput().Trim();
//             }
//             
//             switch (select)
//             {
//                 case "네" :
//                     _gameManager.AddPlayer(input);
//                     return;
//                 
//                 case "아니오" :
//                     break;
//             }
//         }
//     }
//
//     public void BeforeCase1()
//     {
//         Clear();
//         WriteLine("2024년 8월의 여름, 선착장");
//         GetUserInput();
//         
//         Clear(); 
//         WriteLine("내가 하던 게임의 소모임에서 정모를 하다"); 
//         WriteLine("운 좋게 별장을 빌리게 되어 다같이 여행을 가기로 했다.");
//         GetUserInput();
//         
//         Clear();
//         WriteLine("모이기로 한 장소가 여기인것같은데..");
//         GetUserInput();
//         
//         Clear();
//         WriteLine("저 멀리 캐리어를 들고있는 사람들이 보인다.");
//         GetUserInput();
//         
//         Clear();
//         TextDelayPerson("???", "어, 저기 오시나보네요.");
//         GetUserInput();
//             
//         Clear();
//         TextDelayPerson(_gameManager.GetPlayer(), "안녕하세요!");
//         GetUserInput();
//         
//         Clear();
//         WriteLine("??? : ");
//         GetUserInput();
//     }
//
//     // 문자열 쪼개서 한글자씩 출력 (대사 효과)
//     // Thread.Sleep은 UI 스레드를 차단 할 수 있음
//     // UI가 있는 애플리케이션에서는 비동기 방식 구현 필요
//     public void TextDelayPerson(string name, string text)
//     {
//         Write($"{name} : ");
//         foreach (char c in text)
//         {
//             Write(c);
//             Thread.Sleep(TypingDelay);
//         }
//         WriteLine();
//     }
//     
//     public void TextDelay(string text)
//     {
//         foreach (char c in text)
//         {
//             Write(c);
//             Thread.Sleep(TypingDelay);
//         }
//         WriteLine();
//     }
// }