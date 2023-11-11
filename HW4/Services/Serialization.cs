using HW4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace HW4.Services
{
    public  class Serialization<T>
    {

        public  bool SerializeToJsonFile(string filePath, T[] objects)
            {
            File.Delete(filePath);
            try
            {
                using(StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (var obj in objects)
                    {
                        sw.WriteLine(SerializeObject(obj));
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public  T[] DeserializeFromJsonFile(string filePath)
        {
            T[] objects = new T[0];
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    T obj = DeSerializeToObject(line);
                    objects = objects.Append(obj).ToArray();

                }
            }
            return objects;
        }
            
         
        
        

        public string SerializeObject(T obj)
        {
           return JsonConvert.SerializeObject(obj);
        }

        public T DeSerializeToObject(string json)
        {
           return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
