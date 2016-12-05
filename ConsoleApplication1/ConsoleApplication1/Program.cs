using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    class Program
    {
        private string mModelPath = @"C:\Users\ck14567\Documents\Visual Studio 2015\Projects\ConsoleApplication1\packages\OpenNLP.1.3.3\lib\net45\";
        private OpenNLP.Tools.SentenceDetect.MaximumEntropySentenceDetector mSentenceDetector;
        private OpenNLP.Tools.Tokenize.EnglishMaximumEntropyTokenizer mTokenizer;
        private OpenNLP.Tools.PosTagger.EnglishMaximumEntropyPosTagger mPosTagger;
        
        private string[] SplitSentences(string paragraph)
        {
            if (mSentenceDetector == null)
            {
                mSentenceDetector =
                    new OpenNLP.Tools.SentenceDetect.EnglishMaximumEntropySentenceDetector(mModelPath +
                                                                                           "EnglishSD.nbin");
            }

            return mSentenceDetector.SentenceDetect(paragraph);
        }

        public string CleanStopWords(string inputText)
        {
            var StopWords = new StopWords();
            var stopWords= StopWords.returnStopWords();
            stopWords = stopWords.OrderByDescending(w => w.Length).ToArray();

            string outputText = Regex.Replace(inputText, "\\b" + string.Join("\\b|\\b", stopWords) + "\\b", " ", RegexOptions.IgnoreCase);

            return outputText;
        }

        private string[] TokenizeSentence(string sentence)
        {
            if (mTokenizer == null)
            {
                mTokenizer =
                    new OpenNLP.Tools.Tokenize.EnglishMaximumEntropyTokenizer(mModelPath + "EnglishTok.nbin");
            }

            return mTokenizer.Tokenize(sentence);
        }

        private string[] PosTagTokens(string[] tokens)
        {
            if (mPosTagger == null)
            {
                mPosTagger =
                    new OpenNLP.Tools.PosTagger.EnglishMaximumEntropyPosTagger(mModelPath + "EnglishPOS.nbin");
            }

            return mPosTagger.Tag(tokens);
        }
        static void Main(string[] args)
        {
            var input = "[Highcharts] Ability to Admin to select formats in which to allow chart image downloads";


            var program = new Program();
            var convert=new Convert();
            var inputData = convert.ConvertCSVtoDataTable("C:\\Users\\ck14567\\Desktop\\issues2.csv");
            //string output = "description" + "|" + "title"+ "|" + "storypoint"+ System.Environment.NewLine;
            string output = inputData[0] + System.Environment.NewLine;
            for (int i = 1; i < inputData.Length; i++)
            {
                var c= inputData[i].Split(',');
                output = output + c[0] + "," + c[1]+",";
                var titleTags = program.GetTags(c[2]);
                for (int j = 0; j < titleTags.Length; j++)
                {

                    if (j == titleTags.Length - 1)
                        output = output + titleTags[j];
                    else
                    {
                        output = output + titleTags[j] + " ";
                    }
                }

                output = output + ", ";

                var descTags = program.GetTags(c[3]);
                for (int j = 0; j < descTags.Length; j++)
                {
                    
                    if(j==descTags.Length - 1)
                        output = output + descTags[j];
                    else
                    {
                        output = output + descTags[j] + " ";
                    }
                }

                output = output + ", "+c[4] + System.Environment.NewLine;
               

            }
            System.IO.File.WriteAllText("C:\\Users\\ck14567\\Documents\\ihour.txt", output);
            
        }

        public string[] GetTags(string input)
        {
            var program = new Program();
            var removeStopWords = program.CleanStopWords(input);
            var tokenisedStrings = program.TokenizeSentence(removeStopWords);
            //var posTagged = program.PosTagTokens(tokenisedStrings);
            
            //List<string> posTaggedFinal=new List<string>();
            
            //for (var i = 0; i < tokenisedStrings.Length; i++)
            //{
            //    if (posTagged[i].Equals("LS") || posTagged[i].Equals("VB") || posTagged[i].Equals("VBD") || posTagged[i].Equals("VBG") || posTagged[i].Equals("VBN") || posTagged[i].Equals("VBP") || posTagged[i].Equals("VBZ"))
            //        continue;
            //    posTaggedFinal.Add(tokenisedStrings[i]);
                
            //}
           
            return tokenisedStrings;
        }
    }
}