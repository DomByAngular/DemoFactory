using System;

namespace YS.Service.CommomService
{
    public class IDHelperForBatchDelete
    {
        public static string  UnionIDToString(string[]ids)
        {
            /*Random random=new Random();
            string[] randomIds = new string[100];
            for(int i=0;i<100;i++)
            {
                randomIds[i] = random.Next(0, 100).ToString();
            }*/
            string result = String.Empty;

            foreach (string id in ids)
            {
                result += "'"+id+"'" + ",";
            }

            return result.Substring(0, result.Length - 1);
        }
    }
}
