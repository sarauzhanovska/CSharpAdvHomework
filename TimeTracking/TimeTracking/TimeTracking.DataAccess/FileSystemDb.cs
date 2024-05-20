

using Newtonsoft.Json;
using TimeTracking.DataAccess.Interfaces;
using TimeTracking.Domain.Models;

namespace TimeTracking.DataAccess
{
    public class FileSystemDb<T> : IGenericDb<T> where T : BaseEntity
    {
        private string _dbFolder;
        private string _dbPath;
        private string _idPath;

        public FileSystemDb()
        {
            _dbFolder = @"..\..\..\Db";
            _dbPath = _dbFolder + $@"\Users.json";
            _idPath = _dbFolder + @"\id.txt";
            if (!Directory.Exists(_dbFolder))
            {
                Directory.CreateDirectory(_dbFolder);
            }
            if (!File.Exists(_dbPath))
            {
                File.Create(_dbPath).Close();
            }
            if (!File.Exists(_idPath))
            {
                File.Create(_idPath).Close();
            }
        }

        private void WriteData(string path, List<T> data)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(JsonConvert.SerializeObject(data));
            }
        }


        private int GenerateId()
        {
            int id = 1;
            using (StreamReader sr = new StreamReader(_idPath))
            {
                string currentId = sr.ReadLine();
                if (currentId != null) id = int.Parse(currentId);
            }

            using (StreamWriter sw = new StreamWriter(_idPath))
            {
                sw.WriteLine(id + 1);
            }
            return id;
        }

        public int Add(T entity)
        {
            List<T> data = new List<T>();

            using (StreamReader sr = new StreamReader(_dbPath))
            {
                data = JsonConvert.DeserializeObject<List<T>>(sr.ReadToEnd());
            }
            if (data == null) data = new List<T>();
            entity.Id = GenerateId();
            data.Add(entity);
            WriteData(_dbPath, data);
            return entity.Id;
        }

        public List<T> FilterBy(Func<T, bool> filterCondition)
        {
            List<T> data = GetAll();
            return data.Where(filterCondition).ToList();
        }

        public List<T> GetAll()
        {
            using (StreamReader sr = new StreamReader(_dbPath))
            {
                return JsonConvert.DeserializeObject<List<T>>(sr.ReadToEnd());
            }
        }

        public T GetById(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id == id);

        }

        public bool RemoveById(int id)
        {
            try
            {
                List<T> data = new List<T>();

                using (StreamReader sr = new StreamReader(_dbPath))
                {
                    data = JsonConvert.DeserializeObject<List<T>>(sr.ReadToEnd());
                }
                T item = data.SingleOrDefault(x => x.Id == id);
                if (item != null)
                {
                    data.Remove(item);
                    WriteData(_idPath, data);
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        

        public bool Update(T entity)
        {
            try
            {
                List<T> data = new List<T>();

                using (StreamReader sr = new StreamReader(_dbPath))
                {
                    data = JsonConvert.DeserializeObject<List<T>>(sr.ReadToEnd());
                }
                T item = data.SingleOrDefault(x => x.Id == entity.Id);
                if (item != null)
                {
                    data[data.IndexOf(item)] = entity;
                    WriteData(_idPath, data);
                    return true;
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
