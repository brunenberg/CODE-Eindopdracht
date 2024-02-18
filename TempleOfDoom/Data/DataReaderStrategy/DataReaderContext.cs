using GameLogic.Interfaces;
using System.Text.Json;

namespace Data.DataReaderStrategy {
    public class DataReaderContext {

        private IDataReader _dataReader;

        public DataReaderContext(IDataReader dataReader) {
            _dataReader = dataReader;
        }

        public void SetDataReader(IDataReader dataReader) {
            _dataReader = dataReader;
        }

        public Level ReadDataFromFile(string filePath) {
            return _dataReader.ReadData(filePath);
        }
    }
}
