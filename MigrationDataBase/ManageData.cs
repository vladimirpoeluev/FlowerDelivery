using MigrationDataBase.Records;
using System.Data.SqlClient;

namespace MigrationDataBase
{
    public class ManageData
    {
        protected string nameTable;

        public ManageData()
        {
            nameTable = "data";
        }


        public virtual IRecord[] GetAllRecord()
        {
            SqlCommand cmd = new SqlCommand();
            return null;
        } 

        public virtual IRecord GetRecord(int id)
        {
            return GetAllRecord()[id];
        }
    }
}
