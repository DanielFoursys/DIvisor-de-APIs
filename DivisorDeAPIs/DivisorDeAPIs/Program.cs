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
            string[] nomeArquivos = { NomeApis.Login, NomeApis.Onboarding, NomeApis.Customer, NomeApis.PersonalAccountCreation, NomeApis.CompanyAccountCreation, NomeApis.Account, NomeApis.Cards, NomeApis.P2P, NomeApis.BankTransfer, NomeApis.PaymentSlip, NomeApis.CommonFunctionalities };
            dynamic obj = ObterConteudo(@"C:\Users\fgonzalez\Downloads\BlueC Sandbox-v1-oas30.json");
            
            string aspas = "\"";

            var components = obj.components;
            var componentsFinal = aspas + "components" + aspas + ": " + components;

            foreach (var item in nomeArquivos)
            {
                var caminhoArquivoNovo = @"C:\Users\fgonzalez\Documents\CSU\APIs-Divididas\" + item + ".json";
                var caminhoAux = @"C:\Users\fgonzalez\Documents\CSU\APIs-Divididas-Aux\" + item + ".json";
                var arquivoNovo = new StreamWriter(caminhoArquivoNovo);

                switch (item)
                {
                    case NomeApis.Login:
                        obj.info.title = NomeApis.Login;
                        SalvarConteudo(caminhoAux, obj, true);

                        var sr = new StreamReader(caminhoAux);
                        string arquivoCompleto = sr.ReadToEnd();

                        var partePrincipal = RetornaPartePrincipalDoArquivo(arquivoCompleto);

                        string[] nomeRotasLogin = { "/token", "/documents/token-device" };
                        var rotas = RetornaRotasDaApi(nomeRotasLogin, obj, aspas);

                        CriaArquivoJsonCorreto(arquivoNovo, partePrincipal, rotas, componentsFinal);
                        break;
                    case NomeApis.Onboarding:
                        obj.info.title = NomeApis.Onboarding;
                        SalvarConteudo(caminhoAux, obj, true);

                        sr = new StreamReader(caminhoAux);
                        arquivoCompleto = sr.ReadToEnd();

                        partePrincipal = RetornaPartePrincipalDoArquivo(arquivoCompleto);

                        string[] nomeRotasOnboarding = { "/documents/agreement" };
                        rotas = RetornaRotasDaApi(nomeRotasOnboarding, obj, aspas);

                        CriaArquivoJsonCorreto(arquivoNovo, partePrincipal, rotas, componentsFinal);
                        break;
                    case NomeApis.Customer:
                        obj.info.title = NomeApis.Customer;
                        SalvarConteudo(caminhoAux, obj, true);

                        sr = new StreamReader(caminhoAux);
                        arquivoCompleto = sr.ReadToEnd();

                        partePrincipal = RetornaPartePrincipalDoArquivo(arquivoCompleto);

                        string[] nomeRotasCustomer = { "/customer/account", "/customer/validate-document" };
                        rotas = RetornaRotasDaApi(nomeRotasCustomer, obj, aspas);

                        CriaArquivoJsonCorreto(arquivoNovo, partePrincipal, rotas, componentsFinal);
                        break;
                    case NomeApis.PersonalAccountCreation:
                        obj.info.title = NomeApis.PersonalAccountCreation;
                        SalvarConteudo(caminhoAux, obj, true);

                        sr = new StreamReader(caminhoAux);
                        arquivoCompleto = sr.ReadToEnd();

                        partePrincipal = RetornaPartePrincipalDoArquivo(arquivoCompleto);

                        string[] nomeRotasPersonalAccountCreation = { "/create-account" };
                        rotas = RetornaRotasDaApi(nomeRotasPersonalAccountCreation, obj, aspas);

                        CriaArquivoJsonCorreto(arquivoNovo, partePrincipal, rotas, componentsFinal);
                        break;
                    case NomeApis.CompanyAccountCreation:
                        obj.info.title = NomeApis.CompanyAccountCreation;
                        SalvarConteudo(caminhoAux, obj, true);

                        sr = new StreamReader(caminhoAux);
                        arquivoCompleto = sr.ReadToEnd();

                        partePrincipal = RetornaPartePrincipalDoArquivo(arquivoCompleto);

                        string[] nomeRotasCompanyAccountCreation = { "/create-account" };
                        rotas = RetornaRotasDaApi(nomeRotasCompanyAccountCreation, obj, aspas);

                        CriaArquivoJsonCorreto(arquivoNovo, partePrincipal, rotas, componentsFinal);
                        break;
                    case NomeApis.Account:
                        obj.info.title = NomeApis.Account;
                        SalvarConteudo(caminhoAux, obj, true);

                        sr = new StreamReader(caminhoAux);
                        arquivoCompleto = sr.ReadToEnd();

                        partePrincipal = RetornaPartePrincipalDoArquivo(arquivoCompleto);

                        string[] nomeRotasAccount = { "/account/{accountId}/balance", "/account/{accountId}/statement" };
                        rotas = RetornaRotasDaApi(nomeRotasAccount, obj, aspas);

                        CriaArquivoJsonCorreto(arquivoNovo, partePrincipal, rotas, componentsFinal);
                        break;
                    case NomeApis.Cards:
                        obj.info.title = NomeApis.Cards;
                        SalvarConteudo(caminhoAux, obj, true);

                        sr = new StreamReader(caminhoAux);
                        arquivoCompleto = sr.ReadToEnd();

                        partePrincipal = RetornaPartePrincipalDoArquivo(arquivoCompleto);

                        string[] nomeRotasCards = { "/card/{accountId}/prepaid/physical/create", "/card/{cardId}", "/card/{cardId}/pin/reset", "/card/customer", "/card/status/update", "/card/status", "/card/next-status" };
                        rotas = RetornaRotasDaApi(nomeRotasCards, obj, aspas);

                        CriaArquivoJsonCorreto(arquivoNovo, partePrincipal, rotas, componentsFinal);
                        break;
                    case NomeApis.P2P:
                        obj.info.title = NomeApis.P2P;
                        SalvarConteudo(caminhoAux, obj, true);

                        sr = new StreamReader(caminhoAux);
                        arquivoCompleto = sr.ReadToEnd();

                        partePrincipal = RetornaPartePrincipalDoArquivo(arquivoCompleto);

                        string[] nomeRotasP2P = { "/transfer/p2p" };
                        rotas = RetornaRotasDaApi(nomeRotasP2P, obj, aspas);

                        CriaArquivoJsonCorreto(arquivoNovo, partePrincipal, rotas, componentsFinal);
                        break;
                    case NomeApis.BankTransfer:
                        obj.info.title = NomeApis.BankTransfer;
                        SalvarConteudo(caminhoAux, obj, true);

                        sr = new StreamReader(caminhoAux);
                        arquivoCompleto = sr.ReadToEnd();

                        partePrincipal = RetornaPartePrincipalDoArquivo(arquivoCompleto);

                        string[] nomeRotasBankTransfer = { "/banktransfer" };
                        rotas = RetornaRotasDaApi(nomeRotasBankTransfer, obj, aspas);

                        CriaArquivoJsonCorreto(arquivoNovo, partePrincipal, rotas, componentsFinal);
                        break;
                    case NomeApis.PaymentSlip:
                        obj.info.title = NomeApis.PaymentSlip;
                        SalvarConteudo(caminhoAux, obj, true);

                        sr = new StreamReader(caminhoAux);
                        arquivoCompleto = sr.ReadToEnd();

                        partePrincipal = RetornaPartePrincipalDoArquivo(arquivoCompleto);

                        string[] nomeRotasPaymentSlip = { "/recharge/payment/slip/{id}", "/recharge/payment/slip", "/payment/slip/create", "/payment/slip/validate" };
                        rotas = RetornaRotasDaApi(nomeRotasPaymentSlip, obj, aspas);

                        CriaArquivoJsonCorreto(arquivoNovo, partePrincipal, rotas, componentsFinal);
                        break;
                    case NomeApis.CommonFunctionalities:
                        obj.info.title = NomeApis.CommonFunctionalities;
                        SalvarConteudo(caminhoAux, obj, true);

                        sr = new StreamReader(caminhoAux);
                        arquivoCompleto = sr.ReadToEnd();

                        partePrincipal = RetornaPartePrincipalDoArquivo(arquivoCompleto);

                        string[] nomeRotasCommonFunctionalities = { "/location/province/BR", "/location/province/BR/{provinceId}", "/location/zipcode/{zipcode}", "/location/bank/branch-id", "/location/banks/BR", "/location/document-agencies/BR", "/location/company/economic-activities", "/location/company/company-nature" };
                        rotas = RetornaRotasDaApi(nomeRotasCommonFunctionalities, obj, aspas);

                        CriaArquivoJsonCorreto(arquivoNovo, partePrincipal, rotas, componentsFinal);
                        break;
                    default:
                        throw new Exception("Essa API não está contemplada no switch.");
                }
            }
        }

        private static dynamic[] RetornaRotasDaApi(string[] nomeRotas, dynamic obj, string aspas)
        {
            dynamic[] rotas = new dynamic[nomeRotas.Length];

            for (var i = 0; i < nomeRotas.Length; i++)
            {
                var metodo = obj.paths[nomeRotas[i]];
                dynamic metodoCorreto = null;

                if (i == nomeRotas.Length - 1)
                {
                    metodoCorreto = aspas + nomeRotas[i] + aspas + ": " + metodo;
                }
                else
                {
                    metodoCorreto = aspas + nomeRotas[i] + aspas + ": " + metodo + ",";
                }

                rotas.SetValue(metodoCorreto, i);
            }

            return rotas;
        }

        private static string[] RetornaPartePrincipalDoArquivo(string arquivoCompleto)
        {
            var parteSecundaria = arquivoCompleto.Substring(arquivoCompleto.IndexOf("paths", 0) + 10);
            var partePrincipal = arquivoCompleto.Split(parteSecundaria);

            return partePrincipal;
        }

        private static void CriaArquivoJsonCorreto(StreamWriter arquivoNovo ,string[] partePrincipal, dynamic[] rotas, dynamic components)
        {
            arquivoNovo.Write(partePrincipal[0]);

            foreach (var item in rotas)
            {
                arquivoNovo.WriteLine(item);
            }

            arquivoNovo.WriteLine("},");
            arquivoNovo.WriteLine(components);
            arquivoNovo.WriteLine("}");
            arquivoNovo.Close();
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