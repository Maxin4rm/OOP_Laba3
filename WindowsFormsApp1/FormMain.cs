using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.classes;
using WindowsFormsApp1.Factories;
namespace WindowsFormsApp1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        public static List<Transport> transports = new List<Transport>();

        private void OutputTransport()
        {
            while (transportTable.Rows.Count > 0)
                transportTable.Rows.RemoveAt(0);
            int i = 1;
            foreach (Transport transport in transports)
            {
                transportTable.Rows.Add(new object[] {
                    i,
                    transport.GetType().Name,
                    transport.Model,
                    transport.MaxSpeed
                });
                i++;
            }
            
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            FormAddElem addForm = new FormAddElem();
            FormAddElem.mode = FormAddElem.ADD;
            addForm.ShowDialog();
            OutputTransport();   
        }
        
        private void ViewButton_Click(object sender, EventArgs e)
        {
            
            FormAddElem addForm = new FormAddElem();
            FormAddElem.mode = FormAddElem.VIEW;
            FormAddElem.curTransport = transports[transportTable.CurrentRow.Index];
            addForm.ShowDialog();
        }
        
        private void EditButton_Click(object sender, EventArgs e)
        {
            
            FormAddElem addForm = new FormAddElem();
            FormAddElem.mode = FormAddElem.EDIT;
            FormAddElem.curTransport = transports[transportTable.CurrentRow.Index];
            FormAddElem.editIndex = transportTable.CurrentRow.Index;
            addForm.ShowDialog();
            OutputTransport();
            
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Transport temp = transports[transportTable.CurrentRow.Index];
            transports.RemoveAt(transportTable.CurrentRow.Index);
            temp.driver = null;
            temp = null;
            transportTable.Rows.RemoveAt(transportTable.CurrentRow.Index);
            if (transportTable.Rows.Count != 0)
            {
                for (int i = transportTable.CurrentRow.Index; i < transportTable.Rows.Count; i++)
                {
                    transportTable.Rows[i].Cells[0].Value = i + 1;
                }
            }
            if (transportTable.Rows.Count == 0)
            {
                ViewButton.Enabled = EditButton.Enabled = DeleteButton.Enabled = false;
            }
        }

        private void TransportTable_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ViewButton.Enabled = EditButton.Enabled = DeleteButton.Enabled = true;
        }







        
        

        

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = GetFileFilter();
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            OpenFile(openFileDialog.FileName);
        }

        public enum TypeOfSerialization
        {
            [Name("Text files|*.txt")]
            Text,
            [Name("Binary files|*.bin")]
            Binary,
            [Name("Xml files|*.xml")]
            Xml
        }

        readonly Dictionary<TypeOfSerialization, Type> serializers = new Dictionary<TypeOfSerialization, Type>(){
            { TypeOfSerialization.Text, typeof(TxtFactory) },
            { TypeOfSerialization.Binary, typeof(BinaryFactory) },
            { TypeOfSerialization.Xml, typeof(XMLFactory) }
        };

        public void OpenFile(string fileName)
        {
            var serializerType = (TypeOfSerialization)(openFileDialog.FilterIndex - 1);
            SerializerFactory serializerFactory = (SerializerFactory)Activator.CreateInstance(serializers[serializerType]);
            SerializerInterface currSerializer = serializerFactory.CreateSerializer();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    fileStream.CopyTo(memoryStream);
                }
                memoryStream.Seek(0, SeekOrigin.Begin);
                try
                {
                    transports = currSerializer.Deserialize(memoryStream);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "File reading error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            OutputTransport();
        }

        private string GetFileFilter()
        {
            var fields = typeof(TypeOfSerialization).GetFields();
            string filter = "";
            for (int i = 1; i < fields.Length; i++)
            {
                string[] serAttr = ((NameAttribute)fields[i].GetCustomAttributes(typeof(NameAttribute), false)[0]).Name.Split('|');
                string name = serAttr[0];
                string ext = serAttr[1];
                filter += name + '|' + ext + '|';
            }
            string sFilter = filter.Remove(filter.Length - 1, 1);
            return sFilter;
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = GetFileFilter();
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            var serType = (TypeOfSerialization)(saveFileDialog.FilterIndex - 1);
            string fName = saveFileDialog.FileName;
            SerializerFactory serializerFactory = (SerializerFactory)Activator.CreateInstance(serializers[serType]);
            SerializerInterface serializer = serializerFactory.CreateSerializer();
            using (FileStream fileStream = new FileStream(fName, FileMode.Create))
            {
                serializer.Serialize(transports, fileStream);
            }
        }
    }
}
