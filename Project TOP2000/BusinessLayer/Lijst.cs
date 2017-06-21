using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace BusinessLayer
{
    public class Lijst
    {
        private int lijstLengte;

        public int LijstLengte
        {
            get { return lijstLengte; }
            set { lijstLengte = value; }
        }

        private string searchInput;

        public string SearchInput
        {
            get { return searchInput; }
            set { searchInput = value; }
        }

        private int above;

        public int Above
        {
            get { return above; }
            set { above = value; }
        }

        private int val;

        public int Val
        {
            get { return val; }
            set { val = value; }
        }

        private string selectedJaartal;

        public string SelectedJaartal
        {
            get { return selectedJaartal; }
            set { selectedJaartal = value; }
        }

        private DataSet dataSetTop10;

        public DataSet DataSetTop10
        {
            get { return dataSetTop10; }
            set { dataSetTop10 = value; }
        }

        private DataView dataViewTop10;

        public DataView DataViewTop10
        {
            get { return dataViewTop10; }
            set { dataViewTop10 = value; }
        }

        //private DataView dataViewTop10Search;

        //public DataView DataViewTop10Search
        //{
        //    get { return dataViewTop10Search; }
        //    set { dataViewTop10Search = value; }
        //}

        private DataTable dataTable;

        public DataTable DataTable
        {
            get { return dataTable; }
            set { dataTable = value; }
        }

        public Lijst()
        {
            
        }
        public Lijst(DataTable _DataTable)
        {
            this.dataTable = _DataTable;
            
        }

        public Lijst(DataSet _DataSet)
        {
            this.dataSetTop10 = _DataSet;
        }
    }
}
