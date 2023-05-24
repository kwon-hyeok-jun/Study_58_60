//using System;
//using System.IO;

//class StreamWriterWriteLineDemo
//{
//    static void Main()
//    {
//        string data =
//            "안녕하세요.\r\n반가습니다." + Environment.NewLine + "또 만나요.";

//        //[1] StreamWriter 클래스를 사용하여 파일 생성
//        // C 드라이브에 Temp 폴더 미리 생성해야 함
//        StreamWriter sw = new StreamWriter("C:\\Temp\\Test.txt");

//        //[2] Write() 메서드 : 저장
//        sw.WriteLine(data);

//        //[3] StreamWrite 개체를 생성했으면 반드시 닫기
//        sw.Close();

//        //[4] 메모리 해제 
//        sw.Dispose();
//    }
//}

//using System;
//using System.IO;

//class StreamReaderReadToEndDemo
//{
//    static void Main()
//    {
//        //[1] StreamReader 클래스로 텍스트 파일 읽기
//        StreamReader sr = new StreamReader(@"C:\Temp\Test.txt");

//        //[2] ReadToEnd() 메서드로 텍스트 파일의 내용 읽어 콘솔에 출력하기 
//        Console.WriteLine("{0}", sr.ReadToEnd()); // 전체 읽어오기

//        //[3] 사용 후 파일 닫고 메모리 정리하기 
//        sr.Close();
//        sr.Dispose();
//    }
//}

//using System;
//using System.IO;

//class DirectoryAndDirectoryInfo
//{
//    static void Main()
//    {
//        string dir = "C:\\";

//        //[1] Directory 클래스
//        if (Directory.Exists(dir))
//        {
//            Console.WriteLine("[1] C 드라이브의 모든 폴더 목록을 출력");
//            foreach (string folder in Directory.GetDirectories(dir))
//            {
//                Console.WriteLine($"{folder}");
//            }
//        }

//        //[2] DirectoryInfo 클래스
//        DirectoryInfo di = new DirectoryInfo(dir + "Temp\\");
//        if (di.Exists)
//        {
//            Console.WriteLine("[2] C 드라이브의 Temp 폴더의 모든 파일 목록 출력");
//            foreach (var file in di.GetFiles())
//            {
//                Console.WriteLine($"{file}");
//            }
//        }
//    }
//}

//[?] XElement 클래스: XML 요소를 생성하거나 담을 수 있는 그릇
//using System;
//using System.Linq;
//using System.Xml.Linq;

//class XElementDemo
//{
//    static void Main()
//    {
//        //[1] XML 요소 생성
//        XElement category = new XElement("Menus",
//            new XElement("Menu", "책"),
//            new XElement("Menu", "강의"),
//            new XElement("Menu", "컴퓨터")
//        );
//        Console.WriteLine(category);

//        //[2] XML 요소 가공
//        XElement newCategory = new XElement("Menus",
//            from node in category.Elements()
//            where node.Value.ToString().Length >= 2
//            select node
//        );
//        Console.WriteLine(newCategory);
//    }
//}


//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Xml;

//public class Shirt
//{
//    public string Name { get; set; }
//    public DateTime Created { get; set; }
//    public List<string> Sizes { get; set; }
//}

//public class JsonConvertDemo
//{
//    static void Main()
//    {
//        //[1] 직렬화(Serialize) 데모
//        Shirt shirt1 = new Shirt
//        {
//            Name = "Red Shirt",
//            Created = new DateTime(2020, 01, 01),
//            Sizes = new List<string> { "Small" }
//        };
//        string json1 = JsonConvert.SerializeObject(shirt1, Newtonsoft.Json.Formatting.Indented);
//        Console.WriteLine(json1);

//        //[2] 역직렬화(Deserialize) 데모
//        string json2 = @"{
//            'Name': 'Black Shirt',
//            'Created': '2020-12-31T00:00:00',
//            'Sizes': ['Large']
//        }";
//        Shirt shirt2 = JsonConvert.DeserializeObject<Shirt>(json2);
//        Console.WriteLine($"{shirt2.Name} - {shirt2.Created}");
//    }
//}

// HttpClientDemo 프로젝트에서 실행
using System;
using System.Net.Http;
using System.Threading.Tasks;

class HttpClientDemo
{
    static async Task Main()
    {
        //[1] HttpClient 개체 생성
        HttpClient httpClient = new HttpClient();

        //[2] GetAsync() 메서드 호출
        HttpResponseMessage httpResponseMessage =
            await httpClient.GetAsync("http://www.dotnetnote.com/");

        //[3] HTML 가져오기 
        string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

        //[4] 출력
        Console.WriteLine(responseBody);
    }
}
