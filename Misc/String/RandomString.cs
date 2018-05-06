static string randomString(int len, string pool = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWKYZ1234567890")
        {
            if (len < 1) throw new System.ArgumentException("Parameter cannot be less than '1'", "len");
            
            if(pool.Length < 10) throw new System.ArgumentException("Parameter cannot be less than '10'", "pool");

            Random RND = new Random();
            StringBuilder tmp_str = new StringBuilder(String.Empty,len);
            for (int i = 0; i < len; i++)  tmp_str.Append(pool[RND.Next(0, pool.Length)]);
            
            return tmp_str.ToString();
        }
