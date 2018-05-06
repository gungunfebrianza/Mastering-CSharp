class PolyEncryption
{
    public string EncryptText(string input, string key)
    {
  Random R = new Random();
  int kc = 0;
  char[] text = input.ToCharArray();
  char[] keyarr = key.ToCharArray();
  char[] FinVal = new char[input.Length + 1];
  int Rnd = R.Next(100, 220);
  for (int index = 0; index < input.Length; index++)
  {
    if (kc >= keyarr.Length)
    kc = 0;

    int ptVal = (int)text[index];
    int kVal = (int)keyarr[kc];
    int ciVal = ptVal + kVal + Rnd;
    FinVal[index] = Convert.ToChar(ciVal);
    kc++;
  }
  FinVal[input.Length] = (char)Rnd;
  string RetStr = new string(FinVal);
  return RetStr;

    }

    public string DecryptText(string input, string key)
    {
  char[] text = input.ToCharArray();
  char[] keyarr = key.ToCharArray();
  char[] FinVal = new char[input.Length - 1];
  int RndKVal = text[input.Length - 1];
  text[input.Length - 1] = '\0';
  int kc = 0;
  for (int index = 0; index < input.Length; index++)
  {
    if (index >= input.Length - 1)
    continue;
    if (kc >= keyarr.Length)
    kc = 0;
    int ciVal = text[index];
    int kVal = keyarr[kc];
    int ptVal = ciVal - RndKVal - kVal;
    FinVal[index] = Convert.ToChar(ptVal);
    kc++;
  }
  string RetStr = new string(FinVal);
  return RetStr;
    }

}
