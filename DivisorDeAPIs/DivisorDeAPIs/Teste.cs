using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisorDeAPIs
{
    public class Teste
    {
        public static void Main(string[] args)
        {
            var sr = new StreamReader(@"C:\Users\fgonzalez\Downloads\BlueC Sandbox-v1-oas30 (2).json");
            string arquivoCompleto = sr.ReadToEnd();

            string[] nomeArquivos = {"Login", "Onboarding", "Customer", "Personal Account Creation", "Company Account Creation", "Account", "Cards", "P2P", "Bank Transfer", "Payment Slip", "Common Functionalities"};

            //Regex prop = new("[a-z]{4,9}[\\s][a-zA-Z]{1,10}[\\s][_]{0,1}[a-zA-Z]{0,9}[\\s]{0,}[_]{0,1}[a-zA-Z]{0,30}[\\s]{0,1}[;|{|=][\\s]{0,}[a-zA-Z1-9]");
            //MatchCollection p = prop.Matches(caminho);
            //Console.WriteLine("Total de propriedades: {0}", p.Count);

            //Console.WriteLine(arquivo);
            var parteSecundaria = arquivoCompleto.Substring(arquivoCompleto.IndexOf("paths", 0) + 10);
            //Console.WriteLine(arquivo);
            var partePrincipal = arquivoCompleto.Split(parteSecundaria);

            var aux = arquivoCompleto.IndexOf("/token-device");
            var aux2 = arquivoCompleto.IndexOf("},", arquivoCompleto.IndexOf("200", aux));

            Console.WriteLine(aux);
            Console.WriteLine(aux2);

            var parteLogin = arquivoCompleto.Substring(arquivoCompleto.IndexOf("/documents/token-device", arquivoCompleto.IndexOf("paths")) - 1);
            var parteLogin2 = arquivoCompleto.Substring(aux2 + 2);

            var teste = parteLogin.Split(parteLogin2);

            var parte2Login = arquivoCompleto.Substring(arquivoCompleto.IndexOf("/token\"", 0) - 1);

            var auxParte2 = arquivoCompleto.IndexOf("/token\"");
            var aux2Parte2 = arquivoCompleto.IndexOf("},", arquivoCompleto.IndexOf("500", auxParte2));

            var parte2Login2 = arquivoCompleto.Substring(aux2Parte2 + 1);

            var teste2 = parte2Login.Split(parte2Login2);

            Console.WriteLine("Começando o primeiro arquivo!!");
            Console.WriteLine(parte2Login);

            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Começando o segundo arquivo!!");
            Console.WriteLine(parte2Login2);

            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Começando o terceiro arquivo!!");
            Console.WriteLine(teste2[0]);

            //Regex met = new("[\\w]{6,9}[\\s][\\w]{3,9}[\\s]{1}[\\w]{1,50}[(][\\s\\S]{0,50}[)][\\s]{0,30}{[\\s]{0,3}");
            //MatchCollection m = met.Matches(caminho);
            //Console.WriteLine("Total de metódos: {0}", m.Count);

            var parteFinal = arquivoCompleto.Substring(arquivoCompleto.IndexOf("components\"", 0) - 1);

            foreach (var item in nomeArquivos)
            {
                var caminhoArquivoNovo = @"C:\Users\fgonzalez\Documents\CSU\APIs-Divididas\" + item + ".json";

                var arquivoNovo = new StreamWriter(caminhoArquivoNovo);

                arquivoNovo.WriteLine(partePrincipal[0]);
                //arquivoNovo.Close();
                //dynamic conteudo = ObterConteudo(caminhoArquivoNovo);

                if (item == "Login")
                {
                    arquivoNovo.WriteLine(teste[0]);
                    arquivoNovo.WriteLine(teste2[0]);
                    arquivoNovo.WriteLine("},");
                    //conteudo["info"]["title"] = "Login";
                }

                arquivoNovo.WriteLine(parteFinal);
                //arquivoNovo.WriteLine("}");
                arquivoNovo.Close();

                //SalvarConteudo(caminhoArquivoNovo, conteudo, true);
            }
        }

        private string RetornaArquivo()
        {
            throw new NotImplementedException();
        }

        private static dynamic ObterConteudo(string caminhoArquivo)
        {
            string texto = File.ReadAllText(caminhoArquivo);
            return JsonConvert.DeserializeObject(texto);
        }

        private static void SalvarConteudo(string caminhoArquivo, dynamic conteudo, bool identar)
        {
            Formatting formatacao = identar ? Formatting.Indented : Formatting.None;
            string texto = JsonConvert.SerializeObject(conteudo, formatacao);
            File.WriteAllText(caminhoArquivo, texto);
        }
    }
}