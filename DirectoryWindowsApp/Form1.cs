﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DirectoryWindowsApp
{
    public partial class Form1 : Form
    {
        string[] files,filesCalc;
        string[] sortedWords = new string[200];

        List<string> calcExpressions = new List<string>();
        HashSet<string> directories = new HashSet<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //word sorting functionality
        private void button_selectDirectory_Click(object sender, EventArgs e)
        {
            
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {

               
                directories.Add(fbd.SelectedPath);


                listBox_directoryList.Items.Clear();
                foreach (var item in directories)
                {
                    listBox_directoryList.Items.Add(item);
                }

                
                files = Directory.GetFiles(fbd.SelectedPath, "*.txt");

                listBox_listFiles.Items.Clear();
                listBox_listSortedFiles.Items.Clear();

                foreach (var file in files)
                {
                    if (!Path.GetFileName(file).StartsWith("sorted"))
                    {
                        listBox_listFiles.Items.Add(Path.GetFileName(file));

                        
                        string path = fbd.SelectedPath + "/sorted" + Path.GetFileName(file);

                        if (!File.Exists(path))
                        {
                            
                            var sortedFile = File.CreateText(path);
                            sortedFile.Close();
                            listBox_listSortedFiles.Items.Add(Path.GetFileName(path));
                        }

                        // dictionary for storing 
                        var words = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
                        
                        //content of the file
                        string content = File.ReadAllText(file);

                        
                        var wordPattern = new Regex(@"\w+");
                        

                        foreach (Match match in wordPattern.Matches(content))
                        {
                            int currentCount = 0;
                            

                            words.TryGetValue(match.Value, out currentCount);

                            currentCount++;

                            
                            words[match.Value] = currentCount;
                        }

                        
                        using (StreamWriter sw = new StreamWriter(path))
                        {
                            foreach (var word in words.OrderBy(i => PadNumbers(i.Key)))
                            {
                                sw.WriteLine("{0},{1}", word.Key, word.Value);
                            }
                        }
                    }

                }




            }
        }



        //for sorting in alpha numeric way
        public static string PadNumbers(string input)
        {
            return Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(10, '0'));
        }




        // for search functionality
        private void button_searchWords_Click(object sender, EventArgs e)
        {
            string[] filesSorted = new string[200];

            // get the word to searched from the text box
            string searchWord = textBox_searchWords.Text;


            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                //getting the path of selected directory
                string path = fbd.SelectedPath;
                //gettting list of all text files in the directory
                filesSorted = Directory.GetFiles(path, "*.txt");

                //clear the listboc before iterating through a new directory of files
                listBox_listSearchFiles.Items.Clear();

                //iterate through all the text files
                foreach (var fileSorted in filesSorted)
                {
                    //select only those text files which start with sorted prefix
                    if (Path.GetFileName(fileSorted).StartsWith("sorted"))
                    {
                        //read the content of file line by line
                        using (StreamReader sr = new StreamReader(fileSorted))
                        {
                            string line = null;
                            while ((line = sr.ReadLine()) != null)
                            {
                                //if the line contains that search word then save it in listbox
                                if (line.Contains(searchWord))
                                {
                                    listBox_listSearchFiles.Items.Add(Path.GetFileName(fileSorted) + " has : " + line);
                                    break;

                                }
                            }
                        }
                    }


                }

            }
        }

        private void listBox_listSortedFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void listBox_listCalcFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /************************************ 2nd part **************************************/


        //functionlity of number calculation
        private void button1_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                //get all the text files in the selected directory
                filesCalc = Directory.GetFiles(fbd.SelectedPath, "*.calc");

                string path = Path.GetFileName(fbd.SelectedPath);

                //create path for the answ file in the selected directory
                string filePath = fbd.SelectedPath + "/Output" + ".answ";

                //check whether the file exists or not . If does not exist then create a file
                if (!File.Exists(filePath))
                {
                    var answFile = File.CreateText(filePath);
                    answFile.Close();
                    listBox_listAnswers.Items.Add(Path.GetFileName(filePath));
                }

                //clear the listbox showing the list of calc files in the selected directory
                listBox_listCalcFiles.Items.Clear();

                //iterate through all the files and read them one by one
                foreach (var fileCalc in filesCalc)
                {
                    // adding the current calc file in the listbox
                    listBox_listCalcFiles.Items.Add(Path.GetFileName(fileCalc));

                    //reading the content of files line by line and storing the solution in a string array
                    string[] lines = File.ReadAllLines(fileCalc);
                    foreach (string line in lines)
                    {
                        EvaluateString es = new EvaluateString();
                        //adding the evaluated expression in the list in the specified format
                        calcExpressions.Add(line + " = " + Math.Round(es.evaluate(line), 2));
                        listBox_listAnswers.Items.Add(line + " = " + Math.Round(es.evaluate(line), 2));

                    }

                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        foreach (var expression in calcExpressions)
                        {
                            sw.WriteLine(expression);
                        }
                    }

                }
            }


            }



        }
    }
