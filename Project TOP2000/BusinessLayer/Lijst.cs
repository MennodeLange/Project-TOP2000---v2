﻿using System;
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

        public Lijst()
        {
            
        }
    }
}
