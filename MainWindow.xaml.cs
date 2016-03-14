using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;

// For button click functions call
namespace System.Windows.Controls
{
    /// <summary>
    /// For allow perform button click 
    /// </summary>
    public static class MyExt
    {
        public static void PerformClick(this Button btn)
        {
            btn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }
    }
}

namespace KZT_5_Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private const int MatrixSize = 10;
        private Server Server = new Server();
        private int PreviousCompletedRowsCount;
        private bool MessageCompleteIsShown;

        private readonly DispatcherTimer _timer =
            new DispatcherTimer();

        private readonly Random _rand = new Random();

        private bool leftMatrixGenerated = false;
        private bool rightMatrixGenerated = false;

        public MainWindow()
        {
            InitializeComponent();

            _timer.Tick += Tick;
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
        }

        /// <summary>
        /// Starts server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButtonStartServer_Click(object sender, RoutedEventArgs e)
        {
            Server.Data.ResultMatrix = new Matrix<byte>(MatrixSize, MatrixSize);
            for (var i = 0; i < Server.Data.ResultMatrix.CountOfRows; i++)
            {
                for (var j = 0; j < Server.Data.ResultMatrix.CountOfColumns; j++)
                {
                    Server.Data.ResultMatrix.SetAt(i, j, 0);
                }
            }

            ButtonStartServer.IsEnabled = false;
            TextBoxClients.Text += "Server started\n";
            _timer.Start();
            await Server.Run();
            ButtonStartServer.IsEnabled = false;
        }

        /// <summary>
        /// Timer method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tick(object sender, EventArgs e)
        {
            

            lock (Server.Data)
            {
                if (!Server.Data.Log.IsEmpty())
                {
                    foreach (var message in Server.Data.Log.Messages)
                    {
                        TextBoxClients.Text += $"{message}\n";
                    }
                    Server.Data.Log.Clear();
                }

                if (PreviousCompletedRowsCount != Server.Data.CompletedRowsInfo.CompletedRows.Count)
                {
                    PrintMatrix(TextBoxMatrixResult, Server.Data.ResultMatrix, true);
                    PreviousCompletedRowsCount = Server.Data.CompletedRowsInfo.CountOfCompletedRows();
                }

                if (Server.Data.FreeRowsInfo.CountOfFreeRows() == 0 && !MessageCompleteIsShown)
                {
                    MessageCompleteIsShown = true;
                    var res = MessageBox.Show("Matrices are added. Do you want to generate a new one?",
                        "Task is completed",
                        MessageBoxButton.YesNo);
                    if (res == MessageBoxResult.Yes)
                    {
                        GenerateLeft.PerformClick();
                        GenerateRight.PerformClick();
                        MessageCompleteIsShown = false;
                    }
                }
            }
        }

        /// <summary>
        /// Prints Server.Data.Matrix to TextBoxMatrix
        /// </summary>
        private void PrintMatrix(TextBox textBox, Matrix<byte> matrix, bool displayCompletedRows)
        {
            lock (Server.Data)
            {
                textBox.Clear();
                for (var i = 0; i < matrix.CountOfRows; i++)
                {
                    for (var j = 0; j < matrix.CountOfColumns; j++)
                    {
                        textBox.Text += $"{matrix.GetAt(i, j),4}";
                    }
                    if (displayCompletedRows)
                    {
                        if (Server.Data.CompletedRowsInfo.IsCompleted(i))
                        {
                            textBox.Text += "    ✓\n";
                        }
                        else
                        {
                            textBox.Text += "    ✗\n";
                        }
                    }
                    else
                    {
                        textBox.Text += "\n";
                    }
                }
            }
        }

        /// <summary>
        /// Generates random matrix to Server.Data.Matrix
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonGenerate_Click(object sender, RoutedEventArgs e)
        {
            MessageCompleteIsShown = false;
            leftMatrixGenerated = true;

            ButtonStartServer.IsEnabled = leftMatrixGenerated && rightMatrixGenerated;
            lock (Server.Data)
            {
                Server.Data.LeftMatrix = new Matrix<byte>(MatrixSize, MatrixSize);
                
                for (var i = 0; i < Server.Data.LeftMatrix.CountOfRows; i++)
                {
                    for (var j = 0; j < Server.Data.LeftMatrix.CountOfColumns; j++)
                    {
                        Server.Data.LeftMatrix.SetAt(i, j, (byte)_rand.Next(100));
                    }
                }

                Server.Data.CompletedRowsInfo.Clear();
                for (var i = 0; i < Server.Data.LeftMatrix.CountOfRows; i++) {
                    Server.Data.FreeRowsInfo.Add(i);
                }

                PrintMatrix(TextBoxMatrixLeft, Server.Data.LeftMatrix, false);
            }
        }

        private void GenerateRightMatrix(object sender, RoutedEventArgs e)
        {
            MessageCompleteIsShown = false;
            rightMatrixGenerated = true;

            ButtonStartServer.IsEnabled = leftMatrixGenerated && rightMatrixGenerated;
            lock (Server.Data)
            {
                Server.Data.RightMatrix = new Matrix<byte>(MatrixSize, MatrixSize);

                for (var i = 0; i < Server.Data.RightMatrix.CountOfRows; i++)
                {
                    for (var j = 0; j < Server.Data.RightMatrix.CountOfColumns; j++)
                    {
                        Server.Data.RightMatrix.SetAt(i, j, (byte)_rand.Next(100));
                    }
                }

                Server.Data.CompletedRowsInfo.Clear();
                for (var i = 0; i < Server.Data.RightMatrix.CountOfRows; i++)
                {
                    Server.Data.FreeRowsInfo.Add(i);
                }

                PrintMatrix(TextBoxMatrixRight, Server.Data.RightMatrix, false);
            }
        }
    }
}
