﻿using Cloudmersive.APIClient.NET.OCR.Api;
using Cloudmersive.APIClient.NET.OCR.Client;
using Cloudmersive.APIClient.NET.OCR.Model;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace CloudmersiveOCRDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var response = new ImageToTextResponse();
            Configuration.Default.AddApiKey("Apikey", "c3543902-1862-498b-ba4a-256688c39435");
            var apiInstance = new ImageOcrApi();
            var imageFile = new System.IO.FileStream(@"C:\Temp\aratest.tif", System.IO.FileMode.Open); // System.IO.Stream | Image file to perform OCR on.  Common file formats such as PNG, JPEG are supported.

            try
            {
                // Converts an uploaded image in common formats such as JPEG, PNG into text via Optical Character Recognition.
                response = apiInstance.ImageOcrPost(imageFile, txtLanguage.Text, "none");
                Debug.Print(response.TextResult);

                txtResult.Text = response.TextResult;
            }
            catch
            {
                Debug.Print("Exception when calling ImageOcrApi.ImageOcrPost: ");
            }
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "C# Corner Open File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog().Value)
            {
                txtInputFile.Text = fdlg.FileName;
            }
        }

        private void btnGetLines_Click(object sender, RoutedEventArgs e)
        {
            Configuration.Default.AddApiKey("Apikey", "c3543902-1862-498b-ba4a-256688c39435");
            var apiInstance = new ImageOcrApi();
            var imageFile = new System.IO.FileStream(@"C:\Temp\aratest.tif", System.IO.FileMode.Open); // System.IO.Stream | Image file to perform OCR on.  Common file formats such as PNG, JPEG are supported.

            try
            {
                // Converts an uploaded image in common formats such as JPEG, PNG into text via Optical Character Recognition.
                var response = apiInstance.ImageOcrImageLinesWithLocation(imageFile, txtLanguage.Text, "none");

                txtResult.Text = JsonConvert.SerializeObject(response);
            }
            catch
            {
                Debug.Print("Exception when calling ImageOcrApi.ImageOcrPost: ");
            }
        }
    }
}
