namespace Practice._240527;

// public class MainApp
// {
//     public static void Main(string[] args)
//     {
//         string userInput = "";
//         Console.WriteLine("메모장 v1.0\n");
//         
//         while (userInput != "종료")
//         {
//             var textSaver = new TextSave(new List<string> { userInput });
//             userInput = Console.ReadLine();
//             
//             switch (userInput)
//             {
//                 case "보기":
//                     textSaver.TextPrint();
//                     Console.WriteLine("\n돌아가려면 Enter 키를 입력하세요.");
//                     Console.ReadLine();
//                     break;
//             }
//         }
//     }
// }
//
// public class TextSave
// {
//     private List<string> _text;
//
//     public TextSave()
//     {
//         _text = new List<string>();
//     }
//
//     public string GetText(string a)
//     {
//         _text = a;
//     }
//
//     public void TextPrint()
//     {
//         foreach (string list in _text)
//         {
//             this._text.Add(new string());
//             Console.WriteLine(list);
//         }
//     }
// }