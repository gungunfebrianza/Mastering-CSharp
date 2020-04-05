using System;
using Newtonsoft.Json;

namespace TypeData
{
  class Program
  {

    static void Main(string[] args)
    {
      string jsonData = @"{'FirstName': 'Gun Gun', 'LastName': 'Febrianza'}";
      var myDetails = JsonConvert.DeserializeObject<MyDetail>(jsonData);
      Console.WriteLine(string.Concat("Hi ", myDetails.FirstName, " " + myDetails.LastName));
      Console.ReadLine();
    }
  }

  public class MyDetail
  {
    public string FirstName
    {
      get;
      set;
    }
    public string LastName
    {
      get;
      set;
    }
  }
}
