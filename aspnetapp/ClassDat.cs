using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;

namespace aspnetapp
{
    public class ClassDat
    {
        public string sName { get; set; }
        public int iValue { get; set; }

        public string WebRootPath { get; set; }

        public string ContentRootPath { get; set; }

        public string DataPath { get; set; }
        public int DataRows { get; set; }

        public ClassDat() 
        {
            this.iValue = 0;
            this.sName = "";
            this.WebRootPath = "";
            this.ContentRootPath = "";
            this.DataPath = "";
            this.DataRows = 0;
        }
    }
}
