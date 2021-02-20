using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CotacaoMoeda.Aplicacao.Fila.ViewModels;
using CotacaoMoeda.Aplicacao.Interfaces;
using CotacaoMoeda.Application.Exceptions;
using CotacaoMoeda.Dominio.Enum;
using Microsoft.Extensions.Logging;

namespace CotacaoMoeda.Application.Fila.Jobs
{
    public class GetCotacaoCommandHandler : IRequestHandler<GetCotacaoCommand, Unit>
    {
        private readonly IFilaApplicationService _filaApplicationService;
        private readonly ILogger<GetCotacaoCommandHandler> _logger;

        public GetCotacaoCommandHandler(IFilaApplicationService filaApplicationService, ILogger<GetCotacaoCommandHandler> logger)
        {
            _filaApplicationService = filaApplicationService;
            _logger = logger;
        }
        public async Task<Unit> Handle(GetCotacaoCommand request, CancellationToken cancellationToken)
        {
            var dataInicioProcesso = DateTime.Now;

            _logger.LogInformation($"Job iniciada às {dataInicioProcesso}");

            var itemFila = _filaApplicationService.GetItemFilaDataFormatada();

            if (itemFila is null)
            {
                _logger.LogError("A fila não possui itens.");

                throw new NotFoundException("A fila não possui itens.");
            }


            var dadosMoeda = LerDados(itemFila);

            if (dadosMoeda.Count > 0)
            {
                var dadosCotacao = LerDadosCotacao(dadosMoeda);

                GerarArquivoCotacao(dadosMoeda, dadosCotacao);

                var dataFimProcesso = DateTime.Now;
                _logger.LogInformation($"Job encerrada às {dataFimProcesso}");

                var tempoProcesso = dataInicioProcesso - dataFimProcesso;

                _logger.LogInformation($"Tempo total de processamento : {tempoProcesso.TotalMinutes}:{tempoProcesso.TotalSeconds}");
            }
            else
            {
                _logger.LogInformation($"Não foram encontrados dados para o período {itemFila.Data_Inicio} a {itemFila.Data_Fim}");
                _logger.LogInformation($"Job encerrada às {DateTime.Now}");
            }

            return Unit.Value;
        }

        private void GerarArquivoCotacao(List<DadosMoeda> dadosMoeda, List<DadosCotacao> dadosCotacao)
        {
            var dadosCsv = new List<dynamic>();

            //Filtra as cotações de acordo com as moedas encontradas
            foreach (var moeda in dadosMoeda)
            {
                dadosCsv.Add(new
                {
                    Moeda = moeda.Moeda,
                    DataRef = moeda.Data_Ref,
                    cotacao = dadosCotacao.LastOrDefault(x => x.Cod_Cotacao == BuscarCodigo(moeda.Moeda))
                });
            }

            var dataAtual = DateTime.Now;

            using (var stream = new StreamWriter($"Resultado_{dataAtual.ToString("yyyyMMdd")}_{dataAtual.ToString("HHmmss")}.csv"))
            {
                stream.WriteLine("ID_MOEDA;DATA_REF;VL_COTACAO");

                foreach (var dado in dadosCsv)
                {
                    stream.WriteLine($"{dado.Moeda};{dado.DataRef.ToString("dd/MM/yyyy")};{dado.cotacao.Vlr_Cotacao}");
                }
            }

        }

        private int BuscarCodigo(ETipoMoeda moeda)
        {
            int codigo = 0;
            switch (moeda)
            {
                case ETipoMoeda.AFN:
                    codigo = 66;
                    break;
                case ETipoMoeda.ALL:
                    codigo = 49;
                    break;
                case ETipoMoeda.ANG:
                    codigo = 33;
                    break;
                case ETipoMoeda.ARS:
                    codigo = 3;
                    break;
                case ETipoMoeda.AWG:
                    codigo = 6;
                    break;
                case ETipoMoeda.BOB:
                    codigo = 56;
                    break;
                case ETipoMoeda.BYN:
                    codigo = 64;
                    break;
                case ETipoMoeda.CAD:
                    codigo = 25;
                    break;
                case ETipoMoeda.CDF:
                    codigo = 58;
                    break;
                case ETipoMoeda.CLP:
                    codigo = 16;
                    break;
                case ETipoMoeda.COP:
                    codigo = 37;
                    break;
                case ETipoMoeda.CRC:
                    codigo = 52;
                    break;
                case ETipoMoeda.CUP:
                    codigo = 8;
                    break;
                case ETipoMoeda.CVE:
                    codigo = 51;
                    break;
                case ETipoMoeda.CZK:
                    codigo = 29;
                    break;
                case ETipoMoeda.DJF:
                    codigo = 36;
                    break;
                case ETipoMoeda.DZD:
                    codigo = 54;
                    break;
                case ETipoMoeda.EGP:
                    codigo = 12;
                    break;
                case ETipoMoeda.EUR:
                    codigo = 20;
                    break;
                case ETipoMoeda.FJD:
                    codigo = 38;
                    break;
                case ETipoMoeda.GBP:
                    codigo = 22;
                    break;
                case ETipoMoeda.GEL:
                    codigo = 48;
                    break;
                case ETipoMoeda.GIP:
                    codigo = 18;
                    break;
                case ETipoMoeda.HTG:
                    codigo = 63;
                    break;
                case ETipoMoeda.ILS:
                    codigo = 40;
                    break;
                case ETipoMoeda.IRR:
                    codigo = 17;
                    break;
                case ETipoMoeda.ISK:
                    codigo = 11;
                    break;
                case ETipoMoeda.JPY:
                    codigo = 9;
                    break;
                case ETipoMoeda.KES:
                    codigo = 21;
                    break;
                case ETipoMoeda.KMF:
                    codigo = 19;
                    break;
                case ETipoMoeda.LBP:
                    codigo = 42;
                    break;
                case ETipoMoeda.LSL:
                    codigo = 4;
                    break;
                case ETipoMoeda.MGA:
                    codigo = 35;
                    break;
                case ETipoMoeda.MGB:
                    codigo = 26;
                    break;
                case ETipoMoeda.MMK:
                    codigo = 69;
                    break;
                case ETipoMoeda.MRO:
                    codigo = 53;
                    break;
                case ETipoMoeda.MRU:
                    codigo = 15;
                    break;
                case ETipoMoeda.MUR:
                    codigo = 7;
                    break;
                case ETipoMoeda.MXN:
                    codigo = 41;
                    break;
                case ETipoMoeda.MZN:
                    codigo = 43;
                    break;
                case ETipoMoeda.NIO:
                    codigo = 23;
                    break;
                case ETipoMoeda.NOK:
                    codigo = 62;
                    break;
                case ETipoMoeda.OMR:
                    codigo = 34;
                    break;
                case ETipoMoeda.PEN:
                    codigo = 45;
                    break;
                case ETipoMoeda.PGK:
                    codigo = 2;
                    break;
                case ETipoMoeda.PHP:
                    codigo = 24;
                    break;
                case ETipoMoeda.RON:
                    codigo = 5;
                    break;
                case ETipoMoeda.SAR:
                    codigo = 44;
                    break;
                case ETipoMoeda.SBD:
                    codigo = 32;
                    break;
                case ETipoMoeda.SGD:
                    codigo = 70;
                    break;
                case ETipoMoeda.SLL:
                    codigo = 10;
                    break;
                case ETipoMoeda.SOS:
                    codigo = 61;
                    break;
                case ETipoMoeda.SSP:
                    codigo = 47;
                    break;
            }

            return codigo;
        }

        private List<DadosCotacao> LerDadosCotacao(List<DadosMoeda> dadosMoeda)
        {

            string path = Path.Combine("DadosCotacao.csv");

            if (string.IsNullOrEmpty(path))
            {
                _logger.LogError("Arquivo : DadosCotacao.csv não encontrado.");

                throw new NotFoundException("Arquivo : DadosCotacao.csv não encontrado.");
            }

            var dadosCotacao = new List<DadosCotacao>();

            using (StreamReader reader = new StreamReader(path))
            {
                string linha;
                string[] dadosLinha = null;

                int contador = 0;
                while ((linha = reader.ReadLine()) != null)
                {
                    if (contador > 0)
                    {
                        dadosLinha = linha.Split(';');

                        dadosCotacao.Add(new DadosCotacao
                        {
                            Vlr_Cotacao = double.Parse(dadosLinha[0]),
                            Cod_Cotacao = int.Parse(dadosLinha[1]),
                            Dat_Cotacao = DateTime.Parse(dadosLinha[2])
                        });
                    }

                    contador++;
                }
            }

            return dadosCotacao;
        }

        private List<DadosMoeda> LerDados(ItemFilaViewModel itemFila)
        {

            string path = Path.Combine("DadosMoeda.csv");

            if (string.IsNullOrEmpty(path))
                throw new NotFoundException("Arquivo : DadosMoeda.csv não encontado.");

            List<DadosMoeda> dados = new List<DadosMoeda>();

            using (StreamReader reader = new StreamReader(path))
            {
                string linha;
                string[] dadosLinha = null;

                int contador = 0;
                while ((linha = reader.ReadLine()) != null)
                {
                    if (contador > 0)
                    {
                        dadosLinha = linha.Split(';');

                        dados.Add(new DadosMoeda { Moeda = (ETipoMoeda)Enum.Parse(typeof(ETipoMoeda), dadosLinha[0]), Data_Ref = DateTime.Parse(dadosLinha[1]) });
                    }

                    contador++;
                }
            }

            return dados.Where(x => x.Data_Ref >= DateTime.Parse(itemFila.Data_Inicio) && x.Data_Ref <= DateTime.Parse(itemFila.Data_Fim)).ToList();
        }
    }
}
