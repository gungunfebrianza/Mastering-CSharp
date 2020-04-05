using System;

namespace TypeData
{
  class Program
  {
    static void Main(string[] args)
    {
      var age = 25;
      int score = 100;
      Type ageType = age.GetType();
      Console.WriteLine($"age is {ageType}"); //age is System.Int32
      Console.WriteLine($"score is {score.GetType()}"); //score is System.Int32
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
