using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DivisorDeAPIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //string readPath = Console.ReadLine();
            //string readModel = Console.ReadLine();
            //var paths = obj.paths[readPath];
            //var components = obj.components.schemas[readModel];
            //var info = obj.info;
            //var servers = obj.servers;
            //var serverb = servers[0].variables.basePath["default"];
            //serverb = "bolinho";

            //obj.servers[0].variables.basePath["default"] = "bolinho";

            //Console.WriteLine(serverb);

            //var paths = obj.paths;

            //    //var partePrincipal = obj;
            //    //partePrincipal.paths = null;
            //    //partePrincipal.components = null;

            //    //partePrincipal.paths = login;

            //    //arquivoLogin = partePrincipal;
            //    arquivoLogin = "{" + loginTeste + login2Teste + "}";
            //    //arquivoLogin.info.title = "Login";
            //}

            //SalvarConteudo(caminhoArquivoNovo, loginTeste, true);
            //arquivoNovo.WriteLine(partePrincipal[0]);
            //arquivoNovo.Close();
            //dynamic conteudo = ObterConteudo(caminhoArquivoNovo);

            string[] nomeArquivos = { "Login", "Onboarding", "Customer", "Personal Account Creation", "Company Account Creation", "Account", "Cards", "P2P", "Bank Transfer", "Payment Slip", "Common Functionalities" };

            dynamic obj = ObterConteudo(@"C:\Users\fgonzalez\Downloads\BlueC Sandbox-v1-oas30 (2).json");
            
            string aspas = "\"";

            var components = obj.components;
            var componentsFinal = aspas + "components" + aspas + ": " + components;

            foreach (var item in nomeArquivos)
            {
                var caminhoArquivoNovo = @"C:\Users\fgonzalez\Documents\CSU\APIs-Divididas\" + item + ".json";
                var caminhoAux = @"C:\Users\fgonzalez\Documents\CSU\APIs-Divididas-Aux\" + item + ".json";

                var login = obj.paths["/token"];
                var loginTeste = aspas + "/token" + aspas + ": " + login + ",";
                var login2 = obj.paths["/documents/token-device"];
                var login2Teste = aspas + "/documents/token-device" + aspas + ": " + login2;

                var arquivoNovo = new StreamWriter(caminhoArquivoNovo);

                if (item == "Login")
                {
                    obj.info.title = "Login";
                    SalvarConteudo(caminhoAux, obj, true);

                    var sr = new StreamReader(caminhoAux);
                    string arquivoCompleto = sr.ReadToEnd();

                    var parteSecundaria = arquivoCompleto.Substring(arquivoCompleto.IndexOf("paths", 0) + 10);
                    var partePrincipal = arquivoCompleto.Split(parteSecundaria);

                    arquivoNovo.Write(partePrincipal[0]);
                    arquivoNovo.WriteLine(loginTeste);
                    arquivoNovo.WriteLine(login2Teste);
                    arquivoNovo.WriteLine("},");
                }

                arquivoNovo.WriteLine(componentsFinal);
                arquivoNovo.WriteLine("}");
                arquivoNovo.Close();
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

        private static void SalvarConteudo(string caminhoArquivo, object? conteudo, bool identar)
        {
            Formatting formatacao = identar ? Formatting.Indented : Formatting.None;
            string texto = JsonConvert.SerializeObject(conteudo, formatacao);
            File.WriteAllText(caminhoArquivo, texto);
        }
    }
}