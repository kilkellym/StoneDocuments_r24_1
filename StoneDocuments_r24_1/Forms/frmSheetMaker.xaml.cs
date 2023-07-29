﻿using Autodesk.Revit.DB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;


namespace StoneDocuments_r24_1
{
    /// <summary>
    /// Interaction logic for frmSheetMaker.xaml
    /// </summary>
    public partial class frmSheetMaker : Window
    {
        ObservableCollection<clsSheetData> SheetList { get; set; }
        ObservableCollection<Element> TBlockData { get; set; }
        ObservableCollection<View> ViewData { get; set; }
        ObservableCollection<ViewSchedule> ScheduleData { get; set; }
        ObservableCollection<string> CategoryData { get; set; }
        ObservableCollection<clsWrapperTBlockType> Types { get; set; }        

        public List<Element> elemList;

        public frmSheetMaker(List<clsWrapperTBlockType> typeList, List<string> CategoryList, List<View> ViewList, List<ViewSchedule> ScheduleList)
        {
            InitializeComponent();

            SheetList = new ObservableCollection<clsSheetData>();
            Types = new ObservableCollection<clsWrapperTBlockType>(typeList);
            CategoryData = new ObservableCollection<string>(CategoryList);
            ViewData = new ObservableCollection<View>(ViewList);
            ScheduleData = new ObservableCollection<ViewSchedule>(ScheduleList);            

           
            sheetGrid.ItemsSource = SheetList;
            cmbTitleblock.ItemsSource = Types;
            cmbCategory.ItemsSource = CategoryData;
            cmbViews.ItemsSource = ViewData;
            cmbSchedules.ItemsSource = ScheduleData;
        }        

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            SheetList.Add(new clsSheetData());
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (clsSheetData curRow in SheetList)
                {
                    if (sheetGrid.SelectedItem == curRow)
                        SheetList.Remove(curRow);
                }
            }
            catch (Exception)
            { }
        }

        public void AddCategoryItem(string userCategory)
        {
            clsSheetData newCat = new clsSheetData();
            CategoryData.Add(userCategory);
        }

        private void btnAddCat_Click(object sender, RoutedEventArgs e)
        {
            //if (curEdit == null)
            //{
            //    AddCategoryItem(tbxAddCat.Text);
            //}

            //tbxAddCat.Text = "";
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        public List<clsSheetData> GetSheetData()
        {
            return SheetList.ToList();
        }

        
    }
}
