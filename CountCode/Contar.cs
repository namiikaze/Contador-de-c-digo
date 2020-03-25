using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;


namespace CountCode
{
    class Contar
    {
        List<string> PathArchive = new List<string>();
        int qntTotal = 0;
        int qntArquivos = 0;
        
        public string Calcular(string path, string[] TiposPermitido)
        {
            string retorno = "";
           
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            BuscaArquivos(dirInfo);

            string[] todosArquivos = PathArchive.ToArray();
            foreach (string arquivo in todosArquivos)
            {
                if (TipoArquivo(arquivo, TiposPermitido))
                {
                    int qntLinhas;
                    qntLinhas = LerArquivo(arquivo);
                    Debug.WriteLine(qntLinhas + ": " + arquivo);
                    retorno += qntLinhas + ": " + arquivo + "\n";
                    qntTotal += qntLinhas;
                    qntArquivos++;
                }
            }
            Debug.WriteLine("Quantidade de arquivos: " + qntArquivos);
            Debug.WriteLine("Quantidade Total de linhas: " + qntTotal);

            retorno += "Quantidade de arquivos: " + qntArquivos +"\n";
            retorno += "Quantidade Total de linhas: " + qntTotal + "\n";

            return retorno;
        }
        private void BuscaArquivos(DirectoryInfo dir)
        {
            // lista arquivos do diretorio corrente
            foreach (FileInfo file in dir.GetFiles())
            {
                  // aqui no caso estou guardando o nome completo do arquivo em em controle ListBox
                 // voce faz como quiser
                //lbxResultado.Items.Add(file.FullName);
                //Debug.WriteLine(file.FullName);
                PathArchive.Add(file.FullName);
            }

            // busca arquivos do proximo sub-diretorio
            foreach (DirectoryInfo subDir in dir.GetDirectories())
            {
                BuscaArquivos(subDir);
            }
        }

        private int LerArquivo(string path)
        {
            int counter = 0;
            string line;

            System.IO.StreamReader file =
                new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
//                System.Console.WriteLine(line);
                counter++;
            }

            file.Close();
            
            return counter;
        }

        private bool TipoArquivo(string arquivo, string[] formato)
        {
            

            string extensao = Path.GetExtension(arquivo);

            bool retorno = false;

            foreach (string ext in formato)
            {
               string exten = ext;
                
                if (ext[0] != '.')
                {
                    exten = "." + ext;
                }
                
                if (extensao == exten)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

    }
}
