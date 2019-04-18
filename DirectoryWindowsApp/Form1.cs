using System;
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

                        
                        var words = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
                        
                       
                        string content = File.ReadAllText(file);

                        
                        var wordPattern = new Regex(@".[\$]?(\w+)");
                        

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


                listBox_allSortedFiles.Items.Clear();
                foreach (var directory in directories)
                {
                    string[] sortedFilesInAllDirectories = new string[200];
                    sortedFilesInAllDirectories = Directory.GetFiles(directory, "*.txt");
                    foreach (var sortedFiles in sortedFilesInAllDirectories)
                    {


                        if (Path.GetFileName(sortedFiles).StartsWith("sorted"))
                            listBox_allSortedFiles.Items.Add(Path.GetFileName(sortedFiles));
                    }

                }


            }
        }



        
        public static string PadNumbers(string input)
        {
            return Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(10, '0'));
        }




        
        private void button_searchWords_Click(object sender, EventArgs e)
        {
            string[] filesSorted = new string[200];

            
            string searchWord = textBox_searchWords.Text;


            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
               
                string path = fbd.SelectedPath;
                
                filesSorted = Directory.GetFiles(path, "*.txt");

                
                listBox_listSearchFiles.Items.Clear();

               
                foreach (var fileSorted in filesSorted)
                {
                    if (Path.GetFileName(fileSorted).StartsWith("sorted"))
                    {
                        
                        using (StreamReader sr = new StreamReader(fileSorted))
                        {
                            string line = null;
                            while ((line = sr.ReadLine()) != null)
                            {
                                
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

        /************************************ 2nd part **************************************/


        
        private void button1_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                
                filesCalc = Directory.GetFiles(fbd.SelectedPath, "*.calc");

                string path = Path.GetFileName(fbd.SelectedPath);

                
                string filePath = fbd.SelectedPath + "/Output" + ".answ";

               
                if (!File.Exists(filePath))
                {
                    var answFile = File.CreateText(filePath);
                    answFile.Close();
                    listBox_listAnswers.Items.Add(Path.GetFileName(filePath));
                }

                
                listBox_listCalcFiles.Items.Clear();

                
                foreach (var fileCalc in filesCalc)
                {
                    
                    listBox_listCalcFiles.Items.Add(Path.GetFileName(fileCalc));

                   
                    string[] lines = File.ReadAllLines(fileCalc);
                    foreach (string line in lines)
                    {
                        EvaluateString es = new EvaluateString();
                       
                        calcExpressions.Add(line + " = " + Math.Round(es.evaluate(line),2));
                        listBox_listAnswers.Items.Add(line + " = " + Math.Round(es.evaluate(line),2));

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
