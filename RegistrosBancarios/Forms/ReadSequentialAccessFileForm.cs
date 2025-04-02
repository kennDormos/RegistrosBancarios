using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegistrosBancarios.Factories;
using RegistrosBancarios.Serializers;

namespace RegistrosBancarios.Forms
{
    public partial class ReadSequentialAccessFileForm: Form
    {
        private List<Record> records = new List<Record>();
        private SerializerFactory serializerFactory;
        public ReadSequentialAccessFileForm()
        {
            InitializeComponent();
            comboBoxFormat.Items.AddRange(new string[] { "JSON", "XML" });
            comboBoxFormat.SelectedIndex = 0;
            comboBoxFormat.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string format = comboBoxFormat.SelectedItem.ToString();
            if (format == "JSON")
            {
                serializerFactory = new JsonSerializerFactory();
            }
            else
            {
                serializerFactory = new XmlSerializerFactory();
            }
            var serializer = serializerFactory.CreateSerializer();
            records = serializer.Deserialize("data." + format.ToLower());

            dataGridView.DataSource = null;
            dataGridView.DataSource = records;

            MessageBox.Show("Datos cargados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    Record recordToDelete = row.DataBoundItem as Record;
                    if (recordToDelete != null)
                    {
                        records.Remove(recordToDelete);
                    }
                }

                dataGridView.DataSource = null;
                dataGridView.DataSource = records;

                
                string format = comboBoxFormat.SelectedItem.ToString();
                if (format == "JSON")
                {
                    serializerFactory = new JsonSerializerFactory();
                }
                else
                {
                    serializerFactory = new XmlSerializerFactory();
                }
                var serializer = serializerFactory.CreateSerializer();
                serializer.Serialize(records, "data." + format.ToLower());

                MessageBox.Show("Registro(s) borrado(s) correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione al menos un registro para borrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
    }

