using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Soldiers.Backend_Classes
{
    class HTMLWrapper
    {
        String filename;
        FileStream stream;
        StreamWriter document;

        public HTMLWrapper()
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Soldier..";
            saveFileDialog.Filter = "DATA Files|*.data";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.InitialDirectory = "C:\\";
            saveFileDialog.CheckFileExists = true;
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.ShowDialog();
            String fileName;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
                stream = new FileStream(filename, FileMode.CreateNew);
                document = new StreamWriter(stream);
                document.Write("<html>" +
                    "< head >" +
                    "< title > Summarized Leaders Book </ title >" +
                    "</ head >" +
                    "< body >    " +
                    "< h1 align = \" center\" > Summarized Leaders Book </ h1 >" +
                    "< hr /> ");
                document.WriteLine("< table >");
                document.WriteLine("<tr><td>Rank</td><td>Name</td><td>BESD</td><td>DOR</td><td>ETS</td><td>PP</td><td>Flagged</td></tr>");

            }
        }

            public HTMLWrapper(string fname)
            {
                stream = new FileStream(fname, FileMode.CreateNew);
            document = new StreamWriter(stream);
            }
        public void writeHeading(int level, string heading) { }
        public void writeParagraph(string text) { }
        public void insertBreak() { }
        public void writeTable() { }




    }
}
