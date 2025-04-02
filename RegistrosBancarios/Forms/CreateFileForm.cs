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
    public partial class CreateFileForm: Form
    {
        private List<Record> records = new List<Record>();
        private SerializerFactory serializerFactory;
        public CreateFileForm()
        {
            InitializeComponent();
            comboBoxFormat.Items.AddRange(new string[] { "JSON", "XML" });
            comboBoxFormat.SelectedIndex = 0;
            comboBoxFormat.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxAccountNumber.Text, out int accountNumber) || accountNumber <= 0)
            {
                MessageBox.Show("Número de cuenta inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }  

            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text) || string.IsNullOrWhiteSpace(textBoxLastName.Text))
            {
                MessageBox.Show("El nombre y el apellido no pueden estar vacíos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(textBoxBalance.Text, out decimal balance) || balance < 0)
            {
                MessageBox.Show("Saldo inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            records.Add(new Record(accountNumber, textBoxFirstName.Text.Trim(), textBoxLastName.Text.Trim(), balance));


            if (records.Count == 0)
            {
                MessageBox.Show("No hay datos para guardar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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


            MessageBox.Show("Datos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}
