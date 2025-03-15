using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLib.Models;
using MyLib;
using System.IO;

namespace MyTreeView
{
    public partial class MainForm : Form
    {
        private List<TreeNodeModel> treeData_;
        private ProductModel ProductModel_;
        private ProductDataModel ProductDataModel_;
        
        public MainForm()
        {
            InitializeComponent();

            treeData_ = new List<TreeNodeModel>();
            ProductModel_ = new ProductModel();
            ProductDataModel_ = new ProductDataModel();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {            
            productDataGridView.Columns.Add("NameColumn", "Название");
            productDataGridView.Columns.Add("CostColumn", "Цена");
            productDataGridView.Columns.Add("ProducerColumn", "Производитель");
            productDataGridView.Columns["ProducerColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            treeData_ = ProductDataModel_.treeData;
            FillTreeNodeCollection(treeData_, productTreeView.Nodes);
            productTreeView.ExpandAll();
        }

        static private void FillTreeNodeCollection(List<TreeNodeModel> sourceData, TreeNodeCollection targetData)
        {
            foreach (var node in sourceData)
            {
                var treeNode = new TreeNode(node.Name);
                targetData.Add(treeNode);

                if (node.Children != null && node.Children.Count > 0)
                {
                    FillTreeNodeCollection(node.Children, treeNode.Nodes);
                }
            }
        }


        private void TreeViewCar_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Nodes.Count ==0)
            {
                Product product = ProductModel_.GetExampleByName(e.Node.Text);
                if (product !=  null)
                {
                    object[] newRow = { product.name, product.cost, product.producer};
                    productDataGridView.Rows.Add(newRow);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // проверка на наличие данных в таблице
            if (productDataGridView.Rows.Count == 0)
            {
                MessageBox.Show("В таблице нет данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "./";
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog.Title = "Выберите файл";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string selectedFileName = openFileDialog.FileName;
                    SaveDataToCsv savedData = new SaveDataToCsv(selectedFileName, productDataGridView);
                    MessageBox.Show("Данные успешно сохранены. Путь к файлу: " + selectedFileName, "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось сохранить файл.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // очищаем таблицу
            productDataGridView.Rows.Clear();

            string filePath = "data.csv";
            LoadDataFromCsv loadedData = new LoadDataFromCsv(filePath, productDataGridView);

            MessageBox.Show($"Данные из файла успешно загружены.", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

