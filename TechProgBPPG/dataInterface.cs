using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechProgBPPG
{
    public interface DataInterface
    {
        void FillReadersList(DataRepository dr);
        void FillBookDictionary(DataRepository dr);
        void FillExpireDateList(DataRepository dr);
        void FillRentsWithData(DataRepository dr);
    }
}
