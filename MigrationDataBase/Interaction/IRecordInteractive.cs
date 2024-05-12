using MigrationDataBase.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationDataBase.Interaction
{
    public interface IRecordInteractive
    {
        IRecord Get(int id);
        IRecord[] Get();
    }
}
