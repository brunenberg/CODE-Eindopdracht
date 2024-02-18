using Data;
using System.Text.Json;

namespace GameLogic.Interfaces {
    public interface IDataReader {
        public Level ReadData(string filePath);
    }
}
