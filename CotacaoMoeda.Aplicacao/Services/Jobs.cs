using CotacaoMoeda.Application.Fila.Jobs;
using Hangfire;
using MediatR;
using System.Threading.Tasks;

namespace CotacaoMoeda.Application.Services
{
    public class Jobs
    {
        private readonly IMediator _mediator;

        public Jobs(IMediator mediator)
        {
            _mediator = mediator;
        }
        public void StartBackgroudJobs()
        {
            RecurringJob.AddOrUpdate(() => GetCotacao(), "*/2 * * * *");
        }

        public async Task GetCotacao()
        {
            await _mediator.Send(new GetCotacaoCommand());
        }
    }
}
